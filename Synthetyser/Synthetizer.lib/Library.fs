namespace Synthetizer.lib

    module  GlobalVar =
        let sampleRate = 44100 // In Hertz
        let pcmFormat = 1
        let nbChannels = 1
        let bytesPerSample = 2

    module GlobalFunc =

        let fusedData fullwave = 
            fullwave |> Array.concat