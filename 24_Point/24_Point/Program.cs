using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            int cardNumber = 4;
            int resultValue = 24;

            _24_point p = new _24_point(cardNumber, resultValue);
            p.Initialize();
            if (p.PointsGame(cardNumber))
            {
                Console.WriteLine("Success.");
            }
            else
            {
                Console.WriteLine("Fail.");
            }
            Console.ReadLine();
        }
    }
}
