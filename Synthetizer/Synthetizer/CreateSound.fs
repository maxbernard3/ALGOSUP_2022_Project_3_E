// namespace Synth
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
        let sampleRate = 4000 in writer.Write(sampleRate)
        let byteRate = sampleRate in writer.Write(byteRate)
        let blockAlign = 1s in writer.Write(blockAlign)
        let bitsPerSample = 8s in writer.Write(bitsPerSample)

        // data
        writer.Write("data"B)
        writer.Write(data.Length)
        writer.Write(data)

    let sample x = (x + 1.)/2. * 255. |> byte

    // SET YP THE DIFFERENT FORMS OF WAVES
    //need to pass along i, x changes the frequency

    //algorithm to create an empty Wave returning no signal
    let emptyWave i x = 0.

    //algorithm to create a sin Wave
    let sinWave i x  = sin ( float i * x)

    //algorithm to create a triangle Wave
    let triangleWave i x = asin(sin(pi*(float i)*x))/pi

    //algorithm to create a square Wave
    let squareWave i x =
        if sin(float i*x)>= 0.  then
            1.
        else
            -1.

    //algorithm to create a sawtooth Wave
    let sawtoothWave i x = float i*(-1. * float x)

    //Merge the sinus and sawtooth algorithms together
    let sawtoothPlusSinu m x = 1.*cos(2.*pi/0.35*float x)*2.*pi


    // CREATE ARRAYS CONTAINING EACH WAVES DATA

    let emptyTest = Array.init 20000 (fun i -> emptyWave i 1. |> sample)
    //create an array of the empty wave data where we can change the duration

    let sinTest = Array.init 20000 (fun i -> sinWave i 1. |> sample)
    //create an array of the sin wave data where we can change the duration

    let triangleTest = Array.init 20000 (fun i -> triangleWave i 1. |> sample)
    //create an array of the triangle wave data where we can change the duration

    let squareTest = Array.init 20000 (fun i -> squareWave i 1. |> sample)
    //create an array of the square wave data where we can change the duration

    let sawtoothTest = Array.init 20000 (fun i -> sawtoothWave i 1. |> sample)
    //create an array of the sawtooth wave data where we can change the duration

    //SOUND CUSTOMIZATION
    // return all the data from each waves in arrays

    let createEmptyWave = [| yield! emptyTest |]
    let createSinWave = [| yield! sinTest |]
    let createTriangleWave = [| yield! triangleTest |]
    let createSquareWave = [| yield! squareTest |]
    let createSawtoothWave = [| yield! sawtoothTest |]
    
    // create a combined wave based on several waves and concat all the data in a single wave
    let customizedWave =
        [| createSinWave
           createTriangleWave
           createSquareWave
           createSawtoothWave |]
        |> Array.concat

    // CREATING WAV. FILES

    //Empty wave sound
    let emptyStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\empty.wav")
    write emptyStream emptyTest     

    //Sin wave sound
    let SinStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\newSin.wav")
    write SinStream sinTest     

    //Triangle wave sound
    let TriangleStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\Triangle.wav")
    write TriangleStream triangleTest     

    //Square wave sound
    let SquareStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\Square.wav")
    write SquareStream squareTest     

    //Sawtooth wave sound
    let sawtoothStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\newSawtooth.wav")
    write sawtoothStream sawtoothTest   

    //Customized wave sound
    let severalStreams = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\customizedSound.wav")
    write severalStreams customizedWave  