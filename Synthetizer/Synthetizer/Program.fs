namespace Synth
open Synthetizer.lib
module Sound1 =

    // Test simple signals
    let sinSignal = Main.CreateWave "sin" 200. 1. 1.5
    //Main.saveFile [|sinSignal|] "sinSignal.wav"

    let triangleSignal = Main.CreateWave "triangle" 200. 1. 1.5
    //Main.saveFile [|triangleSignal|] "triangleSignal.wav"

    let sawtoothSignal = Main.CreateWave "sawtooth" 200. 1. 1.5
    //Main.saveFile [|sawtoothSignal|] "sawtoothSignal.wav"

    let squareSignal = Main.CreateWave "square" 200. 1. 1.5
    //Main.saveFile [|squareSignal|] "squareSignal.wav"

    let nothing = Main.CreateWave "empty" 200. 1. 1.5
    //Main.saveFile [|nothing|] "nothing.wav"

    //Test modified songs
    let DelayedTriangle = GlobalFunc.delayedWave 8820 triangleSignal
    //Main.saveFile [|DelayedSin|] "DelayedSin.wav"

    let ReducedSin = Filters.reduceAmplitude 2. sinSignal
    let ReducedTriangle = Filters.reduceAmplitude 2. triangleSignal
    //Main.saveFile [|ReducedSin|] "ReducedSin.wav"

    let ChordSinTriangle = Filters.makeChord [|sinSignal; triangleSignal|]
    //Main.saveFile [|ChordSinTriangle|] "ChordSinTriangle.wav"

    //let EverySong = GlobalFunc.fusedData[|sinSignal; triangleSignal; nothing; DelayedSin; ReducedSin; ChordSinTriangle|]
    //Main.saveFile [|EverySong|] "EverySong.wav"
   
    //REVERB TEST
    let reducedDelayedTriangle = Filters.reduceAmplitude 4. DelayedTriangle

    let mergeTriangleTest = Filters.merge [|triangleSignal; reducedDelayedTriangle|]

    let sumTriangleTest = Filters.sum [|ReducedTriangle; reducedDelayedTriangle|]
    //Main.saveFile [|sumTriangleTest|] "sumTriangleTest2.wav"

    //let dividedChord = Filters.reduceAmplitude 2. mergeTest
    //Main.saveFile [|dividedChord|] "dividedChord.wav"

    Mp3ConverterWav.convert2WAV @"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\sample.mp3"
        @"C:\Users\PaulNOWAK\Desktop\Algosup\Computering\Projects\Project sound synthesis\ALGOSUP_2022_Project_3_E\Synthetizer\Synthetizer\sample.wav"
    //array of waveform
    let arr = [|(Main.CreateWave "triangle" 500. 0.5 1.); (Main.CreateWave "square" 500. 0.5 1.); (Main.CreateWave "sin" 500. 0.7 1.)|]

    //array of the time at wich the waveform start
    let time = [| 0.0; 0.5; 1.5|]

    //give the total time
    let sup = [|Filters.Superpose arr time 2.5|]
    Main.saveFile sup "sup1234.wav"
