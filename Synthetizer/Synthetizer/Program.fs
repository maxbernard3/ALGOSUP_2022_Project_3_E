namespace Synth
open Synthetizer.lib
module Sound1 =


    let arr = [|(Main.CreateWave "triangle" 500. 0.5 1.); (Main.CreateWave "square" 500. 0.5 1.); (Main.CreateWave "sin" 500. 0.7 1.)|]
    let time = [| 0.0; 0.5; 1.5|]

    let sup = [|Filters.Superpose arr time 2.5|]
    Main.saveFile sup "sup1234.wav"