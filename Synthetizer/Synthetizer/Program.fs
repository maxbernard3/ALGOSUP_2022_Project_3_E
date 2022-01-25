namespace Synth
open Synthetizer.lib
module Sound1 =

<<<<<<< HEAD
    //example
    //sum 1st 4 value of envelope = time
    let song = [| Envelope.envelope (Main.CreateWave "square" 600. 1. 1.5) 0.25 0.25 0.75 0.25 0.6 |] 

    Main.saveFile song "square.wav"
=======
    let song = [|Main.CreateWave "sin" 200. 1. 1.5|]

    Main.saveFile song "Tone.wave"
>>>>>>> main
