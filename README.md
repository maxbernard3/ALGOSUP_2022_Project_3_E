# ALGOSUP_2022_Project_3_E
## <ins>Introduction:
The aim of this project is to create a sound synthesizer that can be used to create programmable music. This project was inspired by Sonic Pi (https://sonic-pi.net/) and other live coding music packages. The ultimate aim of this project is to be able to play music from code

## <ins>Basic use :

### <ins> Prerequisites : 
- Minimum version of .NET: 6.0 
- Download the file Synthetizer from the Main branch in https://github.com/maxbernard3/ALGOSUP_2022_Project_3_E
- Add the reference Synthetizer.lib on your project after downloading the file

### <ins> How to create a sound :

To create a sound you'll have to proceed like this :


```fs
let sound = Main.CreateWave "sin" 500. 1. 2.
```

As you can see just above we ask to create a sin wave, you can create these four type of waves :
- sin
- triangle
- square
- sawtooth

The second parameter is the frequency of the wave, the lower the frequency the lower the pitch will be, on the other hand higher frequencies will lower the pitch.

The third parameter is the amplitude of the wave, it is the volume, the maximum is 1 while 0 is equal to no sound.

Finally the last sound is the duration in seconds of the wave. It must be a float.

### <ins> Create a basic note :

Creating a basic note is almost like creating a basic wave example.<br>
to create a note you have to proceed as in the following example :
```fs
let note = Notes.Note "sin" "A2" 1. 2.
let note = Notes.Note "triangle" "A#2" 1. 2.
```
As you can see, the difference is the frequency, here we change the frequency with note, it allows us to emulate a piano's notes, which are :
- A,B,C,D,E,F,G
- A#,C#,D#,F#,G#
the first three note (which are A, A# and B) begin at 0 while the other ones begin at 1, also the notes stop at 7 except for C who stop at 8 which make C8 the highest note and A0 the lowest note.
<br>
To better understand the notes and their frequencies you can look at the following link : https://en.wikipedia.org/wiki/Piano_key_frequencies

### <ins> Save a sound :

It is pretty easy to save a sound, to do so, you'll have to follow this exemple :
```fs
let note = Notes.Note "sin" "A2" 1. 2.
Main.saveFile [|note|] "./mySound.wav"  
```
The first parameter is the sound(s) you want to save, it has to be an array of arrays if you want to save sound in your file.

The second parameter is the path of your file.

## <ins> Advanced use :

### <ins> Add a filter on a sound

We have the following filters :
- Echo/reverb
- Overdriven
- Low/high pass filter
- four stage envelope
To add filters to your sound, you need to have your sound as an input of the filter function. More detailed case-to-case examples are provided below.

### <ins> Echo :

To add an echo to a sound you'll have to write this:
```fs 
let note = Notes.notes "square" "C#3" 1. 2.
let echo = note 0.5 0.7 0.1 3
```
The first parameter is your sound.<br>
The second and third parameter are the part of the sound you want to reproduce, in this case, the echo is based on the moment between 0.5 and 0.7. these floats are meant to be in second.<br>
The fourth parameter is the delay between the original sound and the echo, and between the echo themselves. like the two last parameters it is meant to be in second.<br>
the last one is the number of appearance of the echo.<br>
Except for the last one which is an int, all numbers are meant to be floats.
### <ins> Overdriven :
An overdrive is a sound cut at a specific amplitude. To create this kind of effect follow this example:
```fs
let note = Notes.notes "square" "C#3" 1. 1.
let overdrive = note 0.5
```
The first parameter is the wave you want to modify.<br>
the second one the where the overdrive occur. You have to remember that this parameter have to be between 0 and the amplitude of the wave, if it is higher than the amplitude, nothing will happen.
### <ins> Four Stage Envelope :

The four stages envelope or ADSR changes a wave's amplitude over time. The first input is the wave itself. The next four inputs are the times for the periods of the ADSR and the 6th input is called "hold" which is contained between 0 & 1<br>
In order, the ADSR correspond to :
- Attack: the time it takes for the wave to go from 0 to max amplitude
- Decay: the time it takes for a wave's amplitude to decrease from max to "hold"
- Sustain: the amplitude will stay on "hold"
- Release: the time it takes the amplitude to get back to 0. from "hold"

the sum of the ADSR should be no longer than the total time of the wave. I would advise making the ADSR slightly shorter than the wave if you encounter crashes while using the envelope<br>
<br>
The envelope is called diferently from the other filters
```fs
let wave = Main.CreateWave "triangle" 500. 0.8 1.
let envelope = Envelope.envelope wave 0.1 0.2 0.6 0.1 0.5
```


## <ins> Project Team :
[Max Bernard](https://github.com/maxbernard3)<br>
[Aurélien Fernandez](https://github.com/aurelienfernandez)<br>
[Quentin Clément](https://github.com/Quentin-Clement)<br>
[Paul Nowak](https://github.com/PaulNowak36)<br>
[Antonin Pillet](https://github.com/antonin-pillet)<br>
[David Cuahonte](https://github.com/DavidCC812)