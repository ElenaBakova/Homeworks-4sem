
type Term =
    |Variable of string
    |Abstraction of string * Term
    |Application of Term * Term

let findNewName (usedVariables: string list) =
    let letters = List.map (fun x -> x.ToString()) [ 'A' .. 'z' ]
    let unused = List.except usedVariables letters
    List.head unused

let rec getFreeVariables term = 
    match term with
    | Variable(x) -> [x]
    | Application(term1, term2) -> List.distinct (getFreeVariables term1 @ getFreeVariables term2)
    | Abstraction(variable, term1) -> List.except (Seq.singleton variable) (getFreeVariables term1)

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
        | Abstraction(variable, term) -> Abstraction(variable, reduction(term))
        | Application(term1, term2) ->
            match term1 with
            | Abstraction(variable, term3) -> term3// подставить variable into term2
            | _ -> Application(reduction(term1), reduction(term2))
    reduction term