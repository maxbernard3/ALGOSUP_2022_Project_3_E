namespace Synthetizer.lib
  module Notes =


    let Note (wave:string) (note:string) (amplitude:float) (duration:float) =
            let mutable result =[||]        
            let multiplier =
                if not (note.[1]='#')then
                    if (note.[1]='0') then
                        1.
                        
                    else
                        let pow = float note.[1]-48.
                        2.**pow
                else
                    if (note.[2]='0') then
                        1.
                        
                    else
                        let pow = float note.[2]-48.
                        2.**pow
               
           
            if not (note.[1]='#') then
              if not (note.[1]='8') then
                match note.[0] with
                    |'A'->  result<-if (note.[1]='0')then
                                         Main.CreateWave wave (27.50000) amplitude duration
                                    else
                                         Main.CreateWave wave (55.00000*multiplier) amplitude duration

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
                    |'A'->  result<-if (note.[1]='0')then
                                         Main.CreateWave wave (29.13524) amplitude duration
                                    else
                                         Main.CreateWave wave (58.27047*multiplier) amplitude duration 
                    |'C'->  result<- Main.CreateWave wave (34.64783*multiplier) amplitude duration
                    |'D'->  result<- Main.CreateWave wave (38.89087*multiplier) amplitude duration
                    |'F'->  result<- Main.CreateWave wave (46.24930*multiplier) amplitude duration
                    |'G'->  result<- Main.CreateWave wave (51.91309*multiplier) amplitude duration
                    |_-> invalidArg note "note not found" 
              else
                invalidArg note "note not found" 

       

       
            result
           



            