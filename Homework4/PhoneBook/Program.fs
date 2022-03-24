open System
open PhoneBookFunctions

let firstStart () = 
    printfn "What would you like to do?
    0 - exit
    1 - add record (name and phone)
    2 - find number by name
    3 - find name by number
    4 - print all records
    5 - save data to the file
    6 - read data from file"

(*let rec processing phoneBook = 
    let code = Console.ReadLine()
    (match code with
    | "0" -> ()
    | "1" -> readNameNumber |> AddRecord
    | "2" -> findNumber |> printRes) |> processing*)


firstStart()
//processing()