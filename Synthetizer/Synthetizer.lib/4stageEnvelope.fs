namespace Synthetizer.lib
    module Envelope =
        open System.Collections.Generic

        let sampleRate = (GlobalVar.sampleRate)
    
        let envelope (wave:float[]) (attackVar:float) (decayVar:float) (sustainVar:float) (releaseVar:float) (hold:float)=

            let attack = new List<float>()
            for i=0 to (int (attackVar * float sampleRate)) do
                attack.Add (wave.[i] * (-1.)*(float i / (attackVar * float sampleRate)))

            let decay = Array.create (int (float sampleRate * decayVar)) 0.
            for i=(int(decayVar*float sampleRate) - 1) downto 1 do
                Array.set decay (int (float sampleRate * decayVar) - i) (wave.[int (float sampleRate * (decayVar + attackVar)) - i] * (-1.) * (hold + ((float i)*(1. - hold)) / (decayVar * float sampleRate)))

            let sustain = new List<float>()    
            for i=0 to int(sustainVar*float sampleRate) do
                sustain.Add(wave.[int (float sampleRate * (decayVar + attackVar)) - i] * hold)

            let release = Array.create (int (float sampleRate * releaseVar)) 0.  
            for i=(int(releaseVar*float sampleRate) - 1) downto 1 do
                Array.set release (int (float sampleRate * releaseVar) - i) (wave.[int (float sampleRate * (decayVar + attackVar + sustainVar)) - i] * (-1.) * (((float i)*(hold)) / (sustainVar * float sampleRate)))

            GlobalFunc.fusedData [|attack.ToArray(); decay; sustain.ToArray(); release|]
