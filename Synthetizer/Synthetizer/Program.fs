namespace Synth
open Synthetizer.lib
module Sound1 =
   

    let ori=  Musics.imperialMarch

<<<<<<< Updated upstream
    Main.saveFile[|ori|] "ImperialMarch.wav"
=======
    //array of the time at wich the waveform start
    let time = Musics.imperialMarch
    
    //give the total time
    let sup = [|Filters.Superpose arr time 2.5|]
    let test = Notes.Note "square" "A7" 1. 1.

    Main.saveFile [|test|] "../../../test.wav"
>>>>>>> Stashed changes
