namespace Synthetizer.lib
    module Main =
        let sampleRate = GlobalVar.sampleRate

        open System
        open System.IO
        open System.Threading
        open MP3Sharp

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
        
        // Define a function to construct a message to print
        //let write stream frequency (data:byte[]) =
        //    use writer = new BinaryWriter(stream)
        //    // RIFF
        //    writer.Write("RIFF"B)
        //    let size = 36 + data.Length in writer.Write(size)
        //    writer.Write("WAVE"B)
        //    // fmt
        //    writer.Write("fmt "B)
        //    let headerSize = 16 in writer.Write(headerSize)
        //    let pcmFormat = 1s in writer.Write(pcmFormat)
        //    let mono = 2s in writer.Write(mono)
        //    writer.Write(frequency: int)
        //    writer.Write(frequency: int)
        //    let blockAlign = 1s in writer.Write(blockAlign)
        //    let bitsPerSample = 16s in writer.Write(bitsPerSample)
        //    // data
        //    writer.Write("data"B)
        //    writer.Write(data.Length)
        //    writer.Write(data)

        //let convert2WAV path output=
        //    let writeIntermediateFile()= 
        //        use mp3 = File.OpenRead(path)
        //        use stream = new MP3Stream(mp3)
        //        let memory = new System.IO.MemoryStream()
        //        let buffer = Array.zeroCreate 4096 
        //        while not stream.IsEOF do
        //            let bytesRead = stream.Read(buffer, 0, buffer.Length)
        //            memory.Write(buffer, 0, bytesRead)
        //        let Tuple = (stream.Frequency, memory)
        //        Tuple
        //    let frequency, memory = writeIntermediateFile();
        //    use outputStream = File.OpenWrite(output)
        //    let bytes = memory.ToArray()
        //    write outputStream frequency bytes
        //    printfn "Print finished"

        let toBytes i = i |> Array.map(fun x -> (x + 1.)/2. * 255. |> byte)

        let CreateWave (waveForm:string) (frequency:float) (amplitude:float) (duration:float) =
            match waveForm with
            | "sin" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.sinWave frequency amplitude i)
            | "triangle" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.triangleWave frequency amplitude i)
            | "sawtooth" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.sawWave frequency amplitude i)
            | "square" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.squareWave frequency amplitude i)
            | "empty" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.emptyWave frequency amplitude i)
            | _ -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.squareWave frequency amplitude i)


        let saveFile wave (filePath:string) =
            let waveBites = wave |> GlobalFunc.fusedData |> toBytes

            let stream = File.Create(@$"../../../{filePath}")
            write stream waveBites