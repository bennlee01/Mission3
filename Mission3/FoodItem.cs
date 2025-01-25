using System;

namespace FoodBankInventory
{
    // The FoodItem class represents a single food item in the inventory.
    public class FoodItem
    {
        // Properties of a food item
        public string Name { get; set; }            // Name of the food item 
        public string Category { get; set; }       // Category 
        public int Quantity { get; set; }          // Number of units available
        public DateTime ExpirationDate { get; set; } // Expiration date of the item

        // Constructor to initialize a FoodItem object when it's created.
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            // Validate that the quantity is not negative.
            if (quantity < 0) 
                throw new ArgumentException("Quantity cannot be negative.");

            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        // Override the ToString method to display a food item in a readable format.
        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate:yyyy-MM-dd}";
        }
    }
}