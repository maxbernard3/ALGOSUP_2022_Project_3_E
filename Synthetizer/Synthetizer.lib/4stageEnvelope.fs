namespace Synthetizer.lib
    //module Envelope =

        //open XPlot.Plotly
        //let sampleRate = GlobalVar.bytesPerSample
        //let floatSampleRate = float GlobalVar.bytesPerSample

        //let attack amplitude A time i =
        //    let fsr = float sampleRate
        //    let x = fsr*A*time
        //    (amplitude/x) * float i
        //let decay amplitude decayVar D time i =
        //    let fsr = float sampleRate
        //    let y = fsr*D*time
        //    amplitude - decayVar/y* float i
        //let sustain amplitude S =
        //    amplitude*S
        //let release amplitude decayVar A time i =
        //    let fsr = float sampleRate
        //    let z = fsr*A*time
        //    (amplitude - decayVar) - 0.5/z* i
    
        //let envelope (wave:float[]) (attackVar:float) (decayVar:float) (sustainVar:float) (releaseVar:float) (sustainAmplitude)=
        //    let attackArray = Array.init (int (floatSampleRate*A)) (fun i -> attack amplitude A time i)
        //    let decayArray = Array.init (int (floatSampleRate*D)) (fun i -> decay amplitude decayVar D time i)
        //    let sustainArray = Array.init (int (floatSampleRate*S)) (fun _ -> sustain amplitude S)
        //    let releaseArray = Array.init (int (floatSampleRate*R)) (fun i -> release amplitude decayVar A time (float i) )
        //    let finalData = GlobalFunc.fusedData[|attackArray; decayArray; sustainArray; releaseArray|]
        //    finalData

        //let showChart (data:float[]) =
        //    data |> Chart.Line |> Chart.Show