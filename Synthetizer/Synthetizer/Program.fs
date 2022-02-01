namespace Synth
module Waveform =
    open System
    open System.IO
    open SFML.Audio
    open System.Threading
    open XPlot.Plotly
    open SFML
    open MathNet.Filtering

    let pi = Math.PI
    let sampleRate = 44100. // In Hertz
    let overdrive = 1.
    let duration = 2. // In seconds
    let pcmFormat = 1
    let nbChannels = 1
    let bytesPerSample = 2

    let makeOverdrive multiplicator x =
        if x < (-1. * multiplicator) then (-1. * multiplicator) else
        if x > 1. * multiplicator then 1. * multiplicator else
        x

    let makeChord waves =
        let x = waves |>List.sum
        x/float waves.Length 

    let sinWave frequence amplitude t  =
        amplitude * sin (2. * pi * float t * frequence / float sampleRate)

    let sawWave frequence amplitude t =
        2. * amplitude * (float t * frequence/float sampleRate - floor (0.5 +  float t * frequence/float sampleRate))

    let squareWave frequence amplitude t =
        amplitude * float (sign (sin (2. * pi * float t * frequence/float sampleRate)))

    let triangleWave frequence amplitude t =
        2. * amplitude * asin (sin (2. * pi * float t * frequence/float sampleRate)) / pi
    
    let fusedData fullwave = 
        fullwave |> Array.concat

    open System.IO

    /// Write WAVE PCM soundfile 
    let write stream (data:byte[]) =
        let writer = new BinaryWriter(stream)
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

    let sample x = (x + 1.)/2. * 255. |> byte 
    let data1 = Array.init (int (float sampleRate * duration)) (fun i -> triangleWave 200. 1. i |> sample)
    let data2 = Array.init (int (float sampleRate * duration)) (fun i -> sinWave 500. 1. i |> sample)
    let data3 = fusedData [|data1; data2|]

    let stream = File.Create("fusedTone.wav")

    //let result = read (File.Open("toneSquare.wav", FileMode.Open))

    write stream data3

    module Envelope =
        let floatSampleRate = float sampleRate

        let attack amplitude A time i =
            let fsr = float sampleRate
            let x = fsr*A*time
            (amplitude/x) * float i
        let decay amplitude decayVar D time i =
            let fsr = float sampleRate
            let y = fsr*D*time
            amplitude - decayVar/y* float i
        let sustain amplitude S =
            amplitude*S
        let release amplitude decayVar A time i =
            let fsr = float sampleRate
            let z = fsr*A*time
            (amplitude - decayVar) - 0.5/z* i
        
        let envelope (A:float) (D:float) (S:float) (R:float) (amplitude:float) (time:float) (decayVar:float) =

            let attackArray = Array.init (int (floatSampleRate*A*time)) (fun i -> attack amplitude A time i)
            let decayArray = Array.init (int (floatSampleRate*D*time)) (fun i -> decay amplitude decayVar D time i)
            let sustainArray = Array.init (int (time*(floatSampleRate - floatSampleRate*R - floatSampleRate*D - floatSampleRate*A))) (fun _ -> sustain amplitude S)
            let releaseArray = Array.init (int (floatSampleRate*A*time)) (fun i -> release amplitude decayVar A time i)
            let finalData = fusedData[|attackArray; decayArray; sustainArray; releaseArray|]
            finalData
    
        let finalData = envelope 0.1 0.05 0.5 0.5 1. 0.5 0.5
    
        //finalData |> Chart.Line |> Chart.Show
    
     module Reverb = 
        let frequence = 200.
        let amplitude = 1.
        let time = 3.
        let fstWave = amplitude * sin (2. * pi * time * frequence / float sampleRate)
        let reverb (wave:float[]) i = 
            let mutable sndWave = wave
            let mutable sndAmpl = amplitude
            while sndAmpl * i > 0.1 do
                sndAmpl <- sndAmpl * i
                let rep = Array.init (int time) (fun i -> sndAmpl * sin((2. * pi * frequence * float i) / sampleRate))
                let newWave = Array.concat [|sndWave; rep|]
                sndWave <- newWave
            sndWave

     //module Flanger = 
     //   let frequence = 200.
     //   let amplitude = 1.
     //   let time = 3.
     //   let fstWave = amplitude * sin (2. * pi * time * frequence / float sampleRate)
     //   let flanger (wave:float[]) i =
     //       let mutable sndWave = wave
     //       let mutable sndFreq = frequence - 1.
     //       let mutable sndAmpl = amplitude
            
    //take the wave, and add a second one by using a recursive
    //when i = 0 & i = 0.1:
    // - return a constant on 0
    //else return the same wave with a -1 on freq     
            


     module Spectrosope =
         let dataS1 = Array.init (int (float 100. * duration)) (fun i -> triangleWave 200 1. i)
         let dataS2 = Array.init (int (float 100. * duration)) (fun i -> sinWave 200 1. i)
         let dataS3 = fusedData [|dataS1; dataS2|]

         //dataS3 |> Chart.Line |> Chart.Show

    module lowPassFilter =
        let dataS1 = Array.init (int (float sampleRate * duration)) (fun i -> triangleWave 200 1. i)
        
        let lowPass = IIR.IirCoefficients.LowPass(44100., 2000., 1.);
        let filter = new IIR.OnlineIirFilter(lowPass);        
        let processed = filter.ProcessSamples(dataS1);

        //processed |> Chart.Line |> Chart.Show

    module highPassFilter =
        let dataS1 = Array.init (int (float sampleRate * duration)) (fun i -> triangleWave 200 1. i)
        
        let highPass = IIR.IirCoefficients.HighPass(44100., 100., 1.);
        let filter = new IIR.OnlineIirFilter(highPass);        
        let processed = filter.ProcessSamples(dataS1);

        //processed |> Chart.Line |> Chart.Show
     
    type PlaySound() =
    
        // play is the function that play the contain of data
    
        member x.play stream =
            let buffer = new SoundBuffer(stream:Stream)
            let sound = new Sound(buffer)
            sound.Play()
        
            do while sound.Status = SoundStatus.Playing do 
                Thread.Sleep(1)
    
    let p = new PlaySound()

    // convert is used to convert data's bytes in stream

    let convert = new MemoryStream()
    write convert data3

    // Call the play function with convert values

    p.play(convert)
