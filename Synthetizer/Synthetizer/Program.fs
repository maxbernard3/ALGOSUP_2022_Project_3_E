open System
open System.IO

let pi = Math.PI
let freq = 1. // In Hertz
let sampleRate = 44100 // In Hertz
let amplitude = 0.8
let overdrive = 1.
let duration = 1. // In seconds
let pcmFormat = 1
let nbChannels = 1
let bytesPerSample = 2

let makeOverdrive multiplicator x =
    if x < (-1. * multiplicator) then (-1. * multiplicator) else
    if x > 1. * multiplicator then 1. * multiplicator else
    x

let sinWave frequence amplitude t  =
    amplitude * sin (2. * pi * t * frequence)

let sawWave frequence amplitude  t =
    2. * amplitude * (t * frequence - floor (0.5 +  t * frequence))

let squareWave frequence amplitude t =
    amplitude * float (sign (sin (2. * pi * t * frequence)))

let triangleWave frequence amplitude t =
    2. * amplitude * asin (sin (2. * pi * t * frequence)) / pi

let doubleWave frequence amplitude t =
    (sinWave frequence amplitude t) * (sinWave 440. amplitude t)

let bitsPerSample = bytesPerSample * 8

/// Write the WAVE PCM file
let write stream (data: byte []) =
    let byteRate = sampleRate * nbChannels * bytesPerSample
    let blockAlign = uint16 (nbChannels * bytesPerSample)

    use writer = new BinaryWriter(stream)
    // RIFF
    writer.Write("RIFF"B)
    writer.Write(36 + data.Length) // File size
    writer.Write("WAVE"B)
    // fmt
    writer.Write("fmt "B)
    writer.Write(16) // Header size
    writer.Write(pcmFormat)
    writer.Write(uint16 nbChannels)
    writer.Write(sampleRate)
    writer.Write(byteRate)
    writer.Write(blockAlign)
    writer.Write(uint16 bitsPerSample)
    // data
    writer.Write("data"B)
    writer.Write(data.Length)
    writer.Write(data)

/// Read WAVE PCM soundfile
let read stream =
    use reader = new BinaryReader(stream)

    reader.ReadBytes(20) |> ignore // Header
    let pcm = reader.ReadInt16()
    let nbChannels = reader.ReadUInt16()
    let sampleRate = reader.ReadInt32()
    let byteRate = reader.ReadInt32()
    let blockAlign = reader.ReadInt16()
    let bitsPerSample = reader.ReadUInt16()
    // data
    reader.ReadBytes(4) |> ignore
    let dataLength = reader.ReadInt32()
    let data = reader.ReadBytes(dataLength)

    let duration = float dataLength / float sampleRate
    sampleRate, duration, nbChannels, data

let generate func =
    let size = int (duration * float sampleRate)
    let toBytes x =
        let unitary = (x + 2. ** (float bytesPerSample - 1.)) / 2.
        let upscaled = round (unitary * (256. ** (float bytesPerSample))) - (if unitary = 1. then 1. else 0.)
        [ for k in 0..(bytesPerSample-1) do byte (upscaled/(256.**k)) ]

    let getData = float >> (fun x -> (x / float sampleRate)) >> func (freq/2.) amplitude >> makeOverdrive overdrive >> toBytes
    [ for i in 0 .. (size - 1) do yield! getData i ] |> Array.ofList

write (File.Create("toneSin.wav")) (generate sinWave)
write (File.Create("toneSquare.wav")) (generate squareWave)
write (File.Create("toneTriangle.wav")) (generate triangleWave)
write (File.Create("toneSaw.wav")) (generate sawWave)
write (File.Create("toneDouble.wav")) (generate doubleWave)

let result = read (File.Open("toneSquare.wav", FileMode.Open))