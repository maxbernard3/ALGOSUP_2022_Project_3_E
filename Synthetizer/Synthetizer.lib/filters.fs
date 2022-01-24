namespace Synthetizer.lib

namespace Synth
module filters =
    open System
    open System.IO
    open System.Threading
    let sampleRate = 44100 // In Hertz

    let makeChord waves =
        let returnArr = Array.create (Array.get waves 0 |>   Array.length) 0.
        for i=0 to ((Array.get waves 0 |> Array.length)-1) do
            let result = Array.create (Array.length waves) 0.
    
            waves |> Array.iteri (fun j x -> Array.fill result j 1 (Array.get     (Array.get waves j) i))
            Array.fill returnArr i 1 (Array.average result)
        returnArr

    
    let fusedData fullwave = 
        fullwave |> Array.concat

    let makeOverdrive multiplicator x =
        if x < (-1. * multiplicator) then (-1. * multiplicator) else
        if x > 1. * multiplicator then 1. * multiplicator else
        x

    let echo (wave:array<float>) (startEcho:float) (endEcho:float) (delay:float) (numberOfEcho:int)=
            let start= startEcho * float sampleRate |> int
            let originalSound= (endEcho - startEcho) * float sampleRate |> int
            let Delay = delay * float sampleRate |> int

            let totalOfWaves= float originalSound
           
            let startAndDelay= Array.append [|for i in 0..  start do 0.|] [|for i in 0..Delay do 0.|]
            let mutable count =1.
            let echoSound= [|
                for x in 0.. numberOfEcho do 
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
