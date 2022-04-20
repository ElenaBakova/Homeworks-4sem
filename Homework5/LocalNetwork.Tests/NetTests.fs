module LocalNetwork.Tests

open NUnit.Framework
open LocalNetwork
open Foq

[<Test>]
let Test1 () =
    let rand = Mock<System.Random>().Setup(fun x -> <@ x.NextDouble() @>).Returns(0.6).Create()
    let computers = [Computer(Linux, "L", Clear); Computer(Windows, "W", NotClear); Computer(MacOS, "M", Clear)]
    let connections = [("W", "L"); ("W", "M")]
    let net = Network(computers, connections, rand)
    net.Run()
    Assert.AreEqual(2, net.InfectedComputers)
    
[<Test>]
let Test2 () =
    let rand = Mock<System.Random>().Setup(fun x -> <@ x.NextDouble() @>).Returns(0.1).Create()
    let computers = [Computer(Linux, "B", Clear); Computer(Windows, "A", NotClear); Computer(MacOS, "C", Clear); Computer(MacOS, "D", Clear)]
    let connections = [("A", "B"); ("A", "C")]
    let net = Network(computers, connections, rand)
    net.Run()
    Assert.AreEqual(3, net.InfectedComputers)
