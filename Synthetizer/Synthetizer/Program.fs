namespace Synth
open Synthetizer.lib
module Sound1 =

    let song = Main.CreateWave "sin" 200. 1. 1.5

    let song2 = Main.CreateWave "triangle" 200. 1. 1.5

    let nothing = Main.CreateWave "empty" 200. 1. 1.5

    let DelayedSong = GlobalFunc.delayedWave 8820 song

    let ReducedSong = Filters.reduceAmplitude 2. song

    let ChordSong = Filters.makeChord [|song; song2|]

    let EverySong = GlobalFunc.fusedData[|song; song2; nothing; DelayedSong; ReducedSong; ChordSong|]

    Main.saveFile [|EverySong|] "NewCombinedTone.wave"
    //example
    //sum 1st 4 value of envelope = time
    let song3 = [| Envelope.envelope (Main.CreateWave "square" 600. 1. 1.5) 0.25 0.25 0.75 0.25 0.6 |] 

    Main.saveFile song3 "square.wav"
