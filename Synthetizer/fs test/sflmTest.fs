open System;
open System.Collections.Generic;
open System.Linq;
open System.Text;
open System.Threading;
open System.Threading.Tasks
open SFML.Audio;
open SFML.System;
open System.IO;

/// Write WAVE PCM soundfile (8KHz Mono 8-bit)
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
    let sampleRate = 8000 in writer.Write(sampleRate)
    let byteRate = sampleRate in writer.Write(byteRate)
    let blockAlign = 1s in writer.Write(blockAlign)
    let bitsPerSample = 8s in writer.Write(bitsPerSample)
    // data
    writer.Write("data"B)
    writer.Write(data.Length)
    writer.Write(data)

let sample x = (x + 1.)/2. * 255. |>byte

let data = Array.init 16000 (fun i -> sin (float i/float 8) |> sample)

let stream = File.Create(@"C:\AlgoSup\fsharp\project\sound.wav")
write stream data

type PlaySound() =
    member x.play filepath =
        let buffer = new SoundBuffer(filepath:Stream)
        let sound = new Sound(buffer)
        sound.Play()
        do while sound.Status = SoundStatus.Playing do 
            Thread.Sleep(3000)
let p = new PlaySound()
p.play(stream)
