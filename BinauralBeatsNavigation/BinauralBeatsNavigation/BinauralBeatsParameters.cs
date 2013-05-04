using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinauralBeatsNavigation
{
    public class BinauralBeatsParameters
    {
        public enum waveType
        {
            alphaWave = 0,
            betaWave = 1,
            thetaWave = 2,
            deltaWave = 3
        }

        public enum backgroundNoiseType
        {
            none = 0,
            autumnWind = 1,
            calmSea = 2,
            heavyRain = 3,
            hurricane = 4,
            rainForest = 5
        }

        private waveType currentWaveType;

        public waveType CurrentWaveType { get; set; }
        public backgroundNoiseType backroundNoiseType { get; set; }
    }
}
