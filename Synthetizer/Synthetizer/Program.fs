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
    
    let song=GlobalFunc.fusedData[|
        //1
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //2
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //3
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //4
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //5
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //6
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //7
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //8
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "B4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G#4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "B4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "B4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G#4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "B4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "B4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G#4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //9
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //10
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //11
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "D#3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "F3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //12
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "G3" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;Envelope.envelope (Notes.Note "sin" "A2" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A4" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "C5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "E5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        Envelope.envelope (Notes.Note "sin" "A5" 0.5 0.15)  0.03 0. 0.09 0.045 1.;
        //13













    |]

    
   
    
    Main.saveFile [|song|] "Doom.wav"
    