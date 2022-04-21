module Builders

open System

/// Workflow for couting with given accuracy 
type RounderBuilder (digits: int) =
    member this.Bind(x, func) = func x
    member this.Return(x: float) = Math.Round(x, digits)

/// Workflow for couting with numbers given as a string
type StringCalculatorBuilder () =
    member this.Bind(x: string, func) = 
        try 
            x |> int |> func
        with :? FormatException
            -> None
    member this.Return(x) = x |> Some