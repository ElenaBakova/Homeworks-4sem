module TreeMap

type Tree<'a> =
    | Empty
    | Node of 'a * Tree<'a> * Tree<'a>

// Map function for a binary tree
let rec treeMap (binTree: Tree<'a>) (cont: 'a -> 'a) =
    match binTree with
        | Empty -> Empty
        | Node(node, left, right) -> Node(cont node, treeMap left cont, treeMap right cont)