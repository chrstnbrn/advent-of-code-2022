open System.IO
open Day05

[<EntryPoint>]
let main argv =
    let input = File.ReadAllText "./input.txt"

    let resultPart1 = solvePart1 input
    printfn "Part 1: %s" resultPart1

    let resultPart2 = solvePart2 input
    printfn "Part 2: %s" resultPart2

    0
