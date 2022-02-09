module Filters.test

open Synthetizer.lib
open System
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

let sampleRate = GlobalVar.sampleRate

[<Test>]
let makeOverdriveTest () =
    let random = Random()
    let redundency = 100

    let time = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*1000.)
    let overrideRand = Array.init redundency (fun i -> amplitudeRand.[i] - (amplitudeRand.[i]/4.))

    let resultSin = Array.init redundency (fun i -> Filters.makeOverdrive (Main.CreateWave "sin" freqRand.[i] amplitudeRand.[i] time.[i]) overrideRand.[i])

    for i=0 to (redundency-1) do
        Assert.AreEqual(Math.Round(Math.Abs(overrideRand.[i]), 4) , Math.Round(Math.Abs(resultSin.[i].[int((float sampleRate/freqRand.[i])/4.)]), 4))

[<Test>]
let makeChordTest () =
    let random = Random()
    let redundency = 100

    let waveName (a:float) =
        match a with
        | a when (a < 0.25) -> "sin"
        | a when (a < 0.5) && (a >= 0.25) -> "square"
        | a when (a < 0.75) && (a>= 0.5) -> "triangle"
        | a when (a < 1) && (a>= 0.75) -> "sawtooth"
        | _ -> "sin"

    let timeRand = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand1 = Array.init redundency (fun i -> random.NextDouble())
    let freqRand1 = Array.init redundency (fun i -> random.NextDouble()*1000.)
    let waveRand1 = Array.init redundency (fun i -> waveName (random.NextDouble()) )
    let wave1 = Array.init redundency (fun i -> (Main.CreateWave waveRand1.[i] freqRand1.[i] amplitudeRand1.[i] timeRand.[i]))

    let amplitudeRand2 = Array.init redundency (fun i -> random.NextDouble())
    let freqRand2 = Array.init redundency (fun i -> random.NextDouble()*1000.)
    let waveRand2 = Array.init redundency (fun i -> waveName (random.NextDouble()) )
    let wave2 = Array.init redundency (fun i -> (Main.CreateWave waveRand2.[i] freqRand2.[i] amplitudeRand2.[i] timeRand.[i]))

    let chorWave = Array.init redundency (fun i -> Filters.makeChord [| wave1.[i]; (Main.CreateWave waveRand2.[i] freqRand2.[i] amplitudeRand2.[i] timeRand.[i]) |])

    for i=0 to (redundency-1) do
        let randI = Array.init 30 (fun a -> int(random.NextDouble()*(timeRand.[i]*float sampleRate)))
        for j=0 to 29 do
            let a = Math.Round(Math.Abs((wave1.[i].[randI.[j]] + wave2.[i].[randI.[j]])/2.), 4)
            let b = Math.Round(Math.Abs(chorWave.[i].[randI.[j]]), 4)
            Assert.AreEqual( a, b)

[<Test>]
let fusedDataTest () =
    let random = Random()
    let redundency = 100

    let waveName (a:float) =
        match a with
        | a when (a < 0.25) -> "sin"
        | a when (a < 0.5) && (a >= 0.25) -> "square"
        | a when (a < 0.75) && (a>= 0.5) -> "triangle"
        | a when (a < 1) && (a>= 0.75) -> "sawtooth"
        | _ -> "sin"

    let timeRand1 = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand1 = Array.init redundency (fun i -> random.NextDouble())
    let freqRand1 = Array.init redundency (fun i -> random.NextDouble()*1000.)
    let waveRand1 = Array.init redundency (fun i -> waveName (random.NextDouble()) )
    let wave1 = Array.init redundency (fun i -> (Main.CreateWave waveRand1.[i] freqRand1.[i] amplitudeRand1.[i] timeRand1.[i]))

    let timeRand2 = Array.init redundency (fun i -> 1.1 + random.NextDouble()*2.)
    let amplitudeRand2 = Array.init redundency (fun i -> random.NextDouble())
    let freqRand2 = Array.init redundency (fun i -> random.NextDouble()*1000.)
    let waveRand2 = Array.init redundency (fun i -> waveName (random.NextDouble()) )
    let wave2 = Array.init redundency (fun i -> (Main.CreateWave waveRand2.[i] freqRand2.[i] amplitudeRand2.[i] timeRand2.[i]))

    let resultFused = Array.init redundency (fun i -> GlobalFunc.fusedData [|wave1.[i]; wave2.[i] |])

    for i=0 to (redundency - 1) do
        let a = int ((timeRand1.[i] + timeRand2.[i])*float sampleRate)
        let b = resultFused.[i].Length

        Assert.IsTrue(Math.Abs(a-b) < 2 )

   
