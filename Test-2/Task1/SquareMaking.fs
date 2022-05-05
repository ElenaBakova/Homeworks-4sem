module PrintingSquare

open System

// Makes "***" n times line
let rec makeWholeLine n index acc = 
    match index with
    | x when x = n -> acc + "\n"
    | _ -> makeWholeLine n (index + 1) (acc + "*")

// Makes "*    *" line
let rec makeLine n index acc = 
    match index with
    | 0 -> makeLine n (index + 1) (acc + "*")
    | x when x = n - 1 -> (acc + "*\n")
    | _ -> makeLine n (index + 1) (acc + " ")

// Makes square
let rec makeSquare n index acc = 
    if n < 1 then 
        raise (ArgumentException("Square size can't be less than 1"))
    match index with 
    | 0 -> (acc + makeLine n 0 (makeWholeLine n 0 "")) |> makeSquare n (index + 1)
    | x when x = n - 2 -> acc + (makeWholeLine n 0 "")
    | _ -> makeSquare n (index + 1) (acc + makeLine n 0 "")