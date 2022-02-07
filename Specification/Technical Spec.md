# F# Sound Synthesiser

## Technical Specification

## Team
Aurélien Fernandez <br>
Max Bernard <br>
Antonin Pillet <br>
Quentin Clément <br>
David Cuahonte Cuevas <br>
Paul Nowak <br>

## Technichal choices

We have chosen to create a simple library for this sound synthesiser, that programmers/coders will be able to use it easily. The aim of this project is to be able to play music from code and add to this some basic filters.

## Requirements

### How to write a sound file

To create a .wav sound file, we need to determinate its format so we could write it. Indeed, this is a simple format which wouldn't require a library.

The .wav file, also known as WAVE (Waveform Audio File Format), is an audio file format standard used for storing data. It's one of the application used by Microsoft’s Resource Interchange File Format (RIFF) which is specification for storing digital audio files. 

This picture shows all the data fathered in a standard WAV format:<br>

http://soundfile.sapp.org/doc/WaveFormat/wav-sound-format.gif

As you can see, this is basically a RIFF file which contains 2 sub-chunks: "fmt " which specifies the data format, and "data" which is containing the actual sample data. 

The goal would be to create an array of bytes shown as hexadecimal numbers. For that, we will need to write all the data necessary with a binary writer function:<br>

```
stream = (user input)
data = (user input)
write =
    use writer = new BinaryWriter(stream)
    Write("RIFF"B)
    size = 36 + data.Length
    Write("WAVE"B)
    Write("fmt "B)
    headerSize = 16
    pcmFormat = 1
    NumChannels = 1
    sampleRate = 44100 // In Hertz
    byteRate = sampleRate 
    blockAlign = 1
    bitsPerSample = 8
    Write("data"B)
    Write(data.Length)
    Write(data)
```
In computers and digital audio, a data object is preceded by the RIFF header. A header is a unit of information containing important information such as the sample rate or the date of the last update, as they mosty represent the first 44 bytes.

The sample rate is the number of samples the computer takes per second. It allows us to describe the quality of a sound file.
By sampling a sound wave, the data are taken from a continuous signal to convert an analogue audio signal into a digital signal. 

The channels are the position of each audio source within the audio signal. When set to 1, the sound is mono and when set to 2, it is set to stereo.


### Basic Waveforms

We have to generate 4 types of waveforms :
    - Sinus: amplitude * sin (2 * pi * time * frequence / sampleRate)
    - Triangle: 2 * amplitude * (time * frequence/sampleRate - floor (0.5 + time * frequence/sampleRate))
    - Sawtooth: amplitude * float (sign (2 * pi * time * frequence/float sampleRate))
    - Square: 2 * amplitude * asin (2 * pi * time * frequence/sampleRate) / pi

The empty waveform could be also useful for creating some combinations:
    -Empty: 0.

#### Generate a sound file

To generate a sound file, we need to convert the original wave to a byte array. So, before generating our sound file, we have to create a function, which does it.
Then, we have to create a second function, which convert an array of bytes to a type stream, that can then be iread by the console.

### Save Waveforms

We need a function to create/save a .wav file from an array of bytes. This array of bytes is our wave.

### Play Sound

We have to create a function to read the previous .wav file created but we also need a function to read directly the array of bytes without saving it (we are allowed to used the SFML library). 

### Effects

An effect to cut the amplitude just dividing the value of the amplitude by an input value to reduce/increase it:
amplitude/x
with x that is an input value for the user

#### Overdrive
a function that detect if a point on the waveform is within a certain threshold or not and if it is higher (or lower) than the threshold it set the output as the limit
```
threshold = (user input)

if a < (-1*threshold) then
    b = -1*threshold
else
    if a < threshold then
        b = threshold
    else
        b = a
```

#### Basic Filters


#### Echo

This filter's purpose is to create an "echo". So basically, this effect returns a selected sound inside a file and it will repeat itself a defined number of times, each time with a decrasing amplitude.

To do this we will need some parameters to call the function like :
- the original wave
- the moment when the echo starts (in seconds)
- the moment when the echo ends (in seconds)
- a delay between the original sound and the echo, and between each echo (in seconds)
- the number of echoes 

#### Reverb

This effect is able to, based on the original sound, repete this one with less amplitude, but just with a little latency/delay. So, in parameter, we need:
- a sound
- the amplitude
- a delay (in seconds)

#### Flanger

This effect create a copy of the original waveform but
with a decreasing frequency and then, fuse the two waves.
The parameters for this functions are :
- the original wave
- the moment when the flanger starts (in seconds)
- the moment when the flanger ends (in seconds)
- a number to define the speed of decay of the copied version of the wave 

### Four Stage Envelope
The four stage envelope is a function that modulates the amplitude of an input wave. <br>
The input wave takes the form of an array of float (or double). <br>
We also need the time duration for each phases of the ADSR as well as the sustain's amplitude. <br>
Hold can't be greater than 1 because decay is meant to be decreasing in amplitude and would break if it is increased. <br>
The fonction would calculate an array for each phase of the ADSR and join them at the end. Like so: <br>
```
a = (user input) * sampleRate
d = (user input) * sampleRate
s = (user input) * sampleRate
r = (user input) * sampleRate
hold = (user input) 

for i=0 to i=a do
    attack[i] = wave[i] * (i/a)
    i = i+1
    
for i=0 to i=d do
    decay[i] = wave[a+i] * (hold-(i*(1-hold)/d)
    i = i+1
    
for i=0 to i=s do
    sustain[i] = wave[a+d+i] * hold
    i = i+1
    
for i=0 to i=d do
    release[i] = wave[a+d+s+i] * (-i*(hold)/r)
    i = i+1

return (attack + decay + sustain + release)
```

### High and Low Pass Filter

For the high and the low pass filter, we'll use a library (MathNet.Filtering) to analyse the frequencies and to only return the high ones (~5000Hz) or the low ones (~100Hz) depending of the filter that we want.

### Chord

The Chord function needs to be able to combine two waveforms or more. So we have to take the number of arrays ( waves) asked by the user, we will fuse them in one array only and it will make an unique wave.

### Optional Functions

#### Delay

This function must be able to delay the starting point of a soundwave:

```
delayedWave time allWaves = 
    numberOfZeros = init time (fun _ -> 0.)
    append numberOfZeros + allWaves
```


#### Musical notes

We can create the basical notes based on the piano, so the 88 notes from A0 to C8, to do that we just need to ask from the user :
- The wanted note
- the duration of the note (in second) 
- the type of wave (sin, triangle, square or sawtooth)
- amplitude
    ```
    amplitude =(user input)= 1
    wave= (user input) = "sin"
    note = (user input) = "A0"
    duration=(user input)= 1.5
    sampleRate=44100
    let note =[
      for i in 0.. (duration* float sampleRate) do
        if (note.[1]!="#") then
            if (note.[0]="A") then
                if (wave="sin)then
                    if(note.[1]='0')then
                        amplitude * sin (2 * pi * time * 27.5000 / sampleRate)
                    else 
                        amplitude * sin (2 * pi * time * (55.0000* int note.[1]) / sampleRate)
              ]
    ```
