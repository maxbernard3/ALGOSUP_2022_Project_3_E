namespace Synth

    open System.Numerics
    open System.IO
    open System

    module Waveform =
        let pi = Math.PI

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
            let sampleRate = 8000 in writer.Write(sampleRate)
            let byteRate = sampleRate in writer.Write(byteRate)
            let blockAlign = 1s in writer.Write(blockAlign)
            let bitsPerSample = 8s in writer.Write(bitsPerSample)
            // data
            writer.Write("data"B)
            writer.Write(data.Length)
            writer.Write(data)

        let sample x = (x + 1.)/2. * 255. |> byte

        //need to pass along i, x changes the frequency
        let sinWave i x  = sin ( float i * x)

        let triangleWave i x = asin(sin(pi*(float i)*x))/(pi/2.)

        let squareWave i x =
            if sin(float i*x)>= 0.  then 
                1.
            else
                -1.

        let sawtoothWave i x = float i*(-1. * float x)

        let data = Array.init 16000 (fun i -> sawtoothWave i 1. |> sample)
        let stream = File.Create(@"/Users/maxbernard/Documents/F#/tone006.wav")
        write stream data

