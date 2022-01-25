//module Systhetizer.test
//open Synth

//open NUnit.Framework

//[<SetUp>]
//let Setup () =
//    ()

//[<Test>]
//let sinWaveformTest () =
//    let result = Waveform.sinWave 90. 60.3 400
//    Assert.AreEqual(float32 -55.13908, float32 result)

//    let result = Waveform.sinWave 9. 62.8 32
//    Assert.AreEqual(float32 2.57615232, float32 result)

//    let result = Waveform.sinWave 42. 5.7 0
//    Assert.AreEqual(float32 0., float32 result)

//[<Test>]
//let triangleWaveTest () =
//    let result = Waveform.triangleWave 90. 60.3 23
//    Assert.AreEqual(float32 11.3216324, float32 result)

//    let result = Waveform.triangleWave 9. 62.8 34
//    Assert.AreEqual(float32 1.74302042, float32 result)

//    let result = Waveform.triangleWave 42. 5.7 356
//    Assert.AreEqual(float32 3.66971421, float32 result)

//[<Test>]
//let squareWaveTest () =
//    let result = Waveform.squareWave 90. 60.3 333
//    Assert.AreEqual(float32 -60.3, float32 result)

//    let result = Waveform.squareWave 9. 62.8 921
//    Assert.AreEqual(float32 62.8, float32 result)

//    let result = Waveform.squareWave 42. 5.7 1500
//    Assert.AreEqual(float32 5.7, float32 result)

//[<Test>]
//let sawtoothWaveTest () =
//    let result = Waveform.sawWave 90. 60.3 444
//    Assert.AreEqual(float32 -11.3216324, float32 result)

//    let result = Waveform.sawWave 9. 62.8 642
//    Assert.AreEqual(float32 16.4561634, float32 result)

//    let result = Waveform.sawWave 42. 5.7 12
//    Assert.AreEqual(float32 0.13028571, float32 result)

//[<Test>]
//let attackTest () =
//    let result = Waveform.Envelope.attack 1. 0.1 0.5 1
//    Assert.AreEqual(float32 4.5351473922902494331065759637188E-4, float32 result)

//[<Test>]
//let decayTest () = 
//    let result = Waveform.Envelope.decay 1. 0.5 0.05 0.5 1
//    Assert.AreEqual(float32 0.99954648526077097505668934240363, float32 result)

//[<Test>]
//let sustainTest () =
//    let result = Waveform.Envelope.sustain 1. 0.5
//    Assert.AreEqual(float32 0.5, float32 result)

//[<Test>]
//let releaseTest () =
//    let result = Waveform.Envelope.release 1. 0.5 0.1 0.5 1
//    Assert.AreEqual(float32 0.49977324263038548752834467120181, float32 result)

    
