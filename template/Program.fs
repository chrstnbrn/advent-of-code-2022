open System.IO
open DayXX

[<EntryPoint>]
let main argv =
    let input = File.ReadAllLines "./input.txt"

    let resultPart1 = solvePart1 input
    printfn "Part 1: %d" resultPart1

    let resultPart2 = solvePart2 input
    printfn "Part 2: %d" resultPart2

    0
