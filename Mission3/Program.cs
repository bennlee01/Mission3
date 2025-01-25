using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodBankInventory
{
    class Program
    {
        // The inventory is stored as a list of FoodItem objects.
        static List<FoodItem> inventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            // Infinite loop to keep the program running until the user chooses to exit.
            while (true)
            {
                ShowMenu(); // Display the main menu.
                string choice = Console.ReadLine(); // Read the user's menu choice.

                // Execute the appropriate action based on the user's choice.
                switch (choice)
                {
                    case "1": // Option 1: Add a new food item.
                        AddFoodItem();
                        break;
                    case "2": // Option 2: Delete an existing food item.
                        DeleteFoodItem();
                        break;
                    case "3": // Option 3: Display all food items in the inventory.
                        PrintFoodItems();
                        break;
                    case "4": // Option 4: Exit the program.
                        Console.WriteLine("Exiting program. Goodbye!");
                        return;
                    default:
                        // Handle invalid menu input.
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        // Method to display the main menu options to the user.
        static void ShowMenu()
        {
            Console.WriteLine("\n--- Food Bank Inventory System ---");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: "); // Prompt the user to enter their choice.
        }

        // Method to add a new food item to the inventory.
        static void AddFoodItem()
        {
            Console.Write("Enter Food Item Name: ");
            string name = Console.ReadLine(); // Get the name of the food item.

            Console.Write("Enter Category (e.g., Canned Goods, Dairy, Produce): ");
            string category = Console.ReadLine(); // Get the category of the food item.

            // Prompt for and validate the quantity input.
            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid quantity. Must be a non-negative number.");
                return; // Exit the method if the input is invalid.
            }

            // Prompt for and validate the expiration date input.
            Console.Write("Enter Expiration Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
            {
                Console.WriteLine("Invalid date format. Use yyyy-MM-dd.");
                return; // Exit the method if the input is invalid.
            }

            try
            {
                // Create a new FoodItem object and add it to the inventory.
                var foodItem = new FoodItem(name, category, quantity, expirationDate);
                inventory.Add(foodItem);
                Console.WriteLine("Food item added successfully."); // Confirm success.
            }
            catch (ArgumentException ex)
            {
                // Catch and display any validation errors from the FoodItem class.
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Method to delete a food item by its name.
        static void DeleteFoodItem()
        {
            Console.Write("Enter the name of the food item to delete: ");
            string name = Console.ReadLine(); // Get the name of the food item to delete.

            // Find the first food item that matches the entered name (case-insensitive).
            var itemToRemove = inventory.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (itemToRemove != null)
            {
                // If found, remove the item from the inventory.
                inventory.Remove(itemToRemove);
                Console.WriteLine("Food item removed successfully.");
            }
            else
            {
                // If no item matches the name, inform the user.
                Console.WriteLine("Food item not found.");
            }
        }

        // Method to display all food items in the inventory.
        static void PrintFoodItems()
        {
            if (inventory.Count == 0)
            {
                // If the inventory is empty, notify the user.
                Console.WriteLine("No food items in the inventory.");
                return;
            }

            // Display all food items in the inventory in a readable format.
            Console.WriteLine("\n--- Current Food Items ---");
            foreach (var item in inventory)
            {
                Console.WriteLine(item); // Calls the overridden ToString() method in FoodItem.
            }
        }
    }
}
