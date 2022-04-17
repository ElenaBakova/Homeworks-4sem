module Workflow.Tests

open NUnit.Framework
open Builders

[<TestCase(2, 0.05)>]
[<TestCase(3, 0.048)>]
[<TestCase(4, 0.0476)>]
let CounterBuilderTest (digits: int, expected) =
    let rounding x = new CounterBuilder(x)
    let result = rounding digits {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }
    Assert.AreEqual(expected, result)

[<TestCase("1", "2", 3)>]
[<TestCase("15", "2", 17)>]
[<TestCase("-1", "5", 4)>]
let StringCounterBuilderTest (a: string, b: string, expected) =
    let calculate = new StringCounterBuilder()
    let result = calculate {
        let! x = a
        let! y = b
        let z = x + y
        return z
    }
    Assert.AreEqual(expected |> Some, result)
    
[<TestCase("1", "X")>]
[<TestCase("1Y", "2")>]
[<TestCase("-1", "5.")>]
let StringCounterBuilderTest2 (a: string, b: string) =
    let calculate = new StringCounterBuilder()
    let result = calculate {
        let! x = a
        let! y = b
        let z = x + y
        return z
    }
    Assert.AreEqual(None, result)