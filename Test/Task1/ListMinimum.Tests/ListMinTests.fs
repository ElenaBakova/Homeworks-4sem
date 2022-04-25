module ListMinimum.Tests

open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``Get minimum in int list`` () =
    let intGenerator = Arb.generate<int>
    let list = intGenerator |> Gen.sample 1000 100
    let expected = List.min list
    findMin list |> should equal expected

[<Test>]
let ``Get minimum in string list`` () =
    let stringGenerator = Arb.generate<string>
    let list = stringGenerator |> Gen.sample 10 1000
    let expected = List.min list
    findMin list |> should equal expected

[<Test>]
let ``Get minimum in empty list`` () =
    let list = []
    Assert.Throws<System.ArgumentException>(fun () -> findMin list |> ignore) |> ignore