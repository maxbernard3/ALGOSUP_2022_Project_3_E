# F# Synthetiser

## Functional Specifications

<p>The program needs to be able to meet all of the following requirements as well as be easy to use : <br></P>

- Generate the four basic waveform (sin, triangle, square, sawtooth)
- Save waveforms to disk
- Read a section of an audio file
- play the waveform directly without saving it
- Filters :

	- Modify the wave’s amplitude
	- Cut off the wave at specific amplitude
	- Add echo to the sound
	- Flange effect
	- Reverb effect

- Chords
- A four stage envelope (attack, decay, sustain and release)
- Apectroscope analyses
- Low and high pass filter
- Low Frequency Oscillator
- MP3 Compression

<p>An example or two demonstrating the program functionality would be a plus</p>

---
## Technical Specifications

### Technology choice

<p>We use F# as requirement from the client.</p>

<p>.NET provide us with a large number of functionality, built in math library, is easy to test and I don't know how to use C# or F# any other way than with .NET
we are ussing .NET 6.0 specificaly because earlier version have trooble working with mac M1.</p>

<p>We are using NUnit test as for our purpose any of the test framework are equivalent, and it's the one we are the most familiar with</p>

<p>We are using both Visual Studio 2022 and VS code as IDE. VS 2022(and 2019) have easy to use test feature for .NET and overall is simple to use with .NET.</p>

<p>We are using GitHub for version control. everybody, or at least every sub team as a branch. When a functionality is finished the team makes a pull request that to be approved by the administrator to be merged into the main branch.<p>

### Software Architecture
<p>Our software will be organized into two-layer for clarity. Most of the calculations will be in a library, and most of the input and output will be made in a dotnet console app.</p>

<p>The inputs are made by calling a function corresponding to a wave, passing along frequency, amplitude, effect(s), and duration. the return from the inputs should be put in a list that will then be given to another function that will generate a .mp3 from all the waves in sequence as well as play said music from the computer</p>

<p>the folowing diagram show how we intend diferent function and file to comunicate</p>

![Software Architecture(1)](https://user-images.githubusercontent.com/80251657/149500895-86a29331-95d5-46c8-9efb-938e1ceae3a8.png)

