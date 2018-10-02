using System;
using System.Collections.Generic;
using System.Linq;

class ProductShop
{
    static void Main(string[] args)
    {
        SortedDictionary<string, List<Product>> stores = new SortedDictionary<string, List<Product>>();
        string input;

        while ((input = Console.ReadLine()) != "Revision")
        {
            string[] storeArgs = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string storeName = storeArgs[0];
            string productName = storeArgs[1];
            double price = double.Parse(storeArgs[2]);
            Product product = new Product(productName, price);

            if (stores.ContainsKey(storeName) == false)
            {
                stores.Add(storeName, new List<Product>());
            }

            stores[storeName].Add(product);
        }

        foreach (var store in stores)
        {
            Console.WriteLine($"{store.Key}->");
            Console.WriteLine(string.Join(Environment.NewLine,
                store.Value));
            
        }
    }
}

class Product
{
    string name;
    double price;

    public Product(string name, double price)
    {
        this.name = name;
        this.price = price;
    }

    public override string ToString()
    {
        return $"Product: {this.name}, Price: {this.price}";
    }
}