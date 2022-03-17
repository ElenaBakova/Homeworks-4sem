
type Term =
    |Variable of string
    |Abstraction of string * Term
    |Application of Term * Term

let betaReduction term = 
    let rec reduction term=
        match term with
        | Variable(var) -> Variable(var)
        | Abstraction(variable, term) -> Abstraction(variable, reduction(term))
        | Application(term1, term2) ->
            match term1 with
            | Abstraction(variable, term3) -> term3// подставить variable into term2
            | _ -> Application(reduction(term1), reduction(term2))
    reduction term