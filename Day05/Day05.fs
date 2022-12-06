module Day05

open System

let getLines (text: string) : string array = text.Split Environment.NewLine

let toArray2D (text: string) : char [,] =
    let lines = getLines text
    let maxColumns = lines |> Seq.map String.length |> Seq.max

    Array2D.init lines.Length maxColumns (fun i j ->
        lines[i]
        |> Seq.tryItem j
        |> Option.defaultValue ' ')

let column (arr: 'T [,]) i =
    arr.[*, i..i] |> Seq.cast<'T> |> Seq.toArray

let columns (arr: 'T [,]) =
    [ 0 .. arr.GetLength(1) - 1 ]
    |> Seq.map (column arr)

type Stacks = Map<int, char list>

let parseStack column =
    (column |> Array.last |> string |> int,
     column
     |> Array.take (column.Length - 1)
     |> Array.filter ((<>) ' ')
     |> Array.toList)

let parseStacks (input: string) : Stacks =
    input
    |> toArray2D
    |> columns
    |> Seq.chunkBySize 4
    |> Seq.map (Seq.item 1 >> parseStack)
    |> Map.ofSeq

type Instruction = { Count: int; From: int; To: int }

let parseInstruction (input: string) : Instruction =
    let words = input.Split ' '

    { Count = int words[1]
      From = int words[3]
      To = int words[5] }

let parseInstructions = getLines >> Seq.map parseInstruction

let parse (input: string) =
    let parts = input.Split(Environment.NewLine + Environment.NewLine)
    (parseStacks parts[0], parseInstructions parts[1])

let rearrangeWith9000 (stacks: Stacks) (instruction: Instruction) =
    let (toMove, newFrom) = List.splitAt instruction.Count stacks[instruction.From]
    let newTo = (List.rev toMove) @ stacks[instruction.To]

    stacks
    |> Map.add instruction.From newFrom
    |> Map.add instruction.To newTo

let rearrangeWith9001 (stacks: Stacks) (instruction: Instruction) =
    let (toMove, newFrom) = List.splitAt instruction.Count stacks[instruction.From]
    let newTo = toMove @ stacks[instruction.To]

    stacks
    |> Map.add instruction.From newFrom
    |> Map.add instruction.To newTo

let getTopCrates = Map.values >> Seq.map Seq.head >> Seq.toArray

let solvePart1 input =
    let (initialStacks, instructions) = parse input

    instructions
    |> Seq.fold rearrangeWith9000 initialStacks
    |> getTopCrates
    |> String

let solvePart2 input =
    let (initialStacks, instructions) = parse input

    instructions
    |> Seq.fold rearrangeWith9001 initialStacks
    |> getTopCrates
    |> String
