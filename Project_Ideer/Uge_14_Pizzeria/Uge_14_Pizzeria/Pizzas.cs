using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Uge_14_Pizzeria
{
    // Object used with program
    public interface IFoodItem
    {
        public string Type { get; set; }
        string Name { get; set; }
        int Serial { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public int GetPrice { get; }
    }

    public class Pizza : IFoodItem
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public int Price { get; set; }
        public int Serial { get; set; }

        // Constructor
        public Pizza(String Name)
        {
            this.Name = Name;
        }
        public string GetIngredients
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
        public int GetPrice
        {
            get{
                int allingredients = Price;
                foreach (Ingredient I in Ingredients)
                {
                    allingredients += I.Price;
                }
                return allingredients;
            }
        }
        public void UpdatePrice()
        {
            int updatedprice = 0;
            foreach (Ingredient I in Ingredients)
            {
                updatedprice += I.Price;
            }
            Price = updatedprice;
        }
    }
    // Ingredients for Pizza
    public class Ingredient
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        static int NextId;
        public int IngredientID { get; private set; }
        // Constructor
        public Ingredient()
        {
            // new ID everytime the constructor is called
            IngredientID = Interlocked.Increment(ref NextId);
        }

    }
    // Drinks
    public class Drink : IFoodItem
    {
        // ToDo implement Ingredients list for Different Sizes
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public int Serial { get; set; }

        // Constructor
        public Drink(String Name)
        {
            this.Name = Name;
        }

        public int GetPrice
        {
            get
            {
                return Price;
            }
        }
    }
}
