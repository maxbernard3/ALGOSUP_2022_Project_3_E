namespace Synthetizer.lib
  module Notes =


    let Note (wave:string) (note:string) (amplitude:float) (duration:float) =
            let mutable result =[||]        
            let multiplier =
                
                if not (note.[1]='#') then

                    if (int note.[1]-48<=8)then

                        if (note.[1]='0') then
                            float note.[1]-47.
                        else
                            float note.[1]-48.

                    else
                        invalidArg note "number too high" 


                else
                    if (int note.[2]-48<8)then

                        if (note.[2]='0') then

                            float note.[2]-47.
                        else
                            float note.[2]-48.

                    else
                        invalidArg note "number too high"


            if not (note.[1]='#') then
              if not (note.[1]='8') then
                match note.[0] with
                    |'A'->  result<- Main.CreateWave wave (27.50000*multiplier) amplitude duration
                    |'B'->  result<- Main.CreateWave wave (30.86771*multiplier) amplitude duration
                    |'C'->  result<- Main.CreateWave wave (32.70320*multiplier) amplitude duration
                    |'D'->  result<- Main.CreateWave wave (36.70810*multiplier) amplitude duration
                    |'E'->  result<- Main.CreateWave wave (41.20344*multiplier) amplitude duration
                    |'F'->  result<- Main.CreateWave wave (43.65353*multiplier) amplitude duration
                    |'G'->  result<- Main.CreateWave wave (48.99943*multiplier) amplitude duration
                    |_-> invalidArg note "note not found" 
              else
                    result<- Main.CreateWave wave (32.70320*multiplier) amplitude duration

            else
              if not (note.[2]='8') then
                match note.[0] with
                    |'A'->  result<- Main.CreateWave wave (29.13524*multiplier) amplitude duration
                    |'C'->  result<- Main.CreateWave wave (34.64783*multiplier) amplitude duration
                    |'D'->  result<- Main.CreateWave wave (38.89087*multiplier) amplitude duration
                    |'F'->  result<- Main.CreateWave wave (46.24930*multiplier) amplitude duration
                    |'G'->  result<- Main.CreateWave wave (51.91309*multiplier) amplitude duration
                    |_-> invalidArg note "note not found" 
              else
                invalidArg note "note not found" 

       

       
            result
           



            