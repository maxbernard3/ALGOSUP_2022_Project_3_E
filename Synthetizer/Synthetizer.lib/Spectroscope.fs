namespace Synthetizer.lib
module Spectroscope =
    let sampleRate = GlobalVar.sampleRate

    open System
    open System.IO
    open System.Threading
    open MathNet.Filtering

    //let Spectrosope duration =
    //    let dataS1 = Array.init (int (float 100. * duration)) (fun i -> Waves.triangleWave 200. 1. i)
    //    let dataS2 = Array.init (int (float 100. * duration)) (fun i -> Waves.sinWave 200. 1. i)
    //    GlobalFunc.fusedData [|dataS1; dataS2|]

        //dataS3 |> Chart.Line |> Chart.Show

    let lowPassFilter (wave:float[]) (cutoff:float) (width:float) =

       let lowPass = IIR.IirCoefficients.LowPass((float sampleRate), cutoff, width);
       let filter = new IIR.OnlineIirFilter(lowPass);        
       filter.ProcessSamples(wave);

       //processed |> Chart.Line |> Chart.Show

    let highPassFilter (wave:float[]) (cutoff:float) (width:float) =

       let highPass = IIR.IirCoefficients.HighPass((float sampleRate), cutoff, width);
       let filter = new IIR.OnlineIirFilter(highPass);        
       filter.ProcessSamples(wave);
