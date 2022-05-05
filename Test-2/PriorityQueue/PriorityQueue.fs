module PriorityQueue

type PriorityQueue<'a> (n)= 
    let queue: 'a array = Array.zeroCreate(n)
    let size() = queue.Length
    
    member _.IsEmpty with get() = size() = 0

