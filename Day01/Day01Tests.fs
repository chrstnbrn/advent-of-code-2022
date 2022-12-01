module Day01Tests

open NUnit.Framework
open Day01

[<Test>]
let ``solvePart1`` () =
    let input: string =
        @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000"

    let actual = solvePart1 input
    Assert.AreEqual(24000, actual)


[<Test>]
let ``solvePart2`` () =
    let input =
        @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000"

    let actual = solvePart2 input
    Assert.AreEqual(45000, actual)
