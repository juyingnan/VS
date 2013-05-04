using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SignCalculator
{
    class Price
    {
        public string type;
        public string width;
        public string height;
        public double price;
        public string[] buffer = new string[4];

        public void DataAssign()
        {
            type = buffer[0];
            width = buffer[1];
            height = buffer[2];
            price = Convert.ToDouble(buffer[3]);
        }
    }
}
