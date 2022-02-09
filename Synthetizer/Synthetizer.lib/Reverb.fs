namespace Synthetizer.lib
module Reverb =
    open System.Collections.Generic

    let sampleRate = (GlobalVar.sampleRate)

    let echoWave (wave:float[]) (decay:float) delay =
        let delaySample = delay * float sampleRate
        let mutable count =1.
        let result = [|
            for x in 0.. 10 do  
            for i in 0..  int (delaySample* decay) do  (wave.[i]* ( (100.-((float i/delaySample * decay)*100. ))/100.)/count) 
            for i in 0.. int delaySample do 0.
            count <- count+1.
            |]
        result

    let delayedwave wave delay =
        Array.append (Array.create (int ((delay) * float sampleRate)) 0.) (Array.sub wave 0 (wave.Length - int ((delay)  * float sampleRate)))

    let reverb (wave:float[]) (delay:float) =

        let wave1 = delayedwave (echoWave wave 1. delay) delay
        let wave2 = delayedwave (echoWave wave 1.1 (delay + 0.00243)) (delay + 0.00243)
        let wave3 = delayedwave (echoWave wave 1.4 (delay + 0.00412)) (delay + 0.00412)
        let wave4 = delayedwave (echoWave wave 0.8 (delay - 0.00398)) (delay - 0.00398)

        Filters.makeChord [|wave; wave1; wave2; wave3; wave4|]
        //Filters.makeChord  