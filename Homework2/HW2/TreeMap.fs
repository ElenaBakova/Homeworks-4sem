module TreeMap

type Tree<'a> =
    | Empty
    | Node of 'a * Tree<'a> * Tree<'a>

// Map function for a binary tree
let rec treeMap (binTree: Tree<'a>) (continuation: 'a -> 'a) =
    match binTree with
        | Empty -> Empty
        | Node(node, left, right) -> Node(continuation node, treeMap left continuation, treeMap right continuation)