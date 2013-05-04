using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorOptical
{
    class Program
    {
        static void Main(string[] args)
        {
            // input people for each floor
            // from 2nd floor to top floor
            // top floor is length of nPerson + 1
            int[] nPerson = { 4, 3, 5, 7, 4, 3, 6, 2 };
            int[] result = new int[2];
            int stamineFactor = 3;
            //Normal
            //result = Cal(nPerson);
            //Better
            //result = BetterCal(nPerson);
            //Question 1
            //result = ConditionBetterCal(nPerson, stamineFactor);
            // Question2
            int stop = 3;
            result = OpticalCal(nPerson, stop, stamineFactor);


            /////////////////////
            //Console.WriteLine();
            //Console.WriteLine("Final stop floor is: " + result[0]);
            //Console.WriteLine("Final total floor is: " + result[1]);

            //////////////////////                        
            Console.ReadLine();
        }

        private static int[] OpticalCal(int[] nPerson, int stop, int stamineFactor)
        {
            List<int> l = new List<int>();
            for (int i = 2; i <= nPerson.Length + 1; i++)
            {
                l.Add(i);
            }
            Combination c = new Combination(l, stop);
            c.GenerateCombination();
            // optical floors need
            int bestTotal = stamineFactor * (nPerson.Length + 1) * nPerson.Max();
            int[] nFinalBestStop = new int[stop];
            foreach (var item in c.outputNumberArray)
            {
                //MAX C SELECT, each case

                ///////////
                //Output each case
                Console.Write("Stop @: ");
                foreach (var n in item)
                {
                    Console.Write(n + ",");
                }
                Console.WriteLine();
                ///////////

                //stop @ for each floor
                int[] nBestStop = new int[nPerson.Length];
                //total floors need for this case
                int totalFloors = 0;
                //Looking for best stop for each floor
                for (int j = 2; j <= nPerson.Length + 1; j++)
                {
                    int floorsOnBestFloor = stamineFactor * (nPerson.Length + 1);
                    foreach (var i in item)
                    {
                        int temp = (i > j) ? stamineFactor * (i - j) : j - i;
                        if (temp < floorsOnBestFloor)
                        {
                            floorsOnBestFloor = temp;
                            nBestStop[j - 2] = i;
                        }
                    }
                    //Calculate minimum floors need
                    totalFloors += floorsOnBestFloor * nPerson[j - 2];
                }

                //////////
                Console.Write("From Floor 2 to " + nPerson.Length + ": ");
                foreach (var n in nBestStop)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Total Floors need in this case: " + totalFloors);
                Console.WriteLine();
                ///////////

                if (totalFloors < bestTotal)
                {
                    bestTotal = totalFloors;
                    nFinalBestStop = item;
                }
            }

            /////////////////
            Console.Write("Final Solution is: ");
            foreach (var item in nFinalBestStop)
            {
                Console.Write(item + ",");
            }
            Console.WriteLine();
            Console.WriteLine("Final Floor need is: " + bestTotal);
            /////////////////
            int[] result = { 0, bestTotal };
            return result;
        }

        private static int[] BetterCal(int[] nPerson)
        {
            // top floor is length of nPerson + 1
            int topFloor = nPerson.Length + 1;
            int minFloor = nPerson.Max() * topFloor * topFloor;
            int targetFloor = 1;
            int tempTotalFloor = 0;
            int differenceBetweenCases = 0;
            for (int i = 2; i <= topFloor; i++)
            {
                //if no elevator, the total floors need from 1st floor
                tempTotalFloor += nPerson[i - 2] * (i - 1);
                differenceBetweenCases += nPerson[i - 2];
            }

            for (int i = 2; i <= topFloor; i++)
            {
                tempTotalFloor -= differenceBetweenCases;
                //difference between cases is double nPerson[i - 2]
                differenceBetweenCases -= 2 * nPerson[i - 2];
                //////////////////////
                Console.WriteLine("stop floor is: " + i);
                Console.WriteLine("Total floor is: " + tempTotalFloor);
                //////////////////////                
                if (tempTotalFloor < minFloor)
                {
                    minFloor = tempTotalFloor;
                    targetFloor = i;
                }
            }
            int[] result = { targetFloor, minFloor };
            return result;
        }

        private static int[] ConditionBetterCal(int[] nPerson, int k)
        {
            //stamine of upstairs is k times downstairs

            // top floor is length of nPerson + 1
            int topFloor = nPerson.Length + 1;
            int minFloor = nPerson.Max() * topFloor * topFloor;
            int targetFloor = 1;
            int tempTotalFloor = 0;
            int differenceBetweenCases = 0;
            for (int i = 2; i <= topFloor; i++)
            {
                //if no elevator, the total floors need from 1st floor
                tempTotalFloor += nPerson[i - 2] * (i - 1) * k;
                differenceBetweenCases += nPerson[i - 2] * k;
            }

            for (int i = 2; i <= topFloor; i++)
            {
                tempTotalFloor -= differenceBetweenCases;
                //difference between cases is (k+1) times nPerson[i - 2]
                differenceBetweenCases -= (k + 1) * nPerson[i - 2];
                //////////////////////
                Console.WriteLine("stop floor is: " + i);
                Console.WriteLine("Total floor is: " + tempTotalFloor);
                //////////////////////                
                if (tempTotalFloor < minFloor)
                {
                    minFloor = tempTotalFloor;
                    targetFloor = i;
                }
            }
            int[] result = { targetFloor, minFloor };
            return result;
        }

        private static int[] Cal(int[] nPerson)
        {
            // top floor is length of nPerson + 1
            int topFloor = nPerson.Length + 1;
            int minFloor = nPerson.Max() * topFloor * topFloor;
            int targetFloor = 1;
            int tempTotalFloor = 0;

            for (int i = 2; i <= topFloor; i++)
            {
                tempTotalFloor = 0;
                for (int j = 2; j <= topFloor; j++)
                {
                    tempTotalFloor += nPerson[j - 2] * Math.Abs((j - i));
                }
                //////////////////////
                Console.WriteLine("stop floor is: " + i);
                Console.WriteLine("Total floor is: " + tempTotalFloor);
                //////////////////////
                if (tempTotalFloor < minFloor)
                {

                    minFloor = tempTotalFloor;
                    targetFloor = i;
                }
            }
            int[] result = { targetFloor, minFloor };
            return result;
        }
    }
}
