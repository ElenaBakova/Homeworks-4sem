module ExpressionTree

type Expression =
    | Number of int
    | Summation of Expression * Expression
    | Subtraction of Expression * Expression
    | Multiplication of Expression * Expression
    | Division of Expression * Expression

// Evaluates expression tree
let rec evaluate (expression: Expression) =
    match expression with
        | Number number -> number
        | Summation(left, right) -> (evaluate left) + (evaluate right)
        | Subtraction(left, right) -> (evaluate left) - (evaluate right)
        | Multiplication(left, right) -> (evaluate left) * (evaluate right)
        | Division(left, right) -> (evaluate left) / (evaluate right)