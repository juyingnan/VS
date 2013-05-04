using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CarViewApp
{
    public class CarList:ObservableCollection<Car>
    {
        public CarList()
        {
            // Add a few entries to the CarList object.
            Add(new Car(40, "BMW", "Black", "Sidd"));
            Add(new Car(55, "VW", "Black", "Mary"));
            Add(new Car(100, "Ford", "Tan", "Mel"));
            Add(new Car(0, "Yugo", "Green", "Clunker"));
        }
    }
}
