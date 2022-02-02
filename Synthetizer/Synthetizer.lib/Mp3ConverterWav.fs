namespace Synthetizer.lib
    module Mp3ConverterWav =
        open MP3Sharp
        open System.IO

        // Define a function to construct a message to print
        let write stream frequency (data:byte[]) =
            use writer = new BinaryWriter(stream)
            // RIFF
            writer.Write("RIFF"B)
            let size = 36 + data.Length in writer.Write(size)
            writer.Write("WAVE"B)
            // fmt
            writer.Write("fmt "B)
            let headerSize = 16 in writer.Write(headerSize)
            let pcmFormat = 1s in writer.Write(pcmFormat)
            let mono = 2s in writer.Write(mono)
            writer.Write(frequency: int)
            writer.Write(frequency: int)
            let blockAlign = 1s in writer.Write(blockAlign)
            let bitsPerSample = 16s in writer.Write(bitsPerSample)
            // data
            writer.Write("data"B)
            writer.Write(data.Length)
            writer.Write(data)

        //Convert a .mp3 file into a .wav file
        let convert2WAV path output=
            let writeIntermediateFile()= 
                use mp3 = File.OpenRead(path)
                use stream = new MP3Stream(mp3)
                let memory = new System.IO.MemoryStream()
                let buffer = Array.zeroCreate 4096 
                while not stream.IsEOF do
                    let bytesRead = stream.Read(buffer, 0, buffer.Length)
                    memory.Write(buffer, 0, bytesRead)
                let Tuple = (stream.Frequency, memory)
                Tuple
            let frequency, memory = writeIntermediateFile();
            use outputStream = File.OpenWrite(output)
            let bytes = memory.ToArray()
            write outputStream frequency bytes
            printfn "Print finished"
 