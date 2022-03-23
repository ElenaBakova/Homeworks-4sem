module CountEvens

// Functions for counting even numbers in the list
let countWithMap list = list |> List.map (fun x -> abs(x - 1) % 2) |> List.sum
let countWithFilter list = list |> List.filter (fun x -> x % 2 = 0) |> List.length
let countWithFold list = list |> List.fold (fun acc x -> acc + abs(x - 1) % 2) 0