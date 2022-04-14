module BinTree.Tests

open NUnit.Framework
open FsUnit

[<Test>]
let ``Get only even nodes`` () =
    let tree = Node(3, Node(6, Node(8, Tree.Empty, Tree.Empty), Tree.Empty), Node(9, Tree.Empty, Tree.Empty))
    let expected = [6; 8]
    getList tree (fun x -> x % 2 = 0) |> should equal expected

[<Test>]
let ``Get nodes greater than 5`` () =
    let tree = Node(3, Node(6, Node(8, Tree.Empty, Tree.Empty), Tree.Empty), Node(9, Node(10, Node(18, Tree.Empty, Tree.Empty), Tree.Empty), Tree.Empty))
    let expected = [6; 8; 9; 10; 18]
    getList tree (fun x -> x > 5) |> should equal expected

[<Test>]
let ``Get nodes containing letter a`` () =
    let tree = Node("aba", Node("caba", Node("db", Tree.Empty, Tree.Empty), Tree.Empty), Node("bc", Tree.Empty, Tree.Empty))
    let expected = ["aba"; "caba"]
    getList tree (fun x -> x.Contains('a')) |> should equal expected
