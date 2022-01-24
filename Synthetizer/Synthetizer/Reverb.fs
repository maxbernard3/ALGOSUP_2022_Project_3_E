namespace Synth
    module Reverb =
        open System
        open System.IO
        open SFML.Audio
        open System.Threading
        open System.Collections.Generic

        let wave = Waveform.data1
        let delayinMilliSeconds = 80.
        let decayFactor = 0.2 //can't be above 1
        let mixPercent = 0.5 //can't be above 1

        let combFilter waves delay decay =
            let delaySamples = int (delay * (float Waveform.sampleRate /1000.))

            let combFilterSamples = new List<float>()
            waves |> Array.iter (fun x -> combFilterSamples.Add(x))

            for i=0 to ((waves |> Array.length) - int delay - 1) do
                combFilterSamples.Insert( (i+ int delay), (combFilterSamples.[i + int delay] + (combFilterSamples.[i] * decay)) )
                combFilterSamples.RemoveAt(i + int delay + 1)

            combFilterSamples

        let allPassFilter waves delay decay =
            let delaySamples = int (delay * (float Waveform.sampleRate/1000.));
            let allPassFilterSamples = new List<float>()
            waves |> Array.iter (fun x -> allPassFilterSamples.Add(x))

            for i=0 to (waves.Length - 1) do
                if (i - delaySamples) >= 0 then
                    allPassFilterSamples.Insert( i, (allPassFilterSamples.[i] - decay * allPassFilterSamples.[i-int delay]) )
                    allPassFilterSamples.RemoveAt(i+1)

                if (i - delaySamples) >= 1 then
                    allPassFilterSamples.Insert( i, (allPassFilterSamples.[i] + decay * allPassFilterSamples.[(i+20)-int delay]) )
                    allPassFilterSamples.RemoveAt(i+1)

            let mutable value = allPassFilterSamples.[0]
            let mutable max = 0.0

            for i=0 to (waves.Length - 1) do
                if (Math.Abs(allPassFilterSamples.[i])) > max then
                    max <- Math.Abs(allPassFilterSamples.[i])

            for i=0 to (allPassFilterSamples.Count - 1) do
                value <- ((value + (allPassFilterSamples.[i] - value))/max)
                allPassFilterSamples.Insert(i, value)
                allPassFilterSamples.RemoveAt(i+1)

            allPassFilterSamples.ToArray()

        let combFilterSamples1 = combFilter wave delayinMilliSeconds decayFactor
        let combFilterSamples2 = combFilter wave (delayinMilliSeconds - 11.73) (decayFactor - 0.1313)
        let combFilterSamples3 = combFilter wave (delayinMilliSeconds + 19.31) (decayFactor - 0.2743)
        let combFilterSamples4 = combFilter wave (delayinMilliSeconds - 7.97) (decayFactor - 0.31)

        let outputComb = new List<float>()
        for i=0 to ((combFilterSamples1.Count) - 1) do
            outputComb.Add(combFilterSamples1.[i] + combFilterSamples2.[i] + combFilterSamples3.[i] + combFilterSamples4.[i])

        let mixAudio =
            let mix = new List<float>()

            for i=0 to ((combFilterSamples1.Count) - 1) do
                mix.Add(((100. - mixPercent) * wave.[i]) + (mixPercent * outputComb.[i]))
            mix.ToArray()

        let allPassFilterSamples1 = allPassFilter mixAudio 90. 0.13
        let allPassFilterSamples2 = allPassFilter allPassFilterSamples1 90. 0.13


