using System;
using System.Collections.Generic;

public class ShoppingCart
{
    // Private list to hold items
    private List<Item> items;

    // Constructor
    public ShoppingCart()
    {
        items = new List<Item>();
    }

    // Add an item to the cart
    public void AddToCart(Item item)
    {
        items.Add(item);
    }

    // Clear all items from the cart
    public void ClearShoppingCart()
    {
        items.Clear();
    }

    // Remove an item at a specific index
    public void RemoveFromCart(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid index, please try again.");
        }
    }

    // Calculate the subtotal of all items in the cart
    public double CalculateSubTotal()
    {
        double subtotal = 0;
        foreach (Item item in items)
        {
            subtotal += item.Price;
        }
        return subtotal;
    }

    // Calculate the tax (10% of the subtotal)
    public double CalculateTax()
    {
        return CalculateSubTotal() * 0.10;
    }

    // Calculate the total cost (subtotal + tax)
    public double CalculateTotal()
    {
        return CalculateSubTotal() + CalculateTax();
    }

    // ToString method to display the contents of the shopping cart
    public override string ToString()
    {
        string output = "Shopping Cart Items:\n";
        foreach (Item item in items)
        {
            output += $"{item.Name} - {item.Price:C}\n";
        }
        output += $"Subtotal: {CalculateSubTotal():C}\n";
        output += $"Tax: {CalculateTax():C}\n";
        output += $"Total: {CalculateTotal():C}";
        return output;
    }
}
