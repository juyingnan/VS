using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SortingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] originalNumbers = new int[10];
            int counter = 10;
            int swapCounter = 0;
            while (counter > 0)
            {
                InitialNumbers(originalNumbers);
                swapCounter = Sorting(originalNumbers);
                OutputNumbers(originalNumbers, swapCounter);
                --counter;
            }
            Console.ReadLine();
        }

        private static void OutputNumbers(int[] originalNumbers, int swapCounter)
        {
            Console.WriteLine("Sorting Numbers are:");
            for (int i = 0; i < originalNumbers.Length; i++)
            {
                Console.Write(originalNumbers[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.Write("Swaping times: ");
            Console.WriteLine(swapCounter);
            Console.WriteLine();
        }

        private static int Sorting(int[] originalNumbers)
        {
            int swapCounter = 0;
            DateTime startTime = System.DateTime.Now;
            for (int i = 0; i < originalNumbers.Length; i++)
            {
                for (int j = i; j < originalNumbers.Length; j++)
                {
                    if (originalNumbers[i] > originalNumbers[j])
                    {
                        swap(originalNumbers, i, j);
                        swapCounter++;
                    }
                }
            }
            System.TimeSpan peroid = DateTime.Now.Subtract(startTime);
            Console.WriteLine(peroid);
            return swapCounter;
        }

        private static void swap(int[] originalNumbers, int i, int j)
        {
            int temp;
            temp = originalNumbers[i];
            originalNumbers[i] = originalNumbers[j];
            originalNumbers[j] = temp;
            Thread.Sleep(1);
        }

        private static void InitialNumbers(int[] originalNumbers)
        {
            Console.WriteLine("Original Numbers are:");
            Random r = new Random(GetRandomSeed());
            for (int i = 0; i < originalNumbers.Length; i++)
            {
                originalNumbers[i] = r.Next(100);
                Console.Write(originalNumbers[i]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        static int GetRandomSeed()      //get a random seed
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
}
