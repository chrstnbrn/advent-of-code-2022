module Day08Tests

open NUnit.Framework
open Day08

[<Test>]
let ``solvePart1`` () =
    let input =
        @"30373
25512
65332
33549
35390"

    let actual = solvePart1 input
    Assert.AreEqual(21, actual)


[<Test>]
let ``solvePart2`` () =
    let input =
        @"30373
25512
65332
33549
35390"

    let actual = solvePart2 input
    Assert.AreEqual(8, actual)
