namespace Synth
    open System
    open System.IO
    open XPlot.Plotly

    module fourStageEnveloppe =
    
        let sampleRate = 44100. // In Hertz

        let enveloppe (A:float) (D:float) (S:float) (R:float) (amplitude:float) (time:float) (decayVar:float) =
            
                let Attack = Array.init (int (sampleRate*A*time)) (fun i -> amplitude/(sampleRate*A*time)* float i)
                let Decay = Array.init (int (sampleRate*D*time)) (fun i -> amplitude - decayVar/(sampleRate*D*time)* float i)
                let Sustain = Array.init (int (time*(sampleRate - sampleRate*R- sampleRate*D - sampleRate*A))) (fun _ -> S*amplitude)
                let Release = Array.init (int (sampleRate*A*time)) (fun i -> (amplitude - decayVar) - 0.5/(sampleRate*A*time)* float i)
                let finalData = fusedData[|Attack; Decay; Sustain; Release|]
                finalData
        
            let finalData = enveloppe 0.1 0.05 0.5 0.5 1. 0.5 0.5
        
            finalData |> Chart.Line |> Chart.Show

