using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_UI
{
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
        //public string Fooditem;

        // Constructor
        public Unit(String Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
        

        //public String Eat(String Fooditem)
        //{
        //    this.Fooditem = Fooditem;
        //    String result = Name + " is eating " + Fooditem;
        //    Console.WriteLine(result);
        //    return result;
        //}
    }

    public class Human : Unit
    {
        public Human(String Name, int Age) : base(Name, Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        // do unique stuff only humans can do

        //public String Eat(String Fooditem, String Fooditem2)
        //{
        //    this.Fooditem = Fooditem;
        //    String result = Name + " is eating " + Fooditem + " and " + Fooditem2;
        //    Console.WriteLine(result);
        //    return result;
        //}

        //int add;
        //public int AddNumbers(int add)
        //{
        //    this.add = add;
        //    Console.WriteLine("Count: " + Math(add));
        //    return Math(add);
        //}
        //public int AddNumbers(int add, int add2)
        //{
        //    this.add = add + add2;
        //    Console.WriteLine("Count: " + this.add);
        //    return this.add;
        //}
        //int num1;
        //private int Math(int num1)
        //{
        //    this.num1 = num1;
        //    return num1 + 2;
        //}

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
