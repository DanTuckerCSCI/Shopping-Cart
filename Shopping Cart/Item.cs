using System;

public class Item
{
    // Properties
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    private double price;

    public double Price
    {
        get { return price; }
        set { price = value > 0 ? value : throw new ArgumentException("Price must be greater than zero."); }
    }

    // Constructor
    public Item(string name, string description, double price)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
    }

    // ToString method
    public override string ToString()
    {
        return $"ID: {Id}\nName: {Name}\nDescription: {Description}\nPrice: {Price:C}";
    }
}
