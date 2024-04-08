using System;
using System.Collections.Generic;

public class Menu
{
    private List<Item> availableItems;
    private ShoppingCart shoppingCart;
    private List<string> menuOptions;

    // Constructor
    public Menu(List<Item> availableItems)
    {
        this.availableItems = availableItems;
        shoppingCart = new ShoppingCart();
        menuOptions = new List<string>
        {
            "View Cart",
            "Add to Cart",
            "Remove from Cart",
            "Complete Purchase",
            "Exit"
        };
    }

    // Display all menu options
    public void DisplayMenu()
    {
        Console.WriteLine("\nMenu Options:");
        for (int i = 0; i < menuOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {menuOptions[i]}");
        }
    }

    // Get a valid integer input from the user
    public int GetInteger(string prompt)
    {
        int choice;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice <= 0);
        return choice;
    }

    // Get and validate the user's menu choice
    public int GetMenuChoice()
    {
        int choice;
        do
        {
            choice = GetInteger("Choose an option: ");
        } while (choice < 1 || choice > menuOptions.Count);
        return choice;
    }

    // View the shopping cart
    public void ViewCart()
    {
        Console.WriteLine(shoppingCart);
    }

    // Add an item to the cart
    public void AddToCart()
    {
        Console.WriteLine("Available Items:");
        for (int i = 0; i < availableItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableItems[i].Name} - {availableItems[i].Price:C}");
        }
        int choice = GetInteger("Select an item to add to the cart: ") - 1;
        if (choice >= 0 && choice < availableItems.Count)
        {
            shoppingCart.AddToCart(availableItems[choice]);
            Console.WriteLine($"{availableItems[choice].Name} added to cart.");
        }
        else
        {
            Console.WriteLine("Invalid selection, please try again.");
        }
    }

    // Remove an item from the cart
    public void RemoveFromCart()
    {
        ViewCart();
        int choice = GetInteger("Select an item to remove from the cart: ") - 1;
        shoppingCart.RemoveFromCart(choice);
        if (choice >= 0 && choice < availableItems.Count)
        {
            Console.WriteLine("Item removed from cart.");
        }
        else
        {
            Console.WriteLine("Invalid selection, please try again.");
        }
    }

    // Complete the purchase process
    public void CompletePurchase()
    {
        ViewCart();
        Console.WriteLine("Enter credit card number to complete the purchase: ");
        string creditCardNumber = Console.ReadLine(); // Simulating credit card processing
        Console.WriteLine("The credit card has been charged.");
        shoppingCart.ClearShoppingCart();
    }
}
