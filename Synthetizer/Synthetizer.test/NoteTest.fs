module Note.test

open Synthetizer.lib
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let NoteTest () =
    let test= Notes.Note "sin" "A2" 1. 1.4
    let test2= Notes.Note "sin" "A#2" 1. 1.4
    let test3= Notes.Note "sin" "B7" 1. 1.4
    let test4= Notes.Note "sin" "D6" 1. 1.4

    Assert.AreEqual(-0.14199431795763176, test.[2000])
    Assert.AreEqual(-0.42922598100473036, test2.[2000])
    Assert.AreEqual( 0.39929823521486157, test3.[8030])
    Assert.AreEqual(-0.54223504977247394, test4.[1500])

    