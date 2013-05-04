using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DataBindingTest
{
    class Person : INotifyPropertyChanged
    {
        public Person() { }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name == value)
                    return;
                this.name = value;
                Notify("Name");
            }
        }

        int age;
        public int Age
        {
            get { return this.age; }
            set
            {
                if (this.age == value)
                    return;
                this.age = value;
                Notify("Age");
            }
        }

        //InotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            { PropertyChanged(this, new PropertyChangedEventArgs(propName)); }
        }
    }

    class People : ObservableCollection<Person> { }
}
