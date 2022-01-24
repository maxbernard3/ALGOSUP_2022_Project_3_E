namespace Synthetizer.lib
    module Main =
        let sampleRate = GlobalVar.sampleRate

        open System
        open System.IO
        open System.Threading


        let fusedData fullwave = 
            fullwave |> Array.concat

        let toBytes i = i |> Array.map(fun x -> (x + 1.)/2. * 255. |> byte)

        let CreateWave (waveForm:string) (frequency:float) (amplitude:float) (duration:float) =
            match waveForm with
            | "sin" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.sinWave frequency amplitude i)
            | "triangle" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.triangleWave frequency amplitude i)
            | "sawtooth" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.sawWave frequency amplitude i)
            | "square" -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.squareWave frequency amplitude i)
            | _ -> Array.init (int (float sampleRate * duration)) (fun i -> Waves.squareWave frequency amplitude i)


        let saveFile wave (filePath:string) =
            let waveBites = wave |> fusedData |> toBytes

            let stream = File.Create($"{filePath}")
            SoundPlayer.write stream waveBites