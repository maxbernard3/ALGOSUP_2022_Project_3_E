open System.IO
open Microsoft.FSharp.Core.Operators
/// Write WAVE PCM soundfile (8KHz Mono 8-bit)
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
    let sampleRate = 2000 in writer.Write(sampleRate) 
    let byteRate = sampleRate in writer.Write(byteRate)
    let blockAlign = 1s in writer.Write(blockAlign)
    let bitsPerSample = 8s in writer.Write(bitsPerSample)
    //data
    writer.Write("data"B)
    writer.Write(data.Length)
    writer.Write(data)
let sample x = (x + 1.)/2. * 255. |> byte 
let PI = 3.141592653589
let squarewave m x = if sin(float x/ (1. /float m))>=0  then 
                                1.
                             else
                                -1.
let sawtooth m x= x*2.*PI

let sinu m x = 1.*cos(2.*PI/0.35*x)

                                

let data = Array.init 20000 (fun i -> sinu 0.2  i |> sample) //change la durée
let stream = File.Create(@"./sinu.wav")
write stream data
