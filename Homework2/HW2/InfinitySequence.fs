module InfinitySequence

let primeCheck number =
    number <> 1 && seq {2 .. int(sqrt(float number))} |> Seq.exists (fun x -> number % x = 0) |> not

let seqence() = Seq.initInfinite(fun x -> x + 2) |> Seq.choose (fun x -> if primeCheck x then Some x else None)