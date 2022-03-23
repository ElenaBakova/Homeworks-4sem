module Point_free.Tests

open NUnit.Framework
open Functions
open FsUnit
open FsCheck

[<Test>]
let ``Check whether myFunction is correct`` () =
    let answerList = [2; 4; 8; 16; 32]
    let list = [1; 2; 4; 8; 16]
    myFunction 2 list |> should equal answerList

[<Test>]
let ``Point-free and myFunction equality check`` () =
    let myFunction6 = List.map << (*)
    let intGenerator = Arb.generate<int>
    let list = intGenerator |> Gen.sample 1000 100
    myFunction 5 list |> should equal (myFunction6 5 list)