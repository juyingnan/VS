using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SortingGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] originalNumbers = new int[10];
            for (int i = 0; i < originalNumbers.Length; i++)
            {
                originalNumbers[i] = r.Next(40);
                //for (int j = 0; j < originalNumbers[i]; j++)
                //{
                //    Console.Write("#");
                //}
                //Console.WriteLine();
            }

            //Console.WriteLine("__________________________________________");
            //Console.WriteLine();

            int[] pCake = { 3, 2, 1, 6, 5, 4, 9, 8, 7, 0 };
            int[] solution = { 9,6,9,6,9,6 };

            //Sorting(originalNumbers);
            fixSorting(pCake, solution);
            Console.ReadLine();
        }

        private static void fixSorting(int[] pCake, int[] solution)
        {
            Show(pCake);
            foreach (var item in solution)
            {
                Reverse(0, item, pCake);
                Show(pCake);
            }
        }

        private static void Sorting(int[] originalNumbers)
        {
            Show(originalNumbers);
            for (int i = originalNumbers.Length - 1; i >= 0; i--)
            {
                int maxIndex = FindMax(i, originalNumbers);
                if (i != maxIndex)
                {
                    Reverse(0, maxIndex, originalNumbers);
                    Show(originalNumbers);
                    Reverse(0, i, originalNumbers);
                    Show(originalNumbers);
                }
            }
            Show(originalNumbers);
        }

        private static void Show(int[] originalNumbers)
        {
            const int sleepTime = 1000;
            Thread.Sleep(sleepTime);
            //Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < originalNumbers.Length; i++)
            {
                for (int j = 0; j < originalNumbers[i]; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }

        private static void Reverse(int minIndex, int maxIndex, int[] originalNumbers)
        {
            int i = minIndex;
            int j = maxIndex;
            for (; i < j; i++, j--)
            {
                int temp = originalNumbers[j];
                originalNumbers[j]=originalNumbers[i];
                originalNumbers[i] = temp;
            }
        }

        private static int FindMax(int i, int[] originalNumbers)
        {
            int maxIndex=0;
            int count=0;
            do
            {
                if (originalNumbers[maxIndex] < originalNumbers[count])
                    maxIndex = count;
            } while (++count <= i);
            return maxIndex;
        }
    }
}
