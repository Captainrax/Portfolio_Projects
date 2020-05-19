using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Uge_14_Pizzeria
{
    class Discounts
    {
        public static void Discount1()
        {

            if (((MainWindow)Application.Current.MainWindow).DiscountText.Text == "FF")
            {
                var pizzacount = 0;
                var drinkcount = 0;
                Pizza ComparePizza = new Pizza("ComparePizza");
                Drink CompareDrink = new Drink("CompareDrink");

                foreach (IFoodItem P in PizzaViewModel.checkOutList)
                {
                    if (P.GetType() == ComparePizza.GetType())
                    {
                        pizzacount++;
                    }
                }
                foreach (IFoodItem P in PizzaViewModel.checkOutList)
                {
                    if (P.GetType() == CompareDrink.GetType())
                    {
                        drinkcount++;
                    }
                }
                // Discount for 2 pizzas & 2 drinks, one pizza gets free Foundation

                if (pizzacount >= 2 && drinkcount >= 2 && MainWindow.DiscountApplied == false)
                {
                    IFoodItem TempPizza = new Pizza("Error")
                    {
                        Type = "Pizza",
                        Ingredients = new ObservableCollection<Ingredient>(),
                        Serial = MainWindow.GenerateSerial()
                    };
                    foreach (IFoodItem P in PizzaViewModel.checkOutList) // find the most expensive pizza an replace it with TempPizza
                    {
                        if (P is Pizza)
                        {
                            if (P.GetPrice > TempPizza.GetPrice)
                            {
                                TempPizza = P;
                                TempPizza.Name = P.Name;
                            }
                            //debug
                            //MessageBox.Show(TempPizza.GetPrice.ToString() + TempPizza.Name);
                        }
                    }

                    TempPizza.SaveIngredients(); // saves current pizza ingredients
                    TempPizza.DiscountApplied = true;

                    string PreviousFoundationName = "";
                    int PreviousPrice = 0;
                    foreach (Ingredient I in TempPizza.Ingredients) // remove old ingredient, saves name
                    {
                        if (I.Type == "Crust")
                        {
                            PreviousFoundationName = I.Name;
                            PreviousPrice = I.Price;
                            TempPizza.Ingredients.Remove(I);
                            break;
                        }
                    }
                    // add discounted ingredient
                    Ingredient tempfoundation = new Ingredient() { Name = PreviousFoundationName, Price = 0, Type = "Crust" };
                    TempPizza.Ingredients.Insert(1, tempfoundation);

                    Discount tempdiscount = new Discount("Discount: " + PreviousFoundationName); // this can probably look better
                    tempdiscount.Price[0] = PreviousPrice;

                    MainWindow.DiscountList.Add(tempdiscount);

                    PizzaViewModel.Update();

                    MainWindow.DiscountApplied = true;
                    MainWindow.DiscountEffect += "\n Discounts: \n 1 Free Crust -5 kr. \n";
                }
            }
            // force update price
            foreach (IFoodItem I in PizzaViewModel.checkOutList)
            {
                I.Price[0] = I.GetPrice;
            }
        }
    }
}
