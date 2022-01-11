module Systhetizer.test
open Synth

open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let sinWaveformTest () =
    let result = Waveform.sinWave 90 60.3
    Assert.AreEqual(result, -0.99487262318918815)

    let result = Waveform.sinWave 9 62.8
    Assert.AreEqual(result, -0.28276702757104044)

    let result = Waveform.sinWave 42 5.7
    Assert.AreEqual(result, 0.59635959615697076)

[<Test>]
let triangleWaveTest () =
    let result = Waveform.triangleWave 90 60.3
    Assert.AreEqual(result, -4.612279887310475E-13)

    let result = Waveform.triangleWave 9 62.8
    Assert.AreEqual(result, -0.3999999999999424)

    let result = Waveform.triangleWave 42 5.7
    Assert.AreEqual(result, -0.79999999999999261)

[<Test>]
let squareWaveTest () =
    let result = Waveform.squareWave 90 60.3
    Assert.AreEqual(result, -1.0)

    let result = Waveform.squareWave 9 62.8
    Assert.AreEqual(result, -1.0)

    let result = Waveform.squareWave 42 5.7
    Assert.AreEqual(result, 1.0)

[<Test>]
let sawtoothWaveTest () =
    let result = Waveform.sawtoothWave 90 60.3
    Assert.AreEqual(result, -5427.0)

    let result = Waveform.sawtoothWave 9 62.8
    Assert.AreEqual(result, -565.19999999999993)

    let result = Waveform.sawtoothWave 42 5.7
    Assert.AreEqual(result, -239.40000000000001)


    
