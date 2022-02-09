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


```f#
let sound = Main.CreateWave "sin" 500. 1. 2.
```

As you can see just above we ask to create a sin wave, you can create four type of waves such as :
- sin
- triangle
- square
- sawtooth

The second parameter is the frequency of the wave, basically lower is the frequency, more piercing the sound will be, on the other hand higher is the frequency, deeper thesound will be.

The third parameter is the amplitude of the wave, to put it simply it is the volume, the maximum is 1 while 0 is equal to nothing.

Finally the last sound is the duration in second of the wave, there is no constraint on this value.

### <ins> Create A basic note

To create a Basic note it is almost like the first example, but with a huge difference with the sound produced.<br>
To create a note you have to proceed like this :
```f#
let note = Notes.Note "sin" "A2" 1. 2.
let note = Notes.Note "sin" "A#2" 1. 2.

```
As you can see, the difference is the frequency, here we change the frequency with note, we allow to use the same amount of notes as you can see on a piano, which are :
- A,B,C,D,E,F,G
- A#,C#,D#,F#,G#<br>
the first third note (which are A, A# and B) begin at 0 while the other ones begins at 1, also the notes stop at 7 except for C who stop at 8 which make C8 the deeper note and A0 the highest note.
<br>
To have a better understanding of the note and their frequencies this link should be able to help you : https://en.wikipedia.org/wiki/Piano_key_frequencies

### <ins> Save A sound

It is pretty easy to save a sound, you just have to write this
```f#
let note = Notes.Note "sin" "A2" 1. 2.

```