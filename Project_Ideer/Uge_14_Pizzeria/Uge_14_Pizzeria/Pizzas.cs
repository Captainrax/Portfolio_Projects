using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Uge_14_Pizzeria
{
    // Object used with program
    interface IPizza
    {
        string PizzaName { get; set; }
        bool SizeSmall { get; set; }
        bool SizeLarge { get; set; }
        int Serial { get; set; }
    }

    public class Pizza : IPizza
    {
        public string PizzaName { get; set; }
        public bool SizeSmall { get; set; }
        public bool SizeLarge { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public string GetIngredients { get; }
        public int Price { get; set; }
        public int Serial { get; set; }

        // Constructor
        public Pizza(String PizzaName, bool SizeSmall, bool SizeLarge)
        {
            this.PizzaName = PizzaName;
            this.SizeSmall = SizeSmall;
            this.SizeLarge = SizeLarge;
        }
        public string Getingredients
        {
            get{
                string allingredients = "";
                foreach (Ingredient I in Ingredients)
                {
                    allingredients += I.Name + ", ";
                }
                return allingredients;
            }
        }

        public int GetPrice()
        {
            int allingredients = Price;
            foreach (Ingredient I in Ingredients)
            {
                allingredients += I.Price;
            }
            return allingredients;
        }
    }
    public class Ingredient
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

}
