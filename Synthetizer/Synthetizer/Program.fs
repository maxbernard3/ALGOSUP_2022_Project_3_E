namespace Synth
open Synthetizer.lib
open System

module Sound1 =

    ////array of waveform
    //let arr = [|(Main.CreateWave "triangle" 500. 0.5 1.); (Main.CreateWave "square" 500. 0.5 1.); (Main.CreateWave "sin" 500. 0.7 1.)|]

    ////array of the time at wich the waveform start
    //let time = [| 0.0; 0.5; 1.5|]

    ////give the total time
    //let sup = [|Filters.Superpose arr time 2.0|]

    let sup = [|Envelope.envelope (Main.CreateWave "square" 500. 0.8 1.) 0.25 0.25 0.25 0.25 0.5|]

    Main.saveFile sup "sup6.wav"