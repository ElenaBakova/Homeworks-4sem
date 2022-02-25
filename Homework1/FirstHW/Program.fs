open System

// Counts factorial of a given number
let rec factorial number =
    if number < 0 then
        raise (ArgumentException("Number can't be negative"))

    match number with
    | 0 -> 0
    | 1 -> 1
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

let rec powerTwo n =
    let rec inner n acc =
        match n with
        | 0 -> acc
        | _ -> inner (n - 1) (acc <<< 1)

    inner n 1

// Makes list from 2^n to 2^(n+m)
let makeList n m =
    let start = powerTwo n

    let rec fillList m current list =
        match m with
        | 0 -> list
        | _ -> fillList (m - 1) (current * 2) (list @ [ current * 2 ])

    fillList m start [ start ]

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
