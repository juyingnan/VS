using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_ArrayCompare
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] a = null;

            int[] b = null;

            Boolean expected = true;

            Boolean actual = ArrayCompare(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] a = null;

            int[] b = { 1 };

            Boolean expected = false;

            Boolean actual = ArrayCompare(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] a = { 1 };

            int[] b = null;

            Boolean expected = false;

            Boolean actual = ArrayCompare(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int[] a = { 1 };

            int[] b = { 1, 2 };

            Boolean expected = false;

            Boolean actual = ArrayCompare(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int[] a = { };

            int[] b = { };

            Boolean expected = true;

            Boolean actual = ArrayCompare(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod6()
        {
            int[] a = { 1 };

            int[] b = { 0 };

            Boolean expected = false;

            Boolean actual = ArrayCompare(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod7()
        {
            int[] a = { 1 };

            int[] b = { 1 };

            Boolean expected = true;

            Boolean actual = ArrayCompare(a, b);

            Assert.AreEqual(expected, actual);
        }

        public Boolean ArrayCompare(int[] a, int[] b)
        {
            if (a == null)
            {
                if (b == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
}
