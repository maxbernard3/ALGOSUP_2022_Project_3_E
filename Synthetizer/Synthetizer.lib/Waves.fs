namespace Synthetizer.lib

namespace Synth
module Waves =
        open System
        
        let pi = Math.PI
        let sampleRate = 44100 // In Hertz
        
        let sinWave frequence amplitude t  =
            amplitude * sin (2. * pi * float t * frequence / float sampleRate)

        let sawWave frequence amplitude t  =
            2. * amplitude * (float t * frequence/float sampleRate - floor (0.5 +  float t * frequence/float sampleRate))

        let squareWave frequence amplitude t  =
            amplitude * float (sign (sin (2. * pi * float t * frequence/float sampleRate)))

        let triangleWave frequence amplitude t  =
            2. * amplitude * asin (sin (2. * pi * float t * frequence/float sampleRate)) / pi
        