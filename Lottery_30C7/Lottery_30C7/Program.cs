using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lottery_30C7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> l = new List<int>();
            for (int i = 1; i <= 23; i++)
            {
                l.Add(i);
            }
            Combination c = new Combination(l, 5);
            c.GenerateCombination();

            Console.ReadLine();
        }
    }
}
