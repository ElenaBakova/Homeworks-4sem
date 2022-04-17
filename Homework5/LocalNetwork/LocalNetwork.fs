module LocalNetwork

type OS =
    | Windows
    | MacOS
    | Linux

type Infected =
    | Clear
    | Now
    | NotNow

type Computer (operatingSystem: OS, computerID: string, isInfected: Infected) =
    member this.os = operatingSystem
    member this.id = computerID
    member val IsInfected = isInfected