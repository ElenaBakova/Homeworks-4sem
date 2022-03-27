module PhoneBook.Tests

open NUnit.Framework
open FsUnit
open PhoneBookFunctions

[<Test>]
let ``Test for readFromFile`` () =
    let book = [{ Name = "Name"; Number = "85"}; {Name = "Me"; Number = "87"}; {Name =  "Lizz"; Number = "15"}]
    readFromFile "..\\..\\..\\testBook.txt" |> should equal book

[<Test>]
let ``Test for printToFile`` () =
    let path = "..\\..\\..\\test.txt"
    let book = [{ Name = "Name"; Number = "85"}; {Name = "Me"; Number = "87"}; {Name =  "Lizz"; Number = "15"}]
    printToFile book path
    readFromFile path |> should equal book
