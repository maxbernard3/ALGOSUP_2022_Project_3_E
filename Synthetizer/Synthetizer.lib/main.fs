namespace Synthetizer.lib
    module Main =
        let sampleRate = GlobalVar.sampleRate

        open System
        open System.IO
        open System.Threading

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


            // play is the function that play the contain of data


        let toBytes i = i |> Array.map(fun x -> (x + 1.)/2. * 255. |> byte)

        let CreateWave (waveForm:string) (frequency:float) (amplitude:float) (duration:float) =
            match waveForm with
            | "sin" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.sinWave frequency amplitude i)
            | "triangle" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.triangleWave frequency amplitude i)
            | "sawtooth" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.sawWave frequency amplitude i)
            | "square" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.squareWave frequency amplitude i)
            | "empty" -> Array.create (int (float sampleRate * duration)) 0.001
            | _ -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.squareWave frequency amplitude i)


        let saveFile wave (filePath:string) =
            let waveBites = wave |> GlobalFunc.fusedData |> toBytes

            let stream = File.Create(@$"../../../{filePath}")
            write stream waveBites