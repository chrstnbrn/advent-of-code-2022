module Day07

open System

let (|CdCommand|_|) (text: string) =
    if text.StartsWith("$ cd ") then
        Some text[5..]
    else
        None

let tryParseInt s =
    try
        s |> int |> Some
    with
    | :? FormatException -> None

let (|File|_|) (text: string) =
    text.Split(' ')
    |> Array.tryItem 0
    |> Option.bind tryParseInt

let changeDirectory (path: string) =
    function
    | "/" -> "/"
    | ".." -> path[.. (path.LastIndexOf "/") - 1]
    | dir -> path + "/" + dir

let addSizeToParentDirectories size (currentPath: string) =
    Map.change currentPath (Option.map ((+) size) >> Option.orElse (Some size))
    >> Map.map (fun path currentSize ->
        if currentPath.StartsWith(path + "/") then
            currentSize + size
        else
            currentSize)

let processLine (currentPath: string, directorySizeMap: Map<string, int>) =
    function
    | CdCommand dir -> changeDirectory currentPath dir, directorySizeMap
    | File size -> currentPath, addSizeToParentDirectories size currentPath directorySizeMap
    | _ -> currentPath, directorySizeMap

let getDirectorySizeMap (input: string) =
    input.Split Environment.NewLine
    |> Seq.fold processLine ("/", Map.empty)
    |> snd

let solvePart1 input =
    input
    |> getDirectorySizeMap
    |> Map.values
    |> Seq.filter (fun x -> x <= 100_000)
    |> Seq.sum

let solvePart2 input =
    let directorySizeMap = input |> getDirectorySizeMap
    let usedSpace = directorySizeMap["/"]
    let freeSpace = 70000000 - usedSpace
    let requiredSpace = 30000000 - freeSpace

    directorySizeMap
    |> Map.values
    |> Seq.filter (fun x -> x >= requiredSpace)
    |> Seq.min
