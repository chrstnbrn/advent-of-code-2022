module DayXXTests

open NUnit.Framework
open DayXX

[<Test>]
let ``solvePart1`` () =
    let input = [| "1" |]
    let actual = solvePart1 input
    Assert.AreEqual(0, actual)


[<Test>]
let ``solvePart2`` () =
    let input = [| "1" |]
    let actual = solvePart2 input
    Assert.AreEqual(0, actual)
