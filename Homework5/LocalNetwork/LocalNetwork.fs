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

type Network(computers: Computer list, connectionsList: List<Computer * Computer>) =
    let rand = Random()

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

    member this.infectNeighbours(computer: Computer) =
        connectionsList
        |> List.iter
            (fun (first: Computer, second: Computer) ->
                if first.Id = computer.Id then
                    this.infectComputer second

                if second.Id = computer.Id then
                    this.infectComputer first)

    member this.infectComputer(computer: Computer) =
        if this.willInfect computer
           && computer.IsInfected = Clear then
            computer.IsInfected <- AtThisTurn
            this.InfectedComputers <- this.InfectedComputers + 1

    member this.nextStep() =
        List.iter
            (fun (pc: Computer) ->
                if pc.IsInfected = AtThisTurn then
                    pc.IsInfected <- NotClear)
            computers

        List.iter
            (fun (pc: Computer) ->
                if pc.IsInfected = NotClear
                   && pc.IsInfected <> NotClear then
                    this.infectNeighbours pc)
            computers
