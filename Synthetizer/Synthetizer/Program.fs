namespace Synth
open Synthetizer.lib
module Sound1 =

    //array of waveform
    let arr = [|(Main.CreateWave "triangle" 500. 0.5 1.); (Main.CreateWave "square" 500. 0.5 1.); (Main.CreateWave "sin" 500. 0.7 1.)|]

    //array of the time at wich the waveform start
    let time = Musics.imperialMarch
    
    //give the total time
    let sup = [|Filters.Superpose arr time 2.5|]
    Main.saveFile [|time|] "../../../imperialMarch.wav"