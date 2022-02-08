module Waves.test

open Synthetizer.lib
open System
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()
let sampleRate = GlobalVar.sampleRate

[<Test>]
let sinWaveformTest () =
    let random = Random()
    let redundency = 100

    let time = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*1000.)

    let resultSin = Array.init redundency (fun i -> Main.CreateWave "sin" freqRand.[i] amplitudeRand.[i] time.[i])

    for i=0 to (redundency-1) do
        Assert.IsTrue(resultSin.[i].[0] < resultSin.[i].[int((float sampleRate/freqRand.[i])/8.)])
        Assert.IsTrue(resultSin.[i].[int((float sampleRate/freqRand.[i])/2.)] > resultSin.[i].[int((float sampleRate/freqRand.[i])/4.)*3])

[<Test>]
let triangleWaveTest () =
    let random = Random()
    let redundency = 100

    let time = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*1000.)

    let resultSin = Array.init redundency (fun i -> Main.CreateWave "triangle" freqRand.[i] amplitudeRand.[i] time.[i])

    for i=0 to (redundency-1) do
        Assert.IsTrue(resultSin.[i].[0] < resultSin.[i].[int((float sampleRate/freqRand.[i])/8.)])
        Assert.IsTrue(resultSin.[i].[int((float sampleRate/freqRand.[i])/2.)] > resultSin.[i].[int((float sampleRate/freqRand.[i])/4.)*3])

[<Test>]
let squareWaveTest () =
    let random = Random()
    let redundency = 100

    let time = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*1000.)

    let resultSin = Array.init redundency (fun i -> Main.CreateWave "square" freqRand.[i] amplitudeRand.[i] time.[i])

    for i=0 to (redundency-1) do
        Assert.AreEqual(amplitudeRand.[i] ,resultSin.[i].[int((float sampleRate/freqRand.[i])/8.)])
        Assert.AreEqual(amplitudeRand.[i] ,resultSin.[i].[int((float sampleRate/freqRand.[i])/4.)])
        Assert.AreEqual((-1.*amplitudeRand.[i]) ,resultSin.[i].[int((float sampleRate/freqRand.[i])/4.)*3])
        Assert.AreEqual((-1.*amplitudeRand.[i]) ,resultSin.[i].[int((float sampleRate/freqRand.[i])/8.)*7])

[<Test>]
let sawtoothWaveTest () =
    let random = Random()
    let redundency = 100

    let time = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*1000.)

    let resultSin = Array.init redundency (fun i -> Main.CreateWave "sawtooth" freqRand.[i] amplitudeRand.[i] time.[i])

    for i=0 to (redundency-1) do
        Assert.IsTrue(resultSin.[i].[0] < resultSin.[i].[int((float sampleRate/freqRand.[i])/8.)])
        Assert.IsTrue(resultSin.[i].[int((float sampleRate/freqRand.[i])/2.)] > resultSin.[i].[int((float sampleRate/freqRand.[i])/4.)*3])


