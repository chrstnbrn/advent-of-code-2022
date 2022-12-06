module Day06

let allUnique x = (Set x).Count = Seq.length x

let getMarkerPosition n =
    Seq.windowed n >> Seq.findIndex allUnique >> (+) n

let solvePart1: string -> int = getMarkerPosition 4

let solvePart2: string -> int = getMarkerPosition 14
