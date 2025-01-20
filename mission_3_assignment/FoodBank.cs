namespace mission_3_assignment;

public class FoodBank
{
    // This will keep all the food items added so we can display / delete
    private List<FoodItem> items = new List<FoodItem>();
    
    // Show the Food bank menu display. Wait for user input before returning that to the main flow of the program.
    public string displayMenu(string message)
    {
        string menuChoice = "";
        
        Console.Clear();
        Console.WriteLine("======================================");
        Console.WriteLine("            FOOD BANK MENU            ");
        Console.WriteLine("======================================\n");
        Console.WriteLine("1. Enter 'a' to Add an item");
        Console.WriteLine("2. Enter 'd' to Delete an item");
        Console.WriteLine("3. Enter 'l' to List all items");
        Console.WriteLine("4. Enter 'e' to Exit the program\n");
        
        Console.WriteLine(message);
        
        Console.Write("Please select an option: ");
        
        menuChoice = Console.ReadLine();
        
        return menuChoice;
    }
    
    // Menu for adding a food item. It will prompt the user for various inputs and check them before
    // creating a new food item object.
    public string addFoodItem()
    {
        
        Console.Clear();
        Console.WriteLine("======================================");
        Console.WriteLine("            ADD FOOD ITEM             ");
        Console.WriteLine("======================================\n");

        string name;
        string category;
        int quantity;
        int day;
        int month;
        int year;
        DateTime date;
        
        Console.Write("Food Item Name: ");
        name = Console.ReadLine();
        
        Console.Write("Food Item Category: ");
        category = Console.ReadLine();
        
        // Int input is a custom function that will handle the integer input.
        quantity = intInput("Food Item Quantity: ", 9999999, 1);
        
        month = intInput("Food Item Expiration Month (Number):  ", 12, 1);
        
        day = intInput("Food Item Expiration Day (Number):  ", 31, 1);
        
        year = intInput("Food Item Expiration Year (Number):  ", 9999, 1);
        
        // Try to create a date Item and catch the error incase day is out of range of the month.
        try
        {
            date = new DateTime(year, month, day);
        }
        catch (Exception ex)
        {
            return "Item not added. You entered invalid date values.";
        }
        
        // Create the food item object
        FoodItem newItem = new FoodItem(name, category, quantity, date);
        // add the object to our list of food items.
        items.Add(newItem);
        
        return "Item added successfully!";
        
    }
    
    // Page for diplayinig all food items.
    public string listFoodItems()
    {
        
        // If there haven't been any items added immediately return to menu and give error message.
        if (items.Count == 0)
        {
            return "There are no food items. Try adding an item!";
        }
        
        Console.Clear();
        Console.WriteLine("==================================================================================================");
        Console.WriteLine("                                         LIST FOOD ITEMS                                          ");
        Console.WriteLine("==================================================================================================\n");

        // Custom method that will display a table of all food items.
        printFoodItemTable();
        
        Console.Write("Enter any value to return to menu: "); 
        Console.ReadLine();

        return "";
    }
    
    // Menu for deleting a food item
    public string delteFoodItem()
    {
        string userInput = "";
        
        // If there haven't been any items added immediately return to menu and give error message.
        if (items.Count == 0)
        {
            return "There are no food items. Try adding an item!";
        }
        
        Console.Clear();
        Console.WriteLine("==================================================================================================");
        Console.WriteLine("                                       DELETE FOOD ITEM                                           ");
        Console.WriteLine("==================================================================================================\n");

        // Custom function that will generate a table of all food items.
        printFoodItemTable();
        
        Console.Write("Enter an ID to delete an Item: ");
        userInput = Console.ReadLine();
        
        // Custom function that will check to make sure the text entered is an id.
        if (validItemID(userInput))
        {
            // remove the item at the specified id
            int itemID = int.Parse(userInput) - 1;
            items.RemoveAt(itemID);
            return "Item Successfully Deleted!";
        }
        else
        {
            // Return to the menu if no correct ID is entered.
            return "Item ID not found and not deleted. Please try again!";
        }

    }
    
    // This function is only called inside the class and will populate a table with all food items
    // for the list and delete pages.
    public void printFoodItemTable()
    {
        Console.WriteLine("ID     | NAME                 | CATEGORY             | QUANTITY             | EXPIRATION DATE");

        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i+1}      | {items[i].printDetails()}");
        }
        
        Console.WriteLine("\n");
    }
    
    // Custom function to check if an id is valid
    public bool validItemID(string userInput)
    {
        // Step 1: Check if the input is a valid integer
        if (int.TryParse(userInput, out int itemID))
        {
            itemID = itemID - 1;
            
            // Step 2: Check if the itemID is within the valid index range (0 to items.Count - 1)
            if (itemID >= 0 && itemID < items.Count)
            {
                return true;
            }
        }
        return false;
    }

    // custom function to check if a input is an int.
    private int intInput(string text, int max, int min)
    {
        int userValue;
        while (true) // Loop until valid input is received
        {
            Console.Write(text); // Prompt the user
            string userInput = Console.ReadLine();

            // Try to parse the input as an integer
            if (int.TryParse(userInput, out userValue))
            {
                // Check if the input is within the valid range
                if (userValue >= min && userValue <= max)
                {
                    return userValue; // Valid input, return the value
                }
                else
                {
                    Console.WriteLine($"Input must be between {min} and {max}. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}