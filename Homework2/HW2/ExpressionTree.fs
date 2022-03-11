module ExpressionTree

type Proposition =
    | Number of int
    | Summation of Proposition * Proposition
    | Subtraction of Proposition * Proposition
    | Multiplication of Proposition * Proposition
    | Division of Proposition * Proposition

// Evaluates expression tree
let rec evaluate (p: Proposition) =
    match p with
        | Number n -> n
        | Summation(p1, p2) -> (evaluate p1) + (evaluate p2)
        | Subtraction(p1, p2) -> (evaluate p1) - (evaluate p2)
        | Multiplication(p1, p2) -> (evaluate p1) * (evaluate p2)
        | Division(p1, p2) -> (evaluate p1) / (evaluate p2)