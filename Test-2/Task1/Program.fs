open System
open PrintingSquare

let printSquare n = 
    if n < 1 then 
        raise (ArgumentException("Square size can't be less than 1"))
    let str = (makeSquare n 0 "")
    printf "%s" str

printSquare 4