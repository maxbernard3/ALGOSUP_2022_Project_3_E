namespace Synth
open Synthetizer.lib
module Sound1 =


    let arr = [|(Main.CreateWave "triangle" 50. 0.5 1.); (Main.CreateWave "square" 50. 0.5 1.); (Main.CreateWave "sin" 50. 0.7 1.)|]
    let time = [| 0.0; 0.5; 1.5|]

    let sup = [|Filters.Superpose arr time 2.5|]
    Main.saveFile sup "sup1234.wav"