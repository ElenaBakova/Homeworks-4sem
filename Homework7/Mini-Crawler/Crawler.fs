module Crawler

open System.Net.Http
open System.Text.RegularExpressions

// Fetches links from given string
let fetchLinks (html: string) =
    let pattern = "<a href=\"(https?:\/\/\S+\W*)\"[^>]*>"

    let matches = Regex.Matches(html, pattern)

    matches
    |> Seq.map (fun item -> item.Groups[1].Value)

// Downloads page by url
let downloadPage (url: string) (client: HttpClient) =
    client.GetStringAsync(url)
    |> Async.AwaitTask
    |> Async.Catch
    |> Async.RunSynchronously

let getSizes (url: string) (client: HttpClient) =
    downloadPage url client
    |> (function
    | Choice1Of2 result -> result.Length
    | Choice2Of2 (ex: exn) -> failwith ex.Message)

// Returns information about size of pages placed in the given page
let getInfo (url: string) =
    async {
        let client = new HttpClient()

        let html =
            downloadPage url client
            |> (function
            | Choice1Of2 result -> result
            | Choice2Of2 (ex: exn) -> failwith ex.Message)


        let links = fetchLinks html

        let sizes =
            links
            |> Seq.map (fun link -> getSizes link client)

        return Seq.zip links sizes
    }
