module LocalNetwork.Tests

open NUnit.Framework
open LocalNetwork

[<Test>]
let Test1 () =
    let computers = [Computer(Linux, "L", Clear); Computer(Windows, "W", Infected); Computer(MacOS, "M", Clear)]
    let connections = [("W", "L"); ("W", "M")]
    let expected = [Computer(Linux, "L", Clear); Computer(Windows, "W", Infected); Computer(MacOS, "M", Infected)]
    let net = Network(computers, connections, (fun () -> 0.6))
    net.Run()
    Assert.IsTrue(expected.Equals(net.getComputers))
    
[<Test>]
let Test2 () =
    let computers = [Computer(Linux, "B", Clear); Computer(Windows, "A", Infected); Computer(MacOS, "C", Clear); Computer(MacOS, "D", Clear)]
    let connections = [("A", "B"); ("A", "C")]
    let expected = [Computer(Linux, "B", Infected); Computer(Windows, "A", Infected); Computer(MacOS, "C", Infected); Computer(MacOS, "D", Clear)]
    let net = Network(computers, connections, (fun () -> 0.1))
    net.Run()
    Assert.IsTrue(expected.Equals(net.getComputers))

[<Test>]
let ``Test when all clear`` () =
    let computers = [Computer(Linux, "B", Clear); Computer(Windows, "A", Clear); Computer(MacOS, "C", Clear); Computer(MacOS, "D", Clear)]
    let connections = [("A", "B"); ("A", "C"); ("B", "D")]
    let net = Network(computers, connections, (fun () -> 0.1))
    net.Run()
    Assert.IsTrue(computers.Equals(net.getComputers))

[<Test>]
let ``Test when all infected`` () =
    let computers = [Computer(Linux, "B", Infected); Computer(Windows, "A", Infected); Computer(MacOS, "C", Infected); Computer(MacOS, "D", Infected)]
    let connections = [("A", "B"); ("A", "C"); ("B", "D")]
    let net = Network(computers, connections, (fun () -> 0.1))
    net.Run()
    Assert.IsTrue(computers.Equals(net.getComputers))