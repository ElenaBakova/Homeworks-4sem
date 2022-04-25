module BinTree 

type Tree<'a> =
    | Empty
    | Node of 'a * Tree<'a> * Tree<'a>

let getList (binTree: Tree<'a>) condition = 
    let rec parseTree (binTree: Tree<'a>) condition acc =
        match binTree with
            | Empty -> acc
            | Node(node, left, right) ->
                let acc = if condition(node) then node :: acc else acc
                let leftAcc = parseTree left condition acc
                parseTree right condition leftAcc
    parseTree binTree condition []