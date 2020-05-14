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
        public ObservableCollection<int> Price { get; set; }

        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public int GetPrice { get; }
        public void SaveIngredients();
        public void LoadIngredients();
        public bool DiscountApplied { get; set; }
    }

    public class Pizza : IFoodItem
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public ObservableCollection<Ingredient> SavedIngredients { get; set; }
        public bool DiscountApplied { get; set; }
        public ObservableCollection<int> Price { get; set; }
        public int Serial { get; set; }

        // Constructor
        public Pizza(String Name)
        {
            this.Name = Name;
            this.SavedIngredients = new ObservableCollection<Ingredient>();
            this.Price = new ObservableCollection<int>();
        }
        public string GetIngredients // for display in datatemplates
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
        public int GetPrice // for updating the price because the databinding dosnt wanna do it...
        {
            get{
                int allingredients = 0;
                foreach (Ingredient I in Ingredients)
                {
                    allingredients += I.Price;
                }

                return allingredients;
            }
        }
        public int UpdatePrice
        {
            get{
                int updatedprice = 0;
                foreach (Ingredient I in Ingredients)
                {
                    updatedprice += I.Price;
                }
                Price[0] = updatedprice;
                return updatedprice;
            }
        }
        public void SaveIngredients() // saves current ingredients
        {
            SavedIngredients.Clear();
            foreach (Ingredient I in Ingredients)
            {
                Ingredient Temp = new Ingredient() { Name = I.Name, Price = I.Price, Type = I.Type }; // creates new instances of ingredients, incase Original gets deleted.
                SavedIngredients.Add(Temp);
            }
        }
        public void LoadIngredients() // loads saved ingredients
        {
            Ingredients.Clear();
            foreach (Ingredient I in SavedIngredients)
            {
                Ingredient Temp = new Ingredient() { Name = I.Name, Price = I.Price, Type = I.Type };
                Ingredients.Add(Temp);
            }
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
        public ObservableCollection<int> Price { get; set; }
        // probably dosnt need an ingredient list
        public ObservableCollection<Ingredient> Ingredients { get; set; }
        public int Serial { get; set; }

        // Constructor
        public Drink(String Name)
        {
            this.Name = Name;
            this.Price = new ObservableCollection<int>();
        }

        public int GetPrice
        {
            get
            {
                return Price[0];
            }
        }
        // these probably arent needed here unless i decide to make custom drinks(?)
        public bool DiscountApplied { get; set; }
        public void SaveIngredients() // saves current ingredients
        {
        }
        public void LoadIngredients() // loads saved ingredients
        {
        }
    }
}
