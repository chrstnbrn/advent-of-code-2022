module Day05Tests

open NUnit.Framework
open Day05

[<Test>]
let ``solvePart1`` () =
    let input =
        @"    [D]
[N] [C]
[Z] [M] [P]
 1   2   3

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2"

    let actual = solvePart1 input
    Assert.AreEqual("CMZ", actual)


[<Test>]
let ``solvePart2`` () =
    let input =
        @"    [D]
[N] [C]
[Z] [M] [P]
 1   2   3

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2"

    let actual = solvePart2 input
    Assert.AreEqual("MCD", actual)
