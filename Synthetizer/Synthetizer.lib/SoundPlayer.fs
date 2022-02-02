namespace Synthetizer.lib
    module SoundPlayer=

        open System
        open System.IO
        open SFML.Audio
        open System.Threading

        let sampleRate = GlobalVar.bytesPerSample



        type PlaySound() =
            member x.play stream =
                    let buffer = new SoundBuffer(stream:Stream)
                    let sound = new Sound(buffer)
                    sound.Play()
          
                    do while sound.Status = SoundStatus.Playing do 
                        Thread.Sleep(1)
        
        
    
        // convert is used to convert data's bytes in stream
    
        let convert = new MemoryStream()
    
        // Call the play function with convert values
        let playData data =
            Main.write convert data
            let p = new PlaySound()
            p.play(convert)