module Day03

open System

let getCompartments (content: string) =
    let middle = content.Length / 2 - 1

    [ content[..middle]
      content[middle + 1 ..] ]

let getCommonItem: seq<string> -> char =
    Seq.map Set >> Set.intersectMany >> Seq.head

let getScore ch =
    if ch >= 'a' then
        int ch - int 'a' + 1
    else
        int ch - int 'A' + 27

let solvePart1 (input: string) =
    input.Split Environment.NewLine
    |> Seq.map getCompartments
    |> Seq.map getCommonItem
    |> Seq.sumBy getScore

let solvePart2 (input: string) =
    input.Split Environment.NewLine
    |> Seq.chunkBySize 3
    |> Seq.map getCommonItem
    |> Seq.sumBy getScore
