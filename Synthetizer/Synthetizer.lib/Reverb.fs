namespace Synthetizer.lib
module Reverb =
    open System.Collections.Generic
    open System

    let sampleRate = (GlobalVar.sampleRate)

    module Reverb = 
        let frequence = 200.
        let amplitude = 1.
        let time = 3.
        let fstWave = amplitude * sin (2. * Math.PI * time * frequence / float sampleRate)
        let reverb (wave:float[]) i = 
            let mutable sndWave = wave
            let mutable sndAmpl = amplitude
            while sndAmpl * i > 0.1 do
                sndAmpl <- sndAmpl * i
                let rep = Array.init (int time) (fun i -> sndAmpl * sin((2. * Math.PI * frequence * float i) / float sampleRate))
                let newWave = Array.concat [|sndWave; rep|]
                sndWave <- newWave
            sndWave