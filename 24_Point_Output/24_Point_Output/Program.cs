using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24_Point_Output
{
    class Program
    {

        static List<int> AList = new List<int>();

        static void Main(string[] args)
        {
            _24_point p = new _24_point(4, 24);

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            int item = Sorting(new int[] { i, j, k, l });
                            if (Check(item))
                            {
                                AList.Add(item);
                                p.Initialize(new int[] { i, j, k, l });
                                if (p.PointsGame(4))
                                {
                                    Output(item, true);
                                }
                            }
                        }
                    }
                }
            }

            Console.ReadLine();
        }

        private static int Sorting(int[] p)
        {
            int[] original = p;
            int temp;
            for (int i = 0; i < original.Length; i++)
                for (int j = i + 1; j < original.Length; j++)
                {
                    if (original[i] < original[j])
                    {
                        temp = original[j];
                        original[j] = original[i];
                        original[i] = temp;
                    }
                }
            temp = 0;
            int e=1;
            for (int i = 0; i < original.Length; i++)
            {
                temp += original[i] * e;
                e *= 10;
            }
            return temp;
        }

        private static bool Check(int testNumber)
        {
            if (AList.Contains(testNumber))
                return false;
            else return true;
        }

        private static void Output(int item, bool p)
        {
            int temp = item;
            if (p)
            {                
                Console.WriteLine(item);
            }
        }
    }
}
