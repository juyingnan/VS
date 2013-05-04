using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;

namespace BinauralBeatsNavigation
{
    class BinauralBeatsWaveOscillator : WaveProvider16
    {
        private double leftPhaseAngle;
        private double rightPhaseAngle;

        public BinauralBeatsWaveOscillator(int sampleRate) :
            base(sampleRate, 2)
        {
        }

        private double leftFrequency;
        private double rightFrequency;
        private short amplitude;

        public double LeftFrequency
        {
            set
            {
                leftFrequency = value;
                isDrawBufferFull = false;
            }
            get { return leftFrequency; }
        }
        public double RightFrequency
        {
            set
            {
                rightFrequency = value;
                isDrawBufferFull = false;
            }
            get { return rightFrequency; }
        }
        public short Amplitude
        {
            set
            {
                amplitude = value;
                isDrawBufferFull = false;
            }
            get { return amplitude; }
        }
        public short[] drawBuffer = new short[drawBufferCapacity];
        private bool isDrawBufferFull = false;
        public BinauralBeatsParameters type = new BinauralBeatsParameters();

        private static short drawBufferCapacity = 8820;

        public override int Read(short[] buffer, int offset,
          int sampleCount)
        {
            for (int index = 0; index < sampleCount; index += 2)
            {
                buffer[offset + index] = (short)(Amplitude * Math.Sin(leftPhaseAngle));
                buffer[offset + index + 1] = (short)(Amplitude * Math.Sin(rightPhaseAngle));

                if (!isDrawBufferFull)
                {
                    drawBuffer[index] = buffer[offset + index];
                    drawBuffer[index + 1] = buffer[offset + index + 1];
                }

                leftPhaseAngle += 2 * Math.PI * LeftFrequency / WaveFormat.SampleRate;
                rightPhaseAngle += 2 * Math.PI * RightFrequency / WaveFormat.SampleRate;

                if (leftPhaseAngle > 2 * Math.PI)
                    leftPhaseAngle -= 2 * Math.PI;
                if (rightPhaseAngle > 2 * Math.PI)
                    rightPhaseAngle -= 2 * Math.PI;
            }
            isDrawBufferFull = true;
            return sampleCount;
        }

        public void bufferClear()
        {
            for (int i = 0; i < drawBuffer.Count(); i++)
            {
                drawBuffer[i] = 0;
            }
            isDrawBufferFull = false;
        }

        public void reset()
        {
            bufferClear();
            this.Amplitude = 0;
            this.LeftFrequency = 0;
            this.rightFrequency = 0;
        }
    }

}
