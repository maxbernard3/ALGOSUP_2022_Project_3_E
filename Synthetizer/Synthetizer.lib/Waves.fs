namespace Synthetizer.lib
    module Waves =
  
        open System
        let sampleRate = GlobalVar.sampleRate

        let sinWave frequence amplitude t  =
            amplitude * sin (2. * Math.PI * float t * frequence / float sampleRate)

        let sawWave frequence amplitude t =
            2. * amplitude * (float t * frequence/float sampleRate - floor (0.5 +  float t * frequence/float sampleRate))

        let squareWave frequence amplitude t =
            amplitude * float (sign (sin (2. * Math.PI * float t * frequence/float sampleRate)))

        let triangleWave frequence amplitude t =
            2. * amplitude * asin (sin (2. * Math.PI * float t * frequence/float sampleRate)) / Math.PI
    
        
