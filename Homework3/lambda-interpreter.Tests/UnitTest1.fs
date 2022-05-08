module lambda_interpreter.Tests
open LambdaInterpreter

open NUnit.Framework
open FsUnit

[<Test>]
let Test1 () =
    let expression = Application(Abstraction("x", Variable "y"), Variable("a"))
    betaReduction expression |> should equal (Variable "y")
    
[<Test>]
let Test2 () =
    let expression = Application(Abstraction("x", Variable "x"), Variable("a"))
    betaReduction expression |> should equal (Variable "a")

[<Test>]
let Test3 () =
    let expression = Application(Abstraction("x", Variable "x"), Abstraction("y", Abstraction("z", Variable "z")))
    betaReduction expression |> should equal (Abstraction ("y", Abstraction ("z", Variable "z")))
    
[<Test>]
let Test4 () =
    let expression = Application(Abstraction("x", Application(Variable "x", Variable "x")), Abstraction("x", Application(Variable "x", Variable "x")))
    betaReduction expression |> should equal expression
    
[<Test>]
let ``Substitution with changing name`` () =
    let expression = Application(Abstraction("x", Abstraction("y", Variable "x")), Variable "y")
    betaReduction expression |> should equal (Abstraction ("A", Variable "y"))
