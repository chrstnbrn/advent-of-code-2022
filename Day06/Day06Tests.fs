module Day06Tests

open NUnit.Framework
open Day06

[<Test>]
let ``solvePart1`` () =
    let input = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb"

    let actual = solvePart1 input
    Assert.AreEqual(7, actual)


[<Test>]
let ``solvePart2`` () =
    let input = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb"

    let actual = solvePart2 input
    Assert.AreEqual(19, actual)
