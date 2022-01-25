namespace Synthetizer.lib
    module SoundPlayer=

        open System
        open System.IO
        open SFML.Audio
        open System.Threading

        let sampleRate = GlobalVar.bytesPerSample

        let write stream (data:byte[]) =
            use writer = new BinaryWriter(stream)
            // RIFF
            writer.Write("RIFF"B)
            let size = 36 + data.Length in writer.Write(size)
            writer.Write("WAVE"B)
            // fmt
            writer.Write("fmt "B)
            let headerSize = 16 in writer.Write(headerSize)
            let pcmFormat = 1s in writer.Write(pcmFormat)
            let mono = 1s in writer.Write(mono)
            let sampleRate = sampleRate in writer.Write(sampleRate)
            let byteRate = sampleRate in writer.Write(byteRate)
            let blockAlign = 1s in writer.Write(blockAlign)
            let bitsPerSample = 8s in writer.Write(bitsPerSample)
            // data
            writer.Write("data"B)
            writer.Write(data.Length)
            writer.Write(data)


            // play is the function that play the contain of data

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
            write convert data
            let p = new PlaySound()
            p.play(convert)