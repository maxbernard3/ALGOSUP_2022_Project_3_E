namespace Synthetizer.lib

    module Filters =
        open System

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

        let reduceAmplitude (reduction:float) anyWaves =
            let reducedAmp = Array.map (fun x -> x / reduction)
            reducedAmp anyWaves

        let echo (wave:array<float>) (startEcho:float) (endEcho:float) (delay:float) (numberOfEcho:int) (decay:float)=
            let start= startEcho * float sampleRate |> int
            let originalSound= (endEcho - startEcho) * float sampleRate |> int
            let Delay = delay * float sampleRate |> int

    
            let startAndDelay= Array.append [|for i in 0..  start do 0.|] [|for i in 0..Delay do 0.|]
            let mutable count =1.
            let echoSound= [|
                for x in 0.. numberOfEcho do 
                    for i in 0..  int (float originalSound* decay) do  (wave.[start+i]* ( (100.-(((float i)/(float originalSound*decay))*100. ))/100.)/count ) 
                    for i in 0..Delay do 0.
                    count <- count+1.
                |]
                 
            let Echo: array<float> = Array.append startAndDelay echoSound
            let mutable result: array<float>= [||]
            if(Echo.Length=wave.Length) then
                result <- makeChord[|wave;Echo|]
            else 
                let gap =[|for i in 0.. wave.Length-Echo.Length do 0.|]
                let NewEcho= Array.append Echo gap
                result <- makeChord[|wave;NewEcho|]
           
            result


        let frequence = 200.
        let amplitude = 1.
        let time = 2.85* float sampleRate
        let fstWave = amplitude * sin (2. * Math.PI  * time * frequence / float sampleRate)
        let reverb (wave:float[]) (i:float) = 
                let mutable sndWave = wave
                let mutable sndAmpl = amplitude
                while sndAmpl * i > 0.1 do
                    sndAmpl <- sndAmpl-0.01
                    let rep = Array.init (int time) (fun i -> sndAmpl * sin((2. * Math.PI * frequence * float i) / float sampleRate))
                    let newWave =Array.concat[|rep|]
                    sndWave <- newWave
                sndWave
            