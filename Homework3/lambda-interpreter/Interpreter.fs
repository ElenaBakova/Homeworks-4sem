module LambdaInterpreter

let letters = List.map (fun x -> x.ToString()) [ 'A' .. 'z' ]

// Lambda-term
type Term =
    |Variable of string
    |Abstraction of string * Term
    |Application of Term * Term

// Finds new name for a variable
let findNewName (usedVariables: string list) =
    let unused = List.except usedVariables letters
    List.head unused

// Returns list of free variables
let rec getFreeVariables term = 
    match term with
    | Variable(x) -> [x]
    | Application(term1, term2) -> List.distinct (getFreeVariables term1 @ getFreeVariables term2)
    | Abstraction(variable, term1) -> List.except (Seq.singleton variable) (getFreeVariables term1)

// Substitutes newTerm to the term
let rec substitution variable term newTerm = 
    match (term, newTerm) with
    | (Application(left, right), _) -> Application(substitution variable left newTerm, substitution variable right newTerm)
    | (Variable(x), _) when x = variable -> newTerm
    | (Variable(_), _) -> term
    | (Abstraction(var, currentTerm), Variable(_)) when var = variable -> Abstraction(var, currentTerm)
    | (Abstraction(var, currentTerm), _) ->
        let newTermFV = getFreeVariables newTerm
        let currentTermFV = getFreeVariables currentTerm
        if (not (List.contains var newTermFV) || not (List.contains variable currentTermFV)) then
            Abstraction(var, substitution variable currentTerm newTerm)
        else 
            let newName = findNewName (newTermFV @ currentTermFV)
            let newVar = substitution var currentTerm (Variable newName)
            let substitutedTerm = substitution variable newVar newTerm
            Abstraction(newName, substitutedTerm)

let betaReduction term = 
    let rec reduction term=
        match term with
        | Variable(var) -> Variable(var)
        | Application(Abstraction(variable, term2), term) -> substitution variable term2 term
        | Application(term1, term2) ->
            let countedTerm1 = reduction term1
            match countedTerm1 with
            | Abstraction(variable, term3) -> reduction(substitution variable term3 term2)
            | _ -> Application(countedTerm1, reduction(term2))
        | Abstraction(variable, term) -> Abstraction(variable, reduction(term))
    reduction term