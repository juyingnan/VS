using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_InsertionSort
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] number = { 1 };   // INPUT

            int[] expectedArray = { 1 };    //EXPECTED OUTPUT

            InsertionSort.insertionSort(number, 1); //EXECUTION

            Boolean expected = true;    //THESE TWO ARRAYS ARE EXPECTED TO BE EQUAL

            //COMPARE TWO ARRAYS
            Boolean actual = ArrayFunction.ArrayCompare(number, expectedArray);

            //SHOW THE RESULT
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] number = { 1,2 };

            int[] expectedArray = { 1,2 };

            InsertionSort.insertionSort(number, 2);

            Boolean expected = true;

            Boolean actual = ArrayFunction.ArrayCompare(number, expectedArray);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod4()
        {
            int[] number = { 2,1 };

            int[] expectedArray = { 1,2};

            InsertionSort.insertionSort(number, 2);

            Boolean expected = true;

            Boolean actual = ArrayFunction.ArrayCompare(number, expectedArray);

            Assert.AreEqual(expected, actual);
        }

    }

    public class ArrayFunction
    {
        static public Boolean ArrayCompare(int[] a, int[] b)
        {
            if (a == null)
            {
                if (b == null)
                {
                    return true;
                }
                else return false;
            }
            else
            {
                if (b == null)
                {
                    return false;
                }
                else
                {
                    if (a.Length == b.Length)
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[i] != b[i])
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }

    public class InsertionSort
    {
        static public void insertionSort(int[] numbers, int array_size)
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
}
