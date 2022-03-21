module InfinitySequence

let primeCheck number =
    number <> 1 && seq {2 .. int(sqrt(float number))} |> Seq.forall (fun x -> number % x <> 0)

let sequence() = Seq.initInfinite(fun x -> x + 2) |> Seq.filter (fun x -> primeCheck x)