module Filter.test

open Synthetizer.lib
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let envelopeTest () =
    let result = Envelope.envelope (Main.CreateWave "square" 650. 0.8 1.5) 0.25 0.25 0.75 0.25 0.6

    Assert.AreEqual(float32 0.00188662135, float32 result.[26])
    Assert.AreEqual(float32 0.48, float32 result.[35788])
    Assert.AreEqual(float32 0.16936054421768707, float32 result.[2334])