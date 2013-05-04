using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarViewApp
{
    public class Car
    {
        public int Speed { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
        public string PetName { get; set; }
       
        public Car(int speed, string make, string color, string name)
        {
            Speed = speed; Make = make; Color = color; PetName = name;
        }
        public Car()
        {
        }     

        public override string ToString()
        {
            return string.Format("{0} the {1} {2} is going {3} MPH",
              PetName, Color, Make, Speed);
        }
    }
}
