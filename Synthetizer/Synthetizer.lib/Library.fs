namespace Synthetizer.lib

    module  GlobalVar =
        let sampleRate = 400 // In Hertz
        let pcmFormat = 1
        let nbChannels = 1
        let bytesPerSample = 2

    module GlobalFunc =

        let fusedData fullwave = 
            fullwave |> Array.concat

        let delayedWave time allWaves = 
            let numberOfZeros = Array.init time (fun _ -> 0.)
            Array.append numberOfZeros allWaves