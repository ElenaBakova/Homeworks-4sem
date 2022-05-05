module SquareTests

open NUnit.Framework
open System
open PrintingSquare

[<Test>]
let Test1 () =
    let expected = "****\n*  *\n*  *\n****\n"
    let str = makeSquare 4 0 ""
    Assert.AreEqual(expected, str)
    
[<Test>]
let Test2 () =
    Assert.Throws<ArgumentException>(fun () -> (makeSquare 0 0 "") |> ignore) |> ignore