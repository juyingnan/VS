using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixSortingMinTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int pCakeNumber = 7;
            MinTimesTry(pCakeNumber);
            Console.ReadLine();
        }

        private static void MinTimesTry(int pCakeNumber)
        {
            //time
            float startTime = System.Environment.TickCount;
            //time
            
            List<int> originalNumberArray = pCakeArrayInitialize(pCakeNumber);
            Permutation c = new Permutation(originalNumberArray);
            c.GenerateCombination();

            //time
            Console.WriteLine("Combination Generation Time: "+(System.Environment.TickCount- startTime));
            startTime = System.Environment.TickCount;
            //time

            PrefixSorting p = new PrefixSorting();
            //
            int count = 0;
            int persent=0;
            foreach (var item in c.outputNumberArray)
            {
                p.Run(item, pCakeNumber);
                //p.Output();
                //
                count++;
                while (count * 100 >= c.outputNumberArray.Count())
                {
                    Console.WriteLine(++persent+"%");
                    count = 0;
                }
            }
            p.OutputStatistics();

            //time
            Console.WriteLine("SortingStatistic Time: " + (System.Environment.TickCount - startTime));
            //time
        }

        private static List<int> pCakeArrayInitialize(int pCakeNumber)
        {
            List<int> originalNumberArray = new List<int>();
            for (int i = 1; i <= pCakeNumber; i++)
                originalNumberArray.Add(i);
            return originalNumberArray;
        }

    }
}
