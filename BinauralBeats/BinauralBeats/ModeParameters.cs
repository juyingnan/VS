using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace BinauralBeats
{
    class sweepFrequencyModeParameters
    {
        public sweepFrequencyModeParameters()
        {
            minFrequency = 20;
            maxFrequency = 20000;
            isSweepFrequencyModeOn = false;
            isSweepFrequencyPlus = true;
        }

        private double minFrequency;
        private double maxFrequency;
        private double currentFrequency;
        private int sweepFrequencySpeed;
        public bool isSweepFrequencyModeOn;
        public bool isSweepFrequencyPlus;

        public double MinFrequency
        {
            get { return minFrequency; }
            set
            {
                if (value <= 20000 && value >= 20)
                {
                    minFrequency = value;
                }
                else
                {
                    value = 20;
                }
            }
        }

        public double MaxFrequency
        {
            get { return maxFrequency; }
            set
            {
                if (value <= 20000 && value >= 20)
                {
                    maxFrequency = value;
                }
                else
                {
                    value = 20000;
                }
            }
        }

        public double CurrentFrequency
        {
            get { return currentFrequency; }
            set
            {
                if (value >= maxFrequency)
                {
                    currentFrequency = maxFrequency;
                    isSweepFrequencyPlus = false;
                }
                else if (value <= minFrequency)
                {
                    currentFrequency = minFrequency;
                    isSweepFrequencyPlus = true;
                }
                else
                    currentFrequency = value;
            }
        }
        

        public int SweepFrequencySpeed
        {
            get { return sweepFrequencySpeed; }
            set
            {
                if (value >= 10 && value <= 180)
                {
                    sweepFrequencySpeed = value;
                }
                else
                    sweepFrequencySpeed = 100;
            }
        }
    }

    class binauralBeatsModeParemeters
    {
        private double leftFrequency;
        private double rightFrequency;
        private double differenceFrequency;

        public double LeftFrequency
        {
            get { return leftFrequency; }
            set
            {
                if (value <= 20000 && value >= 20)
                {
                    leftFrequency = value;
                }
                else
                {
                    leftFrequency = 100;
                }
                differenceFrequency = rightFrequency - leftFrequency;
            }
        }

        public double RightFrequency
        {
            get { return rightFrequency; }
            set
            {
                if (value <= 20000 && value >= 20)
                {
                    rightFrequency = value;
                }
                else
                {
                    rightFrequency = 103;
                }
                differenceFrequency = rightFrequency - leftFrequency;
            }
        }
    }
}
