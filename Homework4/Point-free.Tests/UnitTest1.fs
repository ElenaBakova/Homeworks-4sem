module Point_free.Tests

open NUnit.Framework
open Functions
open FsCheck

[<Test>]
let ``Point-free and myFunction equality check`` () =
    let check param list = myFunction param list = myFunction5 param list
    Check.QuickThrowOnFailure check