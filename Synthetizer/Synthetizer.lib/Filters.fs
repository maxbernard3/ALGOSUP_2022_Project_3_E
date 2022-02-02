namespace Synthetizer.lib

    open System.Numerics

    module Filters =
        open System
        open MathNet.Numerics
        open MathNet.Filtering
        open MathNet.Numerics.IntegralTransforms

        let sampleRate = GlobalVar.sampleRate

        let makeOverdrive multiplicator wave =
            let logic x =
                if x < (-1. * multiplicator) then (-1. * multiplicator) else
                if x > 1. * multiplicator then 1. * multiplicator else
                x
            wave |> Array.map(fun x -> logic x)

        let makeChord waves =
            let returnArr = Array.create (Array.get waves 0 |>   Array.length) 0.
            for i=0 to ((Array.get waves 0 |> Array.length)-1) do
                let result = Array.create (Array.length waves) 0.
    
                waves |> Array.iteri (fun j x -> Array.fill result j 1 (Array.get(Array.get waves j) i))
                Array.fill returnArr i 1 (Array.average result)
            returnArr

        // TEST Merge function
        let merge waves =
            [|
                let minLenth = waves |> Array.minBy (fun (x: float[]) -> x.Length)
                for i in 0 .. minLenth.Length - 1 do
                    for wave in waves do
                        yield wave.[i]
            |]

        let sum waves =
            let returnArr = Array.create (Array.get waves 0 |>   Array.length) 0.
            for i=0 to ((Array.get waves 0 |> Array.length)-1) do
                let result = Array.create (Array.length waves) 0.
                waves |> Array.iteri (fun j x -> Array.fill result j 1 (Array.get(Array.get waves j) i))
                Array.fill returnArr i 1 (Array.sum result)
            returnArr
        

        let reduceAmplitude (reduction:float) anyWaves =
            let reducedAmp = Array.map (fun x -> x / reduction)
            reducedAmp anyWaves

        let echo (wave:array<float>) (startEcho:float) (endEcho:float) (delay:float) (numberOfEcho:int)=
            let start= startEcho * float sampleRate |> int
            let originalSound= (endEcho - startEcho) * float sampleRate |> int
            let Delay = delay * float sampleRate |> int

            let totalOfWaves = float originalSound
    
            let startAndDelay= Array.append [|for i in 0..  start do 0.|] [|for i in 0..Delay do 0.|]
            let mutable count =1.
            let echoSound= [|
                for x in 0.. 10 do 
                for i in 0..  originalSound do  (wave.[start+i]* ( (100.-((float i/totalOfWaves)*100. ))/100.)/count ) 
                for i in 0..Delay do 0.
                count <- count+1.
                |]
                 
            let Echo: array<float> = Array.append startAndDelay echoSound
            let mutable result: array<float>= [||]
            let mutable gap: array<float>= [||]
            if(Echo.Length=wave.Length)then
                result <- makeChord[|wave;Echo|]
            else
                gap <-[|for i in 0.. wave.Length-Echo.Length do 0.|]
                let NewEcho= Array.append Echo gap
                result <- makeChord[|wave;NewEcho|]
            result

        let Superpose (waves:float[][]) (start:float[]) (lengh:float) =

            let table = Array.init 10 (fun x -> (Array.create (int(lengh*float sampleRate)) 0.0))
            let tableHeight = Array.create (int(lengh*float sampleRate)) 0
            let a = int (start.[1] * float sampleRate)
            for i=0 to (waves.Length - 1) do
                for j=0 to (waves.[i].Length - 1) do
                    if table.[0].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[0] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (1)
                    elif table.[1].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[1] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (2)
                    elif table.[2].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[2] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (3)
                    elif table.[3].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[3] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (4)
                    elif table.[4].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[4] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (5)
                    elif table.[5].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[5] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (6)
                    elif table.[6].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[6] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (7)
                    elif table.[7].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[7] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (8)
                    elif table.[8].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[8] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (9)
                    elif table.[9].[(int(start.[i]*float sampleRate)) + j] = 0. then
                        Array.set table.[9] ((int(start.[i]*float sampleRate)) + j) waves.[i].[j]
                        Array.set tableHeight ((int(start.[i]*float sampleRate)) + j) (10)

            let sum (array:float[][]) (i:int) =
                let result =
                    array.[0].[i] +
                    array.[1].[i] +
                    array.[2].[i] +
                    array.[3].[i] +
                    array.[4].[i] +
                    array.[5].[i] +
                    array.[6].[i] +
                    array.[7].[i] +
                    array.[8].[i] +
                    array.[9].[i]

                result
            
            let result = Array.create (int(lengh*float sampleRate)) 0.
            for i=0 to (table.[0].Length - 1) do
                Array.set result i ((sum table i)/float tableHeight.[i])

            result