namespace Synth
open Synthetizer.lib
module Sound1 =

    let song = [|Main.CreateWave "sin" 200. 1. 1.5|]

    Main.saveFile song "Tone.wave"