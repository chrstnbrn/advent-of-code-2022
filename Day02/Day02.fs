module Day02

open System

type Shape =
    | Rock
    | Paper
    | Scissors

let parseShape =
    function
    | 'A'
    | 'X' -> Rock
    | 'B'
    | 'Y' -> Paper
    | 'C'
    | 'Z' -> Scissors
    | shape -> raise (ArgumentException($"shape {shape} is invalid"))

type Outcome =
    | Loss
    | Draw
    | Win

let parseOutcome =
    function
    | 'X' -> Loss
    | 'Y' -> Draw
    | 'Z' -> Win
    | outcome -> raise (ArgumentException($"outcome {outcome} is invalid"))

let combinations =
    [ (Rock, Rock, Draw)
      (Paper, Paper, Draw)
      (Scissors, Scissors, Draw)
      (Rock, Paper, Win)
      (Paper, Scissors, Win)
      (Scissors, Rock, Win)
      (Paper, Rock, Loss)
      (Scissors, Paper, Loss)
      (Rock, Scissors, Loss) ]

let getOutcome other me =
    combinations
    |> Seq.pick (fun (x, y, z) ->
        if (x, y) = (other, me) then
            Some z
        else
            None)

let getMyShape other outcome =
    combinations
    |> Seq.pick (fun (x, y, z) ->
        if (x, z) = (other, outcome) then
            Some y
        else
            None)

let getRoundScore myShape outcome =
    let getShapeScore =
        function
        | Rock -> 1
        | Paper -> 2
        | Scissors -> 3

    let getOutcomeScore =
        function
        | Loss -> 0
        | Draw -> 3
        | Win -> 6

    getShapeScore myShape + getOutcomeScore outcome

let solvePart1 (input: string) =
    input.Split Environment.NewLine
    |> Seq.sumBy (fun round ->
        let otherShape = parseShape round[0]
        let myShape = parseShape round[2]
        let outcome = getOutcome otherShape myShape
        getRoundScore myShape outcome)

let solvePart2 (input: string) =
    input.Split Environment.NewLine
    |> Seq.sumBy (fun round ->
        let otherShape = parseShape round[0]
        let outcome = parseOutcome round[2]
        let myShape = getMyShape otherShape outcome
        getRoundScore myShape outcome)
