# Software Architecture
Our software will be organized into two-layer for clarity. Most of the calculations will be in a library, and most of the input and output will be made in a dotnet console app. We are using dotnet for its readily available testing functionality and its built-in math library.

The inputs are made by calling a function corresponding to a wave, passing along frequency, amplitude, effect(s), and duration. the return from the inputs should be put in a list that will then be given to another function that will generate a .mp3 from all the waves in sequence as well as play said music from the computer

#
the folowing diagram show how we intend diferent function and file to comunicate

![Software Architecture(1)](https://user-images.githubusercontent.com/80251657/149500895-86a29331-95d5-46c8-9efb-938e1ceae3a8.png)

