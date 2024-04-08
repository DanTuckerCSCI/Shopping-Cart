using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Item> availableItems = InitializeProductList();
        Menu menu = new Menu(availableItems);

        bool exit = false;
        while (!exit)
        {
            menu.DisplayMenu();
            int choice = menu.GetMenuChoice();

            switch (choice)
            {
                case 1:
                    menu.ViewCart();
                    break;
                case 2:
                    menu.AddToCart();
                    break;
                case 3:
                    menu.RemoveFromCart();
                    break;
                case 4:
                    menu.CompletePurchase();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static List<Item> InitializeProductList()
    {
        return new List<Item>
        {
            new Item("Apple", "A juicy red apple", 0.50),
            new Item("Banana", "A ripe yellow banana", 0.30),
            new Item("Orange", "A sweet orange orange", 0.60)
        };
    }
}
