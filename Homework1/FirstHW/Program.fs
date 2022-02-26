open System

// Counts factorial of a given number
let rec factorial number =
    if number < 0 then
        raise (ArgumentException("Number can't be negative"))

    match number with
    | 0 | 1 -> 1
    | _ -> number * factorial (number - 1)

// Counts fibonacci number
let fibonacci number =
    if number < 0 then
        raise (ArgumentException("Number can't be negative"))

    let rec fibonacciCount first second number =
        if number = 0 then
            first
        else
            fibonacciCount second (first + second) (number - 1)

    fibonacciCount 0 1 number

// Reverses list
let listReverse list =
    let rec composeList list listTail =
        match listTail with
        | [] -> list
        | element :: rest -> composeList (element :: list) rest

    composeList [] list

// Makes list from 2^n to 2^(n+m)
let makeList n m =
    let start = pown 2 n

    let rec fillList m current list =
        match m with
        | 0 -> list
        | _ -> fillList (m - 1) (current * 2) (current * 2 :: list)

    fillList m start [start] |> listReverse 

// Finds element in the list
let findInList list number =
    let rec find list number position =
        match list with
        | [] -> raise (Exception("Couldn't find element in the list"))
        | x :: rest ->
            if x = number then
                position
            else
                find rest number (position + 1)

    find list number 0
