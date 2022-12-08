module Day08

open System

let toArray2D (text: string) : char [,] =
    let lines = text.Split Environment.NewLine
    let maxColumns = lines |> Seq.map String.length |> Seq.max

    Array2D.init lines.Length maxColumns (fun i j ->
        lines[i]
        |> Seq.tryItem j
        |> Option.defaultValue ' ')

let getIndexes =
    Array2D.mapi (fun i j _ -> (i, j))
    >> Seq.cast<int * int>

let parseMap =
    toArray2D
    >> Array2D.map (Char.GetNumericValue >> int)

let getTreesInAllDirections (map: int [,]) (i, j) =
    let left = map[i, .. j - 1] |> Array.rev
    let right = map[i, j + 1 ..]
    let top = map[.. i - 1, j] |> Array.rev
    let bottom = map[i + 1 .., j]
    [| left; right; top; bottom |]

let getVisibleTrees (map: int [,]) =
    let isVisible (i, j) =
        getTreesInAllDirections map (i, j)
        |> Seq.exists (Seq.forall (fun x -> x < map[i, j]))

    map |> getIndexes |> Seq.filter isVisible

let getScenicScores (map: int [,]) =
    let getScenicScore i j _ =
        let getVisibleTreeCount trees =
            trees
            |> Array.tryFindIndex (fun x -> x >= map[i, j])
            |> Option.map ((+) 1)
            |> Option.defaultValue trees.Length

        getTreesInAllDirections map (i, j)
        |> Seq.map getVisibleTreeCount
        |> Seq.reduce (*)

    map |> Array2D.mapi getScenicScore

let solvePart1 = parseMap >> getVisibleTrees >> Seq.length

let solvePart2 =
    parseMap
    >> getScenicScores
    >> Seq.cast<int>
    >> Seq.max
