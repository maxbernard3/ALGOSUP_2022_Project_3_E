namespace Synth
    module Echo =
        open System
        open System.IO
        open SFML.Audio
        open System.Threading

        let echo (wave:array<float>) (startEcho:float) (endEcho:float) (delay:float) (numberOfEcho:int)=
                let start= startEcho * float Waveform.sampleRate |> int
                let originalSound= (endEcho - startEcho) * float Waveform.sampleRate |> int
                let Delay = delay * float Waveform.sampleRate |> int

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
                    result <- Waveform.makeChord[|wave;Echo|]
                else
                    gap <-[|for i in 0.. wave.Length-Echo.Length do 0.|]
                    let NewEcho= Array.append Echo gap
                    result <- Waveform.makeChord[|wave;NewEcho|]
                result