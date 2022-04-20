module LocalNetwork

open System

type OS =
    | Windows
    | MacOS
    | Linux

type Infected =
    | Clear
    | AtThisTurn
    | NotClear

type Computer(operatingSystem: OS, computerID: string, isInfected: Infected) =
    member _.Os = operatingSystem
    member _.Id = computerID
    member val IsInfected = isInfected with get, set

    member val InfectionChance =
        match operatingSystem with
        | Windows -> 0.9
        | Linux -> 0.5
        | MacOS -> 0.7

type Network(computers: Computer list, connectionsList, rand: Random) =
    let computersCount = computers.Length
    let mutable changedThisStep = false

    member val InfectedComputers =
        List.fold
            (fun infectedCount (pc: Computer) ->
                if pc.IsInfected = Clear then
                    infectedCount
                else
                    infectedCount + 1)
            0
            computers with get, set

    member this.willInfect(computer: Computer) =
        computer.InfectionChance > rand.NextDouble()
        
    member this.IsClear(pcID: string) =
        let computer = computers |> List.find (fun pc -> pc.Id = pcID)
        computer.IsInfected = Clear

    member this.infectNeighbours(computer: Computer) =
        connectionsList
        |> List.iter (fun pair ->
            if fst(pair) = computer.Id && this.IsClear(snd(pair)) then
                this.infectComputer (snd pair)

            if snd(pair) = computer.Id && this.IsClear(fst(pair)) then
                this.infectComputer (fst pair))

    member this.infectComputer(pcID) =
        let computer = computers |> List.find (fun pc -> pc.Id = pcID)
        if this.willInfect computer
           && computer.IsInfected = Clear then
            computer.IsInfected <- AtThisTurn
            this.InfectedComputers <- this.InfectedComputers + 1
            changedThisStep <- true

    member this.nextStep() =
        List.iter
            (fun (pc: Computer) ->
                if pc.IsInfected = AtThisTurn then
                    pc.IsInfected <- NotClear)
            computers

        List.iter
            (fun (pc: Computer) ->
                if pc.IsInfected = NotClear then
                    this.infectNeighbours pc)
            computers

    member this.Run() =
        match this.InfectedComputers with
        | 0 -> printfn "No infected computers"
        | x when x = computersCount -> printfn $"All of {x} computers are infected"
        | x when x > 0 && x < computersCount ->
            changedThisStep <- false
            printfn $"{this.InfectedComputers} computers are infected"
            this.nextStep ()
            if (not changedThisStep) then
                printfn ""
            else
                this.Run()
        | _ -> printfn ""