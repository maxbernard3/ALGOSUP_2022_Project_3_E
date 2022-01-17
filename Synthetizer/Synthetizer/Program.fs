namespace Synth
    module Waveform =
        open System
        open System.IO

        let pi = Math.PI
        let sampleRate = 44100 // In Hertz
        let overdrive = 1.
        let duration = 2. // In seconds
        let pcmFormat = 1
        let nbChannels = 1
        let bytesPerSample = 2

        let makeOverdrive multiplicator x =
            if x < (-1. * multiplicator) then (-1. * multiplicator) else
            if x > 1. * multiplicator then 1. * multiplicator else
            x

        let makeChord waves =
            let x = waves |>List.sum
            x/float waves.Length 

        let sinWave frequence amplitude t  =
            amplitude * sin (2. * pi * t * frequence / float sampleRate)

        let sawWave frequence amplitude t =
            2. * amplitude * (float t * frequence/float sampleRate - floor (0.5 +  t * frequence/float sampleRate))

        let squareWave frequence amplitude t =
            amplitude * float (sign (sin (2. * pi * t * frequence/float sampleRate)))

        let triangleWave frequence amplitude t =
            2. * amplitude * asin (sin (2. * pi * t * frequence/float sampleRate)) / pi

        open System.IO

        /// Write WAVE PCM soundfile 
        let write stream (data:byte[]) =
            use writer = new BinaryWriter(stream)
            // RIFF
            writer.Write("RIFF"B)
            let size = 36 + data.Length in writer.Write(size)
            writer.Write("WAVE"B)
            // fmt
            writer.Write("fmt "B)
            let headerSize = 16 in writer.Write(headerSize)
            let pcmFormat = 1s in writer.Write(pcmFormat)
            let mono = 1s in writer.Write(mono)
            let sampleRate = sampleRate in writer.Write(sampleRate)
            let byteRate = sampleRate in writer.Write(byteRate)
            let blockAlign = 1s in writer.Write(blockAlign)
            let bitsPerSample = 8s in writer.Write(bitsPerSample)
            // data
            writer.Write("data"B)
            writer.Write(data.Length)
            writer.Write(data)

        let sample x = (x + 1.)/2. * 255. |> byte 
        let data = Array.init (int (float sampleRate * duration)) (fun i -> makeChord [(sinWave 5 1 i); (triangleWave 5 1 i)] |> sample)
        let stream = File.Create("tone.wav")

        //let result = read (File.Open("toneSquare.wav", FileMode.Open))

        write stream data
