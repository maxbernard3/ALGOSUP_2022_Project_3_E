namespace Synthetizer.lib
    module Envelope =
        open System.Collections.Generic

        let sampleRate = (GlobalVar.sampleRate)
    
        let envelope (wave:float[]) (attackVar:float) (decayVar:float) (sustainVar:float) (releaseVar:float) (hold:float)=
            let waveBuffer = List<float>()
            for i=0 to (int (attackVar * float sampleRate)) do
                waveBuffer.Add(wave.[i] * (float i / (attackVar * float sampleRate)))

            for i=(int (attackVar* float sampleRate)) to (int ((attackVar + decayVar)* float sampleRate) - 1) do
                waveBuffer.Add(wave.[i] * (hold + ((float i)*(1. - hold)) / (attackVar * float sampleRate)))

            for i=(int ((attackVar + decayVar)* float sampleRate)) to (int ((attackVar + decayVar + sustainVar)* float sampleRate) - 1) do
                waveBuffer.Add(wave.[i] * hold)

            for i=(int ((attackVar + decayVar + sustainVar)* float sampleRate)) to (int ((attackVar + decayVar + sustainVar + releaseVar)* float sampleRate) - 1) do
                waveBuffer.Add(wave.[i] * ((1. - hold) + ((float i)*(hold) / (attackVar * float sampleRate))))

            waveBuffer.ToArray()