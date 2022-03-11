open TreeMap
open CountEvens
open ExpressionTree
open InfinitySequence
open NUnit.Framework
open FsCheck
open FsUnit

[<Test>]
let ``Functions should be equal`` () =
    let intGenerator = Arb.generate<int>
    let list = intGenerator |> Gen.sample 1000 100
    countWithMap list |> should equal (countWithFold list)
    countWithFold list |> should equal (countWithFilter list)
    
[<Test>]
let ``Tree map testing`` () =
    let tree = Node(3, Node(6, Node(8, Tree.Empty, Tree.Empty), Tree.Empty), Node(9, Tree.Empty, Tree.Empty))
    let expected = Node(9, Node (36, Node (64, Tree.Empty, Tree.Empty), Tree.Empty), Node(81, Tree.Empty, Tree.Empty))
    treeMap tree (fun x -> x * x) |> should equal expected

[<Test>]
let ``Evaluation of expression tree testing`` () =
    let tree = Summation(Multiplication(Number 5, Subtraction(Number 6, Number 7)), Division(Summation(Number 6, Number 8), Number 10))
    let expected = -4
    evaluate tree |> should equal expected
    
[<Test>]
let ``Infinite prime numbers sequence test`` () =
    let sequence = seqence()
    let expected = [2; 3; 5; 7; 11; 13; 17]
    Seq.take 7 sequence |> should equal expected