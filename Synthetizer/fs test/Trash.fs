///// Write WAVE PCM soundfile (8KHz Mono 8-bit)
//let write stream (data:byte[]) =
//    use writer = new BinaryWriter(stream)
//    // RIFF
//    writer.Write("RIFF"B)
//    let size = 36 + data.Length in writer.Write(size)
//    writer.Write("WAVE"B)
//    // fmt
//    writer.Write("fmt "B)
//    let headerSize = 16 in writer.Write(headerSize)
//    let pcmFormat = 1s in writer.Write(pcmFormat)
//    let mono = 1s in writer.Write(mono)
//    let sampleRate = 8000 in writer.Write(sampleRate)
//    let byteRate = sampleRate in writer.Write(byteRate)
//    let blockAlign = 1s in writer.Write(blockAlign)
//    let bitsPerSample = 8s in writer.Write(bitsPerSample)
//    // data
//    writer.Write("data"B)
//    writer.Write(data.Length)
//    writer.Write(data)

//let sample x = (x + 1.)/2. * 255. |> byte

//let data = Array.init 16000 (fun i -> sin (float i/float 8) |> sample)
//let stream = File.Create(@"C:\Algosup\fsharp\project\sound.wav")
//write stream data

//let snd = new SoundPlayer(@"C:\Algosup\fsharp\project\sound.wav");
//snd.Play()

//let read stream =
//    use reader = new BinaryReader(stream)

//    reader.ReadBytes(20) |> ignore // Header
//    let pcm = reader.ReadInt16()
//    let nbChannels = reader.ReadUInt16()
//    let sampleRate = reader.ReadInt32()
//    let byteRate = reader.ReadInt32()
//    let blockAlign = reader.ReadInt16()
//    let bitsPerSample = reader.ReadUInt16()
//    // data
//    reader.ReadBytes(4) |> ignore
//    let dataLength = reader.ReadInt32()
//    let data = reader.ReadBytes(dataLength)

//    let duration = float dataLength / float sampleRate
//    sampleRate, duration, nbChannels,bitsPerSample, data

//let readAndReturnStream stream =
//    use reader = new BinaryReader(stream)

//    reader.ReadBytes(20) |> ignore // Header
//    let pcm = reader.ReadInt16()
//    let nbChannels = reader.ReadUInt16()
//    let sampleRate = reader.ReadInt32()
//    let bitsPerSample = reader.ReadUInt16()
//    // data
//    reader.ReadBytes(4) |> ignore
//    let dataLength = reader.ReadInt32()
//    let data = reader.ReadBytes(dataLength)

//    let bytePerSample = bitsPerSample/ uint16 8
//    let writer = new Synthesizer.writeWav(sampleRate, pcm, int nbChannels, int bytePerSample)
//    let memStream = new MemoryStream()
//    writer.Write memStream data
    
//    memStream




//let convertToBinaryString data =
//    let rec loop (acc : string) (lst : byte list) =
//        match lst with
//        | [] -> acc
//        | _ -> loop (acc + (System.Convert.ToString(lst.Head, 2).PadLeft(8, '0'))) lst.Tail
//
//    loop "" (Array.toList data)
//
//let p = convertToBinaryString(data)

