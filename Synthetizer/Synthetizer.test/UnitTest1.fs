module Systhetizer.test

open Synthetizer.lib
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let sinWaveformTest () =
    let result = Waves.sinWave 90. 60.3 400
    Assert.AreEqual(float32 -55.13908, float32 result)

    let result = Waves.sinWave 9. 62.8 32
    Assert.AreEqual(float32 2.57615232, float32 result)

    let result = Waves.sinWave 42. 5.7 0
    Assert.AreEqual(float32 0., float32 result)

[<Test>]
let triangleWaveTest () =
    let result = Waves.triangleWave 90. 60.3 23
    Assert.AreEqual(float32 11.3216324, float32 result)

    let result = Waves.triangleWave 9. 62.8 34
    Assert.AreEqual(float32 1.74302042, float32 result)

    let result = Waves.triangleWave 42. 5.7 356
    Assert.AreEqual(float32 3.66971421, float32 result)

[<Test>]
let squareWaveTest () =
    let result = Waves.squareWave 90. 60.3 333
    Assert.AreEqual(float32 -60.3, float32 result)

    let result = Waves.squareWave 9. 62.8 921
    Assert.AreEqual(float32 62.8, float32 result)

    let result = Waves.squareWave 42. 5.7 1500
    Assert.AreEqual(float32 5.7, float32 result)

[<Test>]
let sawtoothWaveTest () =
    let result = Waves.sawWave 90. 60.3 444
    Assert.AreEqual(float32 -11.3216324, float32 result)

    let result = Waves.sawWave 9. 62.8 642
    Assert.AreEqual(float32 16.4561634, float32 result)

    let result = Waves.sawWave 42. 5.7 12
    Assert.AreEqual(float32 0.13028571, float32 result)

<<<<<<< HEAD
[<Test>]
let envelopeTest () =
    let result = Envelope.envelope (Main.CreateWave "square" 650. 8. 1.5) 0.25 0.25 0.75 0.25 0.6

    Assert.AreEqual(float32 0.018866213151927439, float32 result.[26])
    Assert.AreEqual(float32 4.8, float32 result.[35788])
    Assert.AreEqual(float32 1.6936054421768707, float32 result.[2334])


=======
//[<Test>]
//let attackTest () =
//    let result = Waves.Envelope.attack 1. 0.1 0.5 1
//    Assert.AreEqual(float32 4.5351473922902494331065759637188E-4, float32 result)

//[<Test>]
//let decayTest () = 
//    let result = Waves.Envelope.decay 1. 0.5 0.05 0.5 1
//    Assert.AreEqual(float32 0.99954648526077097505668934240363, float32 result)

//[<Test>]
//let sustainTest () =
//    let result = Waves.Envelope.sustain 1. 0.5
//    Assert.AreEqual(float32 0.5, float32 result)

//[<Test>]
//let releaseTest () =
//    let result = Waves.Envelope.release 1. 0.5 0.1 0.5 1
//    Assert.AreEqual(float32 0.49977324263038548752834467120181, float32 result)
>>>>>>> main
