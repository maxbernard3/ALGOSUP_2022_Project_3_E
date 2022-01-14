module Tests

open System
open Xunit
open Synth

[<Fact>]
let ``sinWave`` () =
    let result = Waveform.sinWave 8000. 1. 20. 
    Assert.Equal (float32 -1.55418353266192e-11,float32 result)

    let result = Waveform.sinWave 44000. 0.5 320. 
    Assert.Equal (float32 -2.54648590360220e-9,float32 result)

    let result = Waveform.sinWave 3953. 0.8 77787. 
    Assert.Equal (float32 -9.95992596884305e-8,float32 result)

[<Fact>]
let ``sawWave`` () =
    let result = Waveform.sawWave 8000. 1. 22.324445
    Assert.Equal (float32 -0.880000000004657,float32 result)

    let result = Waveform.sawWave 1. 0.5 3.2
    Assert.Equal (float32 0.2,float32 result)

    let result = Waveform.sawWave 3953. 0.8 77.787 
    Assert.Equal (float32 0.0175999999977648,float32 result)

[<Fact>]
let ``squareWave`` () =
    let result = Waveform.squareWave 8000. 1. 22.324445
    Assert.Equal (float32 -1,float32 result)

    let result = Waveform.squareWave 1. 0.5 3.2
    Assert.Equal (float32 0.5,float32 result)

    let result = Waveform.squareWave 3953. 0.8 77.787 
    Assert.Equal (float32 0.8,float32 result)

[<Fact>]
let ``triangleWave`` () =
    let result = Waveform.triangleWave 8000. 1. 20. 
    Assert.Equal (float32 -9.89424E-12,float32 result)

    let result = Waveform.triangleWave 44000. 0.5 320. 
    Assert.Equal (float32 -1.6211433E-09,float32 result)

    let result = Waveform.triangleWave 3953. 0.8 77787. 
    Assert.Equal (float32 -6.340686E-08,float32 result)

[<Fact>]
let ``doubleWave`` () =
    let result = Waveform.doubleWave 8000. 1. 20. 
    Assert.Equal (float32 8.7619065E-24,float32 result)

    let result = Waveform.doubleWave 44000. 0.5 320. 
    Assert.Equal (float32 1.1484909E-20,float32 result)

    let result = Waveform.doubleWave 3953. 0.8 77787. 
    Assert.Equal (float32 5.5812436E-16,float32 result)