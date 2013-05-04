using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _24_Point
{
    class _24_point
    {
        public _24_point(int cardNumber, int resultValue)
        {
            this.cardNumber = cardNumber;
            this.resultValue = resultValue;
            number = new double[cardNumber];
            this.result = new string[cardNumber];
        }

        private double threshold = 1e-6;
        private int cardNumber;
        private int resultValue;
        private double[] number;
        private string[] result;

        public void Initialize()
        {
            Random r = new Random();
            for (int i = 0; i < cardNumber; i++)
            {
                number[i] = r.Next(1, 9);
                result[i] = number[i].ToString();
                //Output
                Console.WriteLine("Number " + i + " : " + number[i]);
            }
        }

        public bool PointsGame(int n)
        {
            if (n == 1)
            {
                if (Math.Abs(number[0] - resultValue) < threshold)
                {
                    Console.WriteLine(result[0] + "=" + resultValue);
                    return true;
                }
                else { return false; }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    double a, b;
                    string expa, expb;

                    a = number[i];
                    b = number[j];
                    number[j] = number[n - 1];
                    expa = result[i];
                    expb = result[j];
                    result[j] = result[n - 1];

                    //ADD
                    result[i] = '(' + expa + '+' + expb + ')';
                    number[i] = a + b;
                    if (PointsGame(n - 1))
                        return true;
                    result[i] = '(' + expb + '+' + expa + ')';
                    number[i] = b + a;
                    if (PointsGame(n - 1))
                        return true;

                    //MINUS
                    result[i] = '(' + expa + '-' + expb + ')';
                    number[i] = a - b;
                    if (PointsGame(n - 1))
                        return true;

                    result[i] = '(' + expb + '-' + expa + ')';
                    number[i] = b - a;
                    if (PointsGame(n - 1))
                        return true;

                    //TIMES
                    result[i] = '(' + expa + '*' + expb + ')';
                    number[i] = a * b;
                    if (PointsGame(n - 1))
                        return true;
                    result[i] = '(' + expb + '*' + expa + ')';
                    number[i] = b * a;
                    if (PointsGame(n - 1))
                        return true;

                    //DIVIDE
                    if (a != 0)
                    {
                        result[i] = '(' + expa + '/' + expb + ')';
                        number[i] = a / b;
                        if (PointsGame(n - 1))
                            return true;
                    }
                    if (b != 0)
                    {
                        result[i] = '(' + expb + '/' + expa + ')';
                        number[i] = b / a;
                        if (PointsGame(n - 1))
                            return true;
                    }

                    number[i] = a;
                    number[j] = b;
                    result[i] = expa;
                    result[j] = expb;

                }
            }
            return false;
        }
    }
}
