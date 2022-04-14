module BinTree 

type Tree<'a> =
    | Empty
    | Node of 'a * Tree<'a> * Tree<'a>

let getList (binTree: Tree<'a>) condition = 
    let rec parseTree (binTree: Tree<'a>) condition acc =
        match binTree with
            | Empty -> acc
            | Node(node, left, right) ->
                if (condition(node)) then
                    node :: acc @ (parseTree left condition acc)  @ (parseTree right condition acc)
                else
                    acc @ (parseTree left condition acc)  @ (parseTree right condition acc)
    parseTree binTree condition []