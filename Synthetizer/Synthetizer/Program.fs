namespace Synth
open Synthetizer.lib
module Sound1 =

    //example
    //sum 1st 4 value of envelope = time
    let sin = [| Envelope.envelope (Main.CreateWave "sin" 500. 0.7 1.5) 0.2 0.3 0.5 0.5 0.6|] 
    
    Main.saveFile sin "sin.wav"