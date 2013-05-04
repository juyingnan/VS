using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberList = { 4, 3, 5, 6, 8, 1, 2, 7 };
            insertionSort(numberList, numberList.Length);
            foreach (var item in numberList)
            {
                Console.Write(item + ", ");
            }
            Console.ReadLine();

            int[] a = null;
            Console.Write(a.Length.ToString());
            Console.ReadLine();
        }

        public static void insertionSort(int[] numbers, int array_size)
        {
            int i, j, index;

            for (i = 1; i < array_size; i++)
            {
                index = numbers[i];
                j = i;
                while ((j > 0) && (numbers[j - 1] > index))
                {
                    numbers[j] = numbers[j - 1];
                    j = j - 1;
                }
                numbers[j] = index;
            }
        }


    }

    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void insertionSortTest()
        {
            int[] numberList = { 4, 3, 5, 6, 8, 1, 2, 7 };

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };

            Program.insertionSort(numberList, numberList.Length);

            int[] actual = numberList;

            for (int i = 0; i < numberList.Length; i++)
            {
                Assert.AreEqual(numberList[1], expected[i]);
            }
        }
    }
}
