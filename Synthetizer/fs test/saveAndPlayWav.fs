﻿open System  
open System.IO
open System.Media  
open SFML


/// Create a wave with all parameters

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

// Sample convert previous values in bytes

let sample x = (x + 1.)/2. * 255. |>byte

// Data is an array of bytes with all the previous values

let data = Array.init 16000 (fun i -> sin (float i/float 8) |> sample)

let stream = File.Create(@"C:\Users\AntoninPILLET\Desktop\crashtest\F# test folder\fs test\fs test\sound.wav")

write stream data

let sound = new SoundPlayer(@"C:\Algosup\F#\Project Sound Synthesis\crashtest\sound.wav");
sound.Play();




