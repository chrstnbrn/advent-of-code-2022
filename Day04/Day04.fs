module Day04

open System

let parse (input: string) =
    let values = input.Split('-', ',') |> Array.map int
    ((values[0], values[1]), (values[2], values[3]))

let fullyContains ((a1, a2), (b1, b2)) =
    a1 <= b1 && a2 >= b2 || b1 <= a1 && b2 >= a2

let hasOverlap ((a1, a2), (b1, b2)) = a1 <= b2 && a2 >= b1

let solvePart1 (input: string) =
    input.Split Environment.NewLine
    |> Seq.map parse
    |> Seq.filter fullyContains
    |> Seq.length

let solvePart2 (input: string) =
    input.Split Environment.NewLine
    |> Seq.map parse
    |> Seq.filter hasOverlap
    |> Seq.length
