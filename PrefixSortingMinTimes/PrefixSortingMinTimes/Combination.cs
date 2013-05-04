using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixSortingMinTimes
{
    class Permutation
    {
        public Permutation(List<int> Input)
        {
            MAX = Input.Count;
            result = new int[MAX];
            originalInput.AddRange(Input);
            outputNumberArray = new int[ladderMultiply(MAX)][];
            for (int i = 0; i < ladderMultiply(MAX); i++)
            {
                outputNumberArray[i] = new int[MAX];
            }
        }

        private int MAX;
        private int[] result;
        public List<int> originalInput= new List<int>();
        public int[][] outputNumberArray;

        //test
        public int count = 0;


        private static int ladderMultiply(int n)
        {
            if (n == 1 || n == 0) return 1;
            else return n * ladderMultiply(n - 1);
        }

        public void GenerateCombination()
        {
            proc(originalInput);
        }

        private void proc(List<int> Input)
        {
            if (Input.Count == 1)
            {
                result[MAX - Input.Count] = Input[0];
                OutputToArray();
                //tets
                //print(result);
            }

            else
            {
                foreach (var item in Input)
                {
                    List<int> tempInput = new List<int>();
                    tempInput.AddRange(Input);
                    result[MAX - Input.Count] = item;
                    tempInput.Remove(item);
                    proc(tempInput);
                }
            }
        }

        private void OutputToArray()
        {
            result.CopyTo(outputNumberArray[count++], 0);
        }

        private void print(int[] result)
        {
            foreach (var item in result)
            {
                Console.Write(item + "");
            }
            Console.WriteLine();
            //test
            //count++;
        }
    }
}
