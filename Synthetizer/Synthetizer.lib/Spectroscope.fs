namespace Synthetizer.lib
module Spectroscope =
    let sampleRate = GlobalVar.sampleRate

    open System
    open System.IO
    open System.Threading
    open 

    //module Spectrosope =
    //    let dataS1 duration = Array.init (int (float 100. * duration)) (fun i -> triangleWave 200 1. i)
    //    let dataS2 duration = Array.init (int (float 100. * duration)) (fun i -> sinWave 200 1. i)
    //    let dataS3 duration = GlobalFunc.fusedData [|dataS1; dataS2|]

    //    //dataS3 |> Chart.Line |> Chart.Show

    //module lowPassFilter =
    //   let dataS1 = Array.init (int (float sampleRate * duration)) (fun i -> triangleWave 200 1. i)
       
    //   let lowPass = IIR.IirCoefficients.LowPass(44100., 2000., 1.);
    //   let filter = new IIR.OnlineIirFilter(lowPass);        
    //   let processed = filter.ProcessSamples(dataS1);

    //   //processed |> Chart.Line |> Chart.Show

    //module highPassFilter =
    //   let dataS1 = Array.init (int (float sampleRate * duration)) (fun i -> triangleWave 200 1. i)
       
    //   let highPass = IIR.IirCoefficients.HighPass(44100., 100., 1.);
    //   let filter = new IIR.OnlineIirFilter(highPass);        
    //   let processed = filter.ProcessSamples(dataS1);
