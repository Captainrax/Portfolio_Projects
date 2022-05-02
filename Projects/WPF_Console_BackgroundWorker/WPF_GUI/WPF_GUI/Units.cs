using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WPF_GUI
{
    // Object used with program
    interface IInterface
    {
        string Name { get; set; }
        int Age { get; set; }
        string ClassName { get; set; }
        int Serial { get; set; }
    }

    public class Unit : IInterface
    {
        public string ClassName { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Serial { get; set; }

        // Constructor
        public Unit(String Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }

    public class Human : Unit
    {
        public Human(String Name, int Age) : base(Name, Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        // do unique stuff only humans can do
    }

    public class Dragon : Unit
    {
        public Dragon(String Name, int Age) : base(Name, Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        // do unique stuff only dragons can do
    }
}
