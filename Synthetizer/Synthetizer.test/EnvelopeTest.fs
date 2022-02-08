module Envelope.test

open Synthetizer.lib
open System
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

let sampleRate = GlobalVar.sampleRate

[<Test>]
let Attack_Test () =
    let random = Random()
    let redundency = 100

    let attackRand = Array.init redundency (fun i -> random.NextDouble())
    let decayRand = Array.init redundency (fun i -> random.NextDouble())
    let sustainRand = Array.init redundency (fun i -> random.NextDouble())
    let releaseRand = Array.init redundency (fun i -> random.NextDouble())
    let holdRand = Array.init redundency (fun i -> random.NextDouble())
    let total = Array.init redundency (fun i -> (attackRand.[i] + decayRand.[i] + sustainRand.[i] + releaseRand.[i]))
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*200.)
    
    async {
            let! text = File.ReadAllTextAsync(path) |> Async.AwaitTask
            let fileName = Path.GetFileName(path)
            Console.WriteLine($"File {fileName} has {text.Length} bytes")
    }


    let resultEnvelop = Array.init redundency (fun i -> Envelope.envelope (Main.CreateWave "square" freqRand.[i] amplitudeRand.[i] total.[i]) attackRand.[i] decayRand.[i] sustainRand.[i] releaseRand.[i] holdRand.[i])

    for i=0 to (redundency-1) do
        Assert.IsTrue(Math.Abs(resultEnvelop.[i].[int((attackRand.[i]/3.)*float sampleRate)]) <= Math.Abs(resultEnvelop.[i].[int((attackRand.[i]/2.)*float sampleRate)]))


[<Test>]
let Decay_Test () =
    let random = Random()
    let redundency = 100

    let attackRand = Array.init redundency (fun i -> random.NextDouble())
    let decayRand = Array.init redundency (fun i -> random.NextDouble())
    let sustainRand = Array.init redundency (fun i -> random.NextDouble())
    let releaseRand = Array.init redundency (fun i -> random.NextDouble())
    let holdRand = Array.init redundency (fun i -> random.NextDouble())
    let total = Array.init redundency (fun i -> (attackRand.[i] + decayRand.[i] + sustainRand.[i] + releaseRand.[i]))
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*200.)

    let resultEnvelop = Array.init redundency (fun i -> Envelope.envelope (Main.CreateWave "square" freqRand.[i] amplitudeRand.[i] total.[i]) attackRand.[i] decayRand.[i] sustainRand.[i] releaseRand.[i] holdRand.[i])

    for i=0 to (redundency-1) do
        Assert.IsTrue(Math.Abs(resultEnvelop.[i].[int((attackRand.[i] + (decayRand.[i]/3.))*float sampleRate)]) >= Math.Abs(resultEnvelop.[i].[int((attackRand.[i]+ (decayRand.[i]/2.))*float sampleRate)]))


[<Test>]
let Sustain_Test () =
    let random = Random()
    let redundency = 100

    let attackRand = Array.init redundency (fun i -> random.NextDouble())
    let decayRand = Array.init redundency (fun i -> random.NextDouble())
    let sustainRand = Array.init redundency (fun i -> random.NextDouble())
    let releaseRand = Array.init redundency (fun i -> random.NextDouble())
    let holdRand = Array.init redundency (fun i -> random.NextDouble())
    let total = Array.init redundency (fun i -> (attackRand.[i] + decayRand.[i] + sustainRand.[i] + releaseRand.[i]))
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*200.)

    let resultEnvelop = Array.init redundency (fun i -> Envelope.envelope (Main.CreateWave "square" freqRand.[i] amplitudeRand.[i] total.[i]) attackRand.[i] decayRand.[i] sustainRand.[i] releaseRand.[i] holdRand.[i])

    for i=0 to (redundency-1) do
        Assert.AreEqual(Math.Abs(resultEnvelop.[i].[int((attackRand.[i] + decayRand.[i] + (sustainRand.[i]/3.))*float sampleRate)]), Math.Abs(resultEnvelop.[i].[int((attackRand.[i] + decayRand.[i] + (sustainRand.[i]/3.))*float sampleRate)]))

[<Test>]
let Release_Test_Decrease () =
    let random = Random()
    let redundency = 100

    let attackRand = Array.init redundency (fun i -> random.NextDouble())
    let decayRand = Array.init redundency (fun i -> random.NextDouble())
    let sustainRand = Array.init redundency (fun i -> random.NextDouble())
    let releaseRand = Array.init redundency (fun i -> random.NextDouble())
    let holdRand = Array.init redundency (fun i -> random.NextDouble())
    let total = Array.init redundency (fun i -> (attackRand.[i] + decayRand.[i] + sustainRand.[i] + releaseRand.[i]))
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*200.)

    let resultEnvelop = Array.init redundency (fun i -> Envelope.envelope (Main.CreateWave "square" freqRand.[i] amplitudeRand.[i] total.[i]) attackRand.[i] decayRand.[i] sustainRand.[i] releaseRand.[i] holdRand.[i])

    for i=0 to (redundency-1) do
        Assert.IsTrue(Math.Abs(resultEnvelop.[i].[int((attackRand.[i] + decayRand.[i] + sustainRand.[i] + (releaseRand.[i]/3.))*float sampleRate)]) >= Math.Abs(resultEnvelop.[i].[int((attackRand.[i] + decayRand.[i] + sustainRand.[i] + (releaseRand.[i]/1.5))*float sampleRate)]))

[<Test>]
let Release_Test_Go_To_0 () =
    let random = Random()
    let redundency = 100

    let attackRand = Array.init redundency (fun i -> random.NextDouble())
    let decayRand = Array.init redundency (fun i -> random.NextDouble())
    let sustainRand = Array.init redundency (fun i -> random.NextDouble())
    let releaseRand = Array.init redundency (fun i -> random.NextDouble() + 0.1)
    let holdRand = Array.init redundency (fun i -> random.NextDouble())
    let total = Array.init redundency (fun i -> (attackRand.[i] + decayRand.[i] + sustainRand.[i] + releaseRand.[i]))
    let amplitudeRand = Array.init redundency (fun i -> random.NextDouble())
    let freqRand = Array.init redundency (fun i -> random.NextDouble()*200.)

    let resultEnvelop = Array.init redundency (fun i -> Envelope.envelope (Main.CreateWave "square" freqRand.[i] amplitudeRand.[i] total.[i]) attackRand.[i] decayRand.[i] sustainRand.[i] releaseRand.[i] holdRand.[i])

    for i=0 to (redundency-1) do
        Assert.IsTrue( Math.Abs(resultEnvelop.[i].[int (total.[i] * float sampleRate)]) < (0.01))


        