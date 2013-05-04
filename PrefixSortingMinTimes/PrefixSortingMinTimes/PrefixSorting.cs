using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrefixSortingMinTimes
{
    class PrefixSorting
    {
        private int[] m_CakeArray;  //烙饼信息数组
        private int m_nCakeCount;   //烙饼个数
        private int m_nMaxSwap;     //最多交换次数=m_nCakeCount*2
        private int[] m_SwapArray;     //交换结果数组
        private int[] m_ReverseCakeArray;   //当前翻转烙饼信息数组
        private int[] m_ReverseCakeArraySwap;   //当前翻转烙饼交换结果数组
        private int m_nSearch;     //当前搜索次数信息
        //statistic information
        public static int minSwap = 0;
        public static int maxSwap = 0;

        public PrefixSorting()
        {
            m_nCakeCount = 0;
            m_nMaxSwap = 0;
        }

        public void Run(int[] pCakeArray, int nCakeCount)
        {
            Init(pCakeArray, nCakeCount);
            m_nSearch = 0;
            Search(0);

            //statistics
            if (minSwap > m_nMaxSwap) minSwap = m_nMaxSwap;
            if (maxSwap < m_nMaxSwap) maxSwap = m_nMaxSwap;
        }

        public void Output()
        {
            ////detail output
            //for (int i = 0; i < m_nMaxSwap; i++)
            //{
            //    Console.Write(m_SwapArray[i] + 1);    //reverse first n+1
            //    Console.Write(" ");
            //}
            //Console.WriteLine();
            //Console.WriteLine("|Search Times| :" + m_nSearch);
            //Console.WriteLine("Total Swap Times = " + m_nMaxSwap);
            Console.Write(m_nMaxSwap + " ");
        }

        public void OutputStatistics()
        {
            Console.WriteLine();
            Console.WriteLine("Max Swap: " + maxSwap);
            Console.WriteLine("Min Swap: " + minSwap);
        }

        private void Search(int step)
        {
            int i;
            int nEstimate;
            m_nSearch++;

            //
            nEstimate = LowerBound(m_ReverseCakeArray, m_nCakeCount);
            if (step + nEstimate > m_nMaxSwap)
                return;

            //
            if (isSorted(m_ReverseCakeArray, m_nCakeCount))
            {
                if (step < m_nMaxSwap)
                {
                    m_nMaxSwap = step;
                    for (i = 0; i < m_nMaxSwap; i++)
                        m_SwapArray[i] = m_ReverseCakeArraySwap[i];
                }
                return;
            }

            //
            for (i = 1; i < m_nCakeCount; i++)
            {
                Reverse(0, i);
                m_ReverseCakeArraySwap[step] = i;
                Search(step + 1);
                Reverse(0, i);
            }
        }

        private void Reverse(int nBegin, int nEnd)
        {
            int i, j, t;
            for (i = nBegin, j = nEnd; i < j; i++, j--)
            {
                t = m_ReverseCakeArray[i];
                m_ReverseCakeArray[i] = m_ReverseCakeArray[j];
                m_ReverseCakeArray[j] = t;
            }
        }

        private bool isSorted(int[] m_ReverseCakeArray, int m_nCakeCount)
        {
            for (int i = 1; i < m_nCakeCount; i++)
            {
                if (m_ReverseCakeArray[i - 1] > m_ReverseCakeArray[i])
                    return false;   //Not Sorted
            }
            return true;    //Sorted
        }

        private int LowerBound(int[] m_ReverseCakeArraySwap, int m_nCakeCount)
        {
            int t;
            int ret = 0;
            for (int i = 1; i < m_nCakeCount; i++)
            {
                t = m_ReverseCakeArraySwap[i] - m_ReverseCakeArraySwap[i - 1];
                if (!(t == 1 || t == -1))
                    ret++;
            }
            return ret;
        }

        private void Init(int[] pCakeArray, int nCakeCount)
        {
            m_nCakeCount = nCakeCount;
            //初始化烙饼数组
            m_CakeArray = new int[m_nCakeCount];
            for (int i = 0; i < m_nCakeCount; i++)
            {
                m_CakeArray[i] = pCakeArray[i];
            }

            //设置最多交换次数信息
            m_nMaxSwap = UpperBound(m_nCakeCount);

            //初始化交换结果数组
            m_SwapArray = new int[m_nMaxSwap + 1];//why +1?

            //初始化中间交换结果信息
            m_ReverseCakeArray = new int[m_nCakeCount];
            for (int i = 0; i < m_nCakeCount; i++)
            {
                m_ReverseCakeArray[i] = m_CakeArray[i];
            }
            m_ReverseCakeArraySwap = new int[m_nMaxSwap + 1];
        }

        private int UpperBound(int m_nCakeCount)
        {
            return m_nCakeCount * 2;
        }
    }
}

