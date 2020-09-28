using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    public class MenuItem
    {
        public int MealNumber;
        public string ItemName;
        public string Description;
        public List<string> Ingredients;
        public int Price;

        public void PrintProperties()
        {
            Console.WriteLine($"1. Name: {ItemName}");
            Console.WriteLine($"2. Meal Number: {MealNumber}");
            Console.WriteLine($"3. Description: {Description}");
            Console.WriteLine("4. Ingredients:");
            foreach (var item in Ingredients)
            {
                int count = 1;
                Console.WriteLine($"   {item}");
                count++;
            }
            Console.WriteLine($"5. Price: {Price}");
        }

        
       


        public MenuItem() 
        {
            Ingredients = new List<string>();
        }
        public MenuItem(string itemName, string description, int price, int mealNumber)
        {
            
            ItemName = itemName;
            Description = description;
            Price = price;
            Ingredients = new List<string>();
            MealNumber = mealNumber;
        }  
    }
    /*public class Entree : MenuItem 
    {
        public int MealNumber;
        public Entree() { }
        public Entree(string itemName, string description, int price, int mealNumber)
            : base (itemName, description, price )
        {
            MealNumber = mealNumber;
        }
    }
    public class Appetizer : MenuItem
    {
        public Appetizer() { }

        bool isSoup;
        bool isSalad;
        public Appetizer(string itemName, string description, int price, int mealNumber)
            : base(itemName, description, price) { }
        public class soupSalad : MenuItem
        {
            public soupSalad() { }
            public soupSalad(string itemName, string description, int price, int mealNumber)
                : base(itemName, description, price) { }
        }
    }*/
}
