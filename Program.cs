
using System;
using System.Collections.Generic;

// Base class
class FoodProduct
{
    public string Name { get; set; }
    public DateTime ExpirationDate { get; set; }
    public double Calories { get; set; }

    public FoodProduct(string name, DateTime expirationDate, double calories)
    {
        Name = name;
        ExpirationDate = expirationDate;
        Calories = calories;
    }

    public virtual string GetNutritionalValue()
    {
        return $"Calories: {Calories} kcal";
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Expiration date: {ExpirationDate:dd.MM.yyyy}");
        Console.WriteLine(GetNutritionalValue());
        Console.WriteLine();
    }
}

// Dairy product subclass
class DairyProduct : FoodProduct
{
    public DairyProduct(string name, DateTime expirationDate, double calories)
        : base(name, expirationDate, calories)
    {
    }

    public override string GetNutritionalValue()
    {
        return $"Dairy product | Calories: {Calories} kcal | " +
               "Rich in calcium and protein";
    }
}

// Meat product subclass
class MeatProduct : FoodProduct
{
    public MeatProduct(string name, DateTime expirationDate, double calories)
        : base(name, expirationDate, calories)
    {
    }

    public override string GetNutritionalValue()
    {
        return $"Meat product | Calories: {Calories} kcal | " +
               "Rich in protein and iron";
    }
}

// Vegetable subclass
class Vegetable : FoodProduct
{
    public Vegetable(string name, DateTime expirationDate, double calories)
        : base(name, expirationDate, calories)
    {
    }

    public override string GetNutritionalValue()
    {
        return $"Vegetable | Calories: {Calories} kcal | " +
               "Rich in vitamins and fiber";
    }
}

// Main program
class Program
{
    static void Main()
    {
        List<FoodProduct> products = new List<FoodProduct>
        {
            new DairyProduct("Milk", new DateTime(2026, 11, 10), 60),
            new DairyProduct("Cheese", new DateTime(2026, 12, 15), 350),
            new MeatProduct("Chicken", new DateTime(2026, 11, 5), 165),
            new MeatProduct("Beef", new DateTime(2026, 11, 8), 250),
            new Vegetable("Carrot", new DateTime(2026, 11, 20), 41),
            new Vegetable("Broccoli", new DateTime(2026, 11, 12), 34)
        };

        Console.WriteLine("=== FOOD PRODUCTS ===\n");

        foreach (FoodProduct product in products)
        {
            product.DisplayInfo();
        }

        Console.WriteLine("=== EXPIRATION CHECK ===\n");

        foreach (FoodProduct product in products)
        {
            if (product.ExpirationDate < DateTime.Today)
            {
                Console.WriteLine($"{product.Name} - Expired");
            }
            else
            {
                Console.WriteLine($"{product.Name} - Fresh");
            }
        }

        Console.WriteLine("\n=== POLYMORPHISM DEMONSTRATION ===\n");

        foreach (FoodProduct product in products)
        {
            Console.WriteLine($"{product.Name}: {product.GetNutritionalValue()}");
        }
    }
}
