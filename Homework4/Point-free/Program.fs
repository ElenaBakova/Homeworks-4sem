﻿module Functions

let myFunction x l = List.map (fun y -> y * x) l

let myFunction2 x = List.map (fun y -> y * x)

let myFunction3 x = List.map ((*) x)

let myFunction4 x = List.map << (*) << x

let myFunction5 = List.map << (*)

printfn "%A" (myFunction5 2 [1; 2; 4; 8; 5; 8])