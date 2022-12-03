module Day02Tests

open NUnit.Framework
open Day02

[<Test>]
let ``solvePart1`` () =
    let input =
        @"A Y
B X
C Z"

    let actual = solvePart1 input
    Assert.AreEqual(15, actual)


[<Test>]
let ``solvePart2`` () =
    let input =
        @"A Y
B X
C Z"

    let actual = solvePart2 input
    Assert.AreEqual(12, actual)
