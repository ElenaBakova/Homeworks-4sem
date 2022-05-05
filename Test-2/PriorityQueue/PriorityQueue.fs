module PriorityQueue

open System

type PriorityQueue<'a when 'a :> IComparable> (n)= 
    let mutable queue: ('a * int) list = []
    let size() = queue.Length

    let rec enqueueElement (value: 'a) (priority: int) list =
        match list with
        | [] -> [(value, priority)]
        | ((head: (#IComparable * int)))::tail -> 
            if head.Item2 <= priority then
                head :: [(value, priority)] @ tail
            else 
                head :: (enqueueElement value priority tail)

    let enqueue (value: 'a) priority = 
        queue <- (enqueueElement value priority queue)

    //let dequeueElement list =

    let dequeue() = 
        if size() = 0 then
            raise (InvalidOperationException("Can't dequeue from empty queue"))
        //dequeueElement queue

    member _.IsEmpty with get() = size() = 0