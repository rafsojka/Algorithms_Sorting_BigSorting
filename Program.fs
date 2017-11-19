// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System

[<EntryPoint>]
let main argv = 
    let n = Console.ReadLine() |> Int32.Parse
    let arr = Array.create n ""
    for i in 0..n-1 do
        arr.[i] <- Console.ReadLine()

    let sorted_arr = 
        arr 
        // 1. groupBy lengths
        |> Seq.groupBy (fun s -> s.Length) 
        // 2. sortBy lengths
        |> Seq.sortBy (fun (k,_) -> k)
        //  3. within the same lengths sort strings alphabetically
        |> Seq.map (fun (_,s) -> Seq.sort s) 
        // 4. flatten into single array
        |> Seq.concat

    sorted_arr |> Seq.iter (fun i -> printfn "%s" i)

    0 // return an integer exit code
