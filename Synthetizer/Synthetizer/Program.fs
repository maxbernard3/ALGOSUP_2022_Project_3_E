namespace Synth
open Synthetizer.lib

module Sound1 =

    //let song = Main.CreateWave "sin" 200. 1. 1.5

    //let song2 = Main.CreateWave "triangle" 200. 1. 1.5

    //let nothing = Main.CreateWave "empty" 200. 1. 1.5

    //let DelayedSong = GlobalFunc.delayedWave 8820 song

    //let ReducedSong = Filters.reduceAmplitude 2. song

    //let ChordSong = Filters.makeChord [|song; song2|]

    //let EverySong = GlobalFunc.fusedData[|song; song2; nothing; DelayedSong; ReducedSong; ChordSong|]

    //Main.saveFile [|EverySong|] "NewCombinedTone.wave"
    ////example
    ////sum 1st 4 value of envelope = time
    let sqr = Notes.Note "square" "C6" 0.5 1.5
    let test=  Notes.Note "sin" "C8" 0.5 1.5
    let chord= Filters.makeChord[|sqr; test|]
    
    Main.saveFile [|chord|] "note.wav"
    