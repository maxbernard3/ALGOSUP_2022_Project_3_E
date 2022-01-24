namespace Synth
    module Main =
        
        open System
        open System.IO
        open System.Threading

        let pi = Math.PI
        let sampleRate = 44100 // In Hertz
        let overdrive = 1.
        let duration = 2. // In seconds
        let pcmFormat = 1
        let nbChannels = 1
        let bytesPerSample = 2

/// Write WAVE PCM soundfile 
        let write stream (data:byte[]) =
            let writer = new BinaryWriter(stream)
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
        let data1 = Array.init (int (float sampleRate * duration)) (fun i ->Waves.triangleWave 200. 1. i |> sample)
        let data2 = Array.init (int (float sampleRate * duration)) (fun i -> Waves.sinWave 500. 1. i )
        let data3 =  Filters.echo data2 1. 1.1 0.2 3 |>Array.map (fun x -> sample x)

        let stream = File.Create("../../../test.wav")

    //let result = read (File.Open("toneSquare.wav", FileMode.Open))

        write stream data3