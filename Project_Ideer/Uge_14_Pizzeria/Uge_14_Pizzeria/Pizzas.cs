using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Uge_14_Pizzeria
{
    // Object used with program
    public interface IFoodItem
    {
        public string Type { get; set; }
        string Name { get; set; }
        int Serial { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public int GetPrice();
    }

    public class Pizza : IFoodItem
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool SizeSmall { get; set; }
        public bool SizeLarge { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public string GetIngredients { get; }
        public int Price { get; set; }
        public int Serial { get; set; }

        // Constructor
        public Pizza(String Name, bool SizeSmall, bool SizeLarge)
        {
            this.Name = Name;
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
        public void SetSize()
        {
            // somehow set bool sizes when changing combobox selected when adding to checkOutList
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
    // Ingredients for Pizza
    public class Ingredient
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
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

        public int GetPrice()
        {
            return Price;
        }
    }
}
