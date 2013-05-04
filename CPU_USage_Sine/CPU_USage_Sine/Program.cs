using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CPU_USage_Sine
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread threadOne;
            Thread threadTwo;
            Thread threadThree;
            Thread threadFour;
            threadOne = new Thread(new ThreadStart(Run));
            threadTwo = new Thread(new ThreadStart(Run));
            threadThree = new Thread(new ThreadStart(Run));
            threadFour = new Thread(new ThreadStart(Run));
            threadOne.Start();
            threadTwo.Start();
            threadThree.Start();
            threadFour.Start();
        }

        private static void Run()
        {
            const int SAMPLING_COUNT = 200;
            const int TOTAL_AMPLITUDE = 300;    //300 is a proper number. 1000 or 100 will make CPU not go down to near 0%.
            double[] busyspan = new double[SAMPLING_COUNT];
            int amplitude = TOTAL_AMPLITUDE / 2;
            double radian = 0;
            double radianIncrement = 2.0 / SAMPLING_COUNT;
            double startTime;
            for (int i = 0; i < SAMPLING_COUNT; i++)
            {
                busyspan[i] = amplitude + Math.Sin(Math.PI * radian) * amplitude;
                radian += radianIncrement;
            }

            for (int i = 0; ; i = (++i) % SAMPLING_COUNT)
            {
                startTime = System.Environment.TickCount;
                while (System.Environment.TickCount - startTime <= busyspan[i]) ;
                Console.WriteLine();
                Thread.Sleep((int)(TOTAL_AMPLITUDE - busyspan[i]));
            }
        }
    }
}
