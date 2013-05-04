using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorOptical
{
    class Combination
    {
        public Combination(List<int> Input, int n)
        {
            MAX = Input.Count;
            SELECT = n;
            result = new int[SELECT];
            originalInput.AddRange(Input);
            AMOUNT = ladderMultiply(MAX) / ladderMultiply(MAX - SELECT) / ladderMultiply(SELECT);
            outputNumberArray = new int[AMOUNT][];
            for (int i = 0; i < AMOUNT; i++)
            {
                outputNumberArray[i] = new int[SELECT];
            }
        }

        private int MAX, SELECT, AMOUNT;
        private int[] result;
        public List<int> originalInput = new List<int>();
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
            proc(originalInput,0);
        }

        private void proc(List<int> Input, int step)
        {
            if (Input.Count < 1 || SELECT - step > Input.Count)
                return;
            if (step == SELECT - 1)
            {
                foreach (var item in Input)
                {
                    result[step] = item;
                    OutputToArray();
                    //tets
                    //print(result);
                }                
            }

            else
            {
                foreach (var item in Input)
                {
                    List<int> tempInput = new List<int>();
                    tempInput.AddRange(Input);
                    result[step] = item;
                    tempInput.RemoveRange(0, tempInput.IndexOf(item) + 1);
                    proc(tempInput, step + 1);
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
