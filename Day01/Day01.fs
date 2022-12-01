module Day01

open System

let getGroups (input: string) =
    input.Split(Environment.NewLine + Environment.NewLine)
    |> Seq.map (fun x -> x.Split(Environment.NewLine) |> Seq.map int)

let solvePart1 = getGroups >> Seq.map Seq.sum >> Seq.max

let solvePart2 =
    getGroups
    >> Seq.map Seq.sum
    >> Seq.sortDescending
    >> Seq.take 3
    >> Seq.sum
