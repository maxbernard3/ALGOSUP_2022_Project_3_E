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
    let sinWave i x  = sin ( float i * x)

    let triangleWave i x = asin(sin(pi*(float i)*x))/(pi/2.)

    let squareWave i x =
        if sin(float i*x)>= 0.  then
            1.
        else
            -1.

    let sawtoothWave i x = float i*(-1. * float x)

    let emptyWave i x = 0.

    //Merge the sinus and sawtooth waves together
    let sawtoothPlusSinu m x = 1.*cos(2.*pi/0.35*float x)*2.*pi


    // CREATE ARRAYS CONTAINING EACH  WAVES DATA
    let data = Array.init 20000 (fun i -> sawtoothWave i 1. |> sample)

    let emptyTest = Array.init 20000 (fun i -> emptyWave i 1. |> sample)
    //create an array of the empty wave data where we can change the duration

    let sinTest = Array.init 20000 (fun i -> sinWave i 1. |> sample)
    //create an array of the sin wave data where we can change the duration

    let sawtoothTest = Array.init 20000 (fun i -> sawtoothWave i 1. |> sample)
    //create an array of the sawtooth wave data where we can change the duration




    //PROGRAM TESTING

    // let testArray = Array.init 4 (fun v -> v + 5)

    let createSinWave = [| yield! sinTest |]
    let createSawtoothWave = [| yield! sawtoothTest |]
    let createEmptyWave = [| yield! emptyTest |]

    let inputs =
        [| createSinWave
           createSawtoothWave
           createSinWave
           createSawtoothWave |]
        |> Array.concat
    
 
    //PROGRAM TESTING






    //COMBINING WAVES

    let combined = [| yield! sinTest ; yield! sawtoothTest; |] //combine 2 waves in one

    let threeCombined = [| yield! sinTest ; yield! emptyTest ; yield! sawtoothTest; |] //combine 3 waves in one

    // CREATING WAV. FILES

    let emptyStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\empty.wav")
    write emptyStream emptyTest     //create a new .wav file

    let SinStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\newSin.wav")
    write SinStream sinTest     //create a new .wav file

    let sawtoothStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\newSawtooth.wav")
    write sawtoothStream sawtoothTest   //create a new .wav file

    let dobleStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\newSinSawtoothCombined.wav")
    write dobleStream combined  //create a new .wav file

    let tripleStream = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\SinEmptySawtoothCombined.wav")
    write tripleStream threeCombined  //create a new .wav file

    let severalStreams = File.Create(@"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\Sounds\severalSinsCombined.wav")
    write severalStreams inputs  //create a new .wav file