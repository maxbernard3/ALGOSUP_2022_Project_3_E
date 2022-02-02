namespace Synth
open Synthetizer.lib

module Sound1 =

    //let song = Main.CreateWave "square" 200. 1. 1.5

    //let song2 = Main.CreateWave "triangle" 200. 1. 1.5

    //let nothing = Main.CreateWave "empty" 200. 1. 1.5

    //let DelayedSong = GlobalFunc.delayedWave 8820 song

    //let ReducedSong = Filters.reduceAmplitude 2. song

    //let ChordSong = Filters.makeChord [|song; song2|]

    //let EverySong = GlobalFunc.fusedData[|song; song2; nothing; DelayedSong; ReducedSong; ChordSong|]

    //Main.saveFile [|EverySong|] "NewCombinedTone.wave"
    ////example
    ////sum 1st 4 value of envelope = time
    
    let song= Musics.imperialMarch

    
    
    Main.saveFile [|song|] "test.wav"
    