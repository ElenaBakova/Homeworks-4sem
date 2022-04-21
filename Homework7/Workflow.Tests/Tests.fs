module Workflow.Tests

open NUnit.Framework
open Builders

[<Test>]
let RoundBuilderTest () =
    let rounding x = new RounderBuilder(x)
    let result = rounding 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    Assert.AreEqual(0.048, result)

[<Test>]
let RoundBuilderTest2 () =
    let rounding x = new RounderBuilder(x)
    Assert.Throws<System.ArgumentOutOfRangeException>(fun () ->
        rounding -3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        } |> ignore) |> ignore

[<Test>]
let StringCalculatorBuilderTest () =
    let calculate = new StringCalculatorBuilder()
    let result = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return "3"
    }
    Assert.AreEqual(Some("3"), result)
    
[<Test>]
let StringCalculatorBuilderTest2 () =
    let calculate = new StringCalculatorBuilder()
    let result = calculate {
        let! x = "1"
        let! y = "X"
        let z = x + y
        return z
    }
    Assert.AreEqual(None, result)