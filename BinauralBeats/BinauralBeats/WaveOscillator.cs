using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;

namespace BinauralBeats
{
    class SineWaveOscillator : WaveProvider16
    {
        double phaseAngle;

        public SineWaveOscillator(int sampleRate) :
            base(sampleRate, 2)
        {
        }

        public double Frequency { set; get; }
        public short Amplitude { set; get; }

        public override int Read(short[] buffer, int offset,
          int sampleCount)
        {

            for (int index = 0; index < sampleCount; index++)
            {
                buffer[offset + index] =
                  (short)(Amplitude * Math.Sin(phaseAngle));
                phaseAngle +=
                  2 * Math.PI * Frequency / WaveFormat.SampleRate;

                if (phaseAngle > 2 * Math.PI)
                    phaseAngle -= 2 * Math.PI;
            }
            return sampleCount;
        }
    }

    class WaveOscillator : WaveProvider16
    {
        double phaseAngle;

        public WaveOscillator(int sampleRate) :
            base(sampleRate, 2)
        {
        }

        private double frequency;
        private short amplitude;

        public double Frequency
        {
            set
            {
                frequency = value;
                isDrawBufferFull = false;
            }
            get { return frequency; }
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
        public waveType currentType { set; get; }
        public short[] drawBuffer = new short[drawBufferCapacity];
        private bool isDrawBufferFull = false;
        public enum waveType
        {
            zero = 0,
            SineWave = 1,
            triangleWave = 2,
            rectangleWave = 3,
            whiteNoiseWave = 4
        }

        private static short drawBufferCapacity = 8820;

        public override int Read(short[] buffer, int offset,
          int sampleCount)
        {

            switch (currentType)
            {
                case waveType.SineWave:
                    {
                        for (int index = 0; index < sampleCount; index++)
                        {
                            buffer[offset + index] =
                              (short)(Amplitude * Math.Sin(phaseAngle));
                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                            phaseAngle +=
                              2 * Math.PI * Frequency / WaveFormat.SampleRate;

                            if (phaseAngle > 2 * Math.PI)
                                phaseAngle -= 2 * Math.PI;
                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.triangleWave:
                    {
                        for (int index = 0; index < sampleCount; index++)
                        {
                            buffer[offset + index] =
                              (short)(Amplitude * phaseAngle);
                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                            //why 2 here?
                            phaseAngle += 2 * Frequency / WaveFormat.SampleRate;

                            if (phaseAngle > 1)
                                phaseAngle -= 2;
                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.rectangleWave:
                    {
                        for (int index = 0; index < sampleCount; index++)
                        {
                            buffer[offset + index] =
                                (short)(Amplitude * (phaseAngle > 0 ? 1 : -1));
                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                            phaseAngle += 2 * Frequency / WaveFormat.SampleRate;

                            if (phaseAngle > 1)
                                phaseAngle -= 2;
                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.whiteNoiseWave:
                    {
                        int randomMaxValue = 1000;
                        int halfRandomMaxValue = randomMaxValue / 2;
                        int doubleRandomMaxValue = randomMaxValue * 2;
                        Random r = new Random();
                        for (int index = 0; index < sampleCount; index++)
                        {
                            buffer[offset + index] =
                                (short)((double)Amplitude * (double)(r.Next(randomMaxValue) - halfRandomMaxValue) / doubleRandomMaxValue);
                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.zero:
                    break;
                default:
                    this.currentType = waveType.zero;
                    break;
            }
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
            this.Frequency = 0;
        }
    }

    class BinauralBeatsWaveOscillator : WaveProvider16
    {
        double leftPhaseAngle;
        double rightPhaseAngle;

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
        public waveType currentType { set; get; }
        public short[] drawBuffer = new short[drawBufferCapacity];
        private bool isDrawBufferFull = false;
        public enum waveType
        {
            zero = 0,
            SineWave = 1,
            triangleWave = 2,
            rectangleWave = 3,
            whiteNoiseWave = 4
        }

        private static short drawBufferCapacity = 8820;

        public override int Read(short[] buffer, int offset,
          int sampleCount)
        {

            switch (currentType)
            {
                case waveType.SineWave:
                    {
                        for (int index = 0; index < sampleCount; index+=2)
                        {
                            buffer[offset + index] =
                              (short)(Amplitude * Math.Sin(leftPhaseAngle));
                            buffer[offset + index+1] =
                              (short)(Amplitude * Math.Sin(rightPhaseAngle));

                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                            leftPhaseAngle +=
                              2 * Math.PI * LeftFrequency / WaveFormat.SampleRate;
                            rightPhaseAngle +=
                              2 * Math.PI * RightFrequency / WaveFormat.SampleRate;

                            if (leftPhaseAngle > 2 * Math.PI)
                                leftPhaseAngle -= 2 * Math.PI;
                            if (rightPhaseAngle > 2 * Math.PI)
                                rightPhaseAngle -= 2 * Math.PI;

                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.triangleWave:
                    {
                        for (int index = 0; index < sampleCount; index++)
                        {
                            buffer[offset + index] =
                              (short)(Amplitude * leftPhaseAngle);
                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                            //why 2 here?
                            leftPhaseAngle += 2 * LeftFrequency / WaveFormat.SampleRate;

                            if (leftPhaseAngle > 1)
                                leftPhaseAngle -= 2;
                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.rectangleWave:
                    {
                        for (int index = 0; index < sampleCount; index++)
                        {
                            buffer[offset + index] =
                                (short)(Amplitude * (leftPhaseAngle > 0 ? 1 : -1));
                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                            leftPhaseAngle += 2 * LeftFrequency / WaveFormat.SampleRate;

                            if (leftPhaseAngle > 1)
                                leftPhaseAngle -= 2;
                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.whiteNoiseWave:
                    {
                        int randomMaxValue = 1000;
                        int halfRandomMaxValue = randomMaxValue / 2;
                        int doubleRandomMaxValue = randomMaxValue * 2;
                        Random r = new Random();
                        for (int index = 0; index < sampleCount; index++)
                        {
                            buffer[offset + index] =
                                (short)((double)Amplitude * (double)(r.Next(randomMaxValue) - halfRandomMaxValue) / doubleRandomMaxValue);
                            if (!isDrawBufferFull)
                            {
                                drawBuffer[index] = buffer[offset + index];
                            }
                        }
                        isDrawBufferFull = true;
                        break;
                    }
                case waveType.zero:
                    break;
                default:
                    this.currentType = waveType.zero;
                    break;
            }
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
        }
    }

}
