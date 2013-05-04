using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixReversal
{
    class Program
    {
        static void Main(string[] args)
        {
            PrefixSorting p = new PrefixSorting();
            int[] pCake = { 5,3,2,4,6,1,7 };
            p.Run(pCake, pCake.Length);
            p.Output();
            Console.ReadLine();
        }
    }
}
