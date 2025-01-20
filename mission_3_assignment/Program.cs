// Jacob Thomas
// IS 413 Section 2

// Food Bank Program
// Allows for accessing and managing food items. You can:
// Add Food Items
// Delete Food Items
// Print List of Current Food Items
// Exit the Program

using mission_3_assignment;

// Food bank class for creating different pages.
FoodBank myFoodBank = new FoodBank();

// This is a message that will be rendered to the user in the Food Bank Menu.
// I will change throughout the program
string message = "";

do
{
    // Start with the Food bank menu. Based on the user input lets open to a new Page.
    string userInput = "";
    userInput = myFoodBank.displayMenu(message).ToLower();

    // Once the actions are complete from each of these pages we will repeat back to the menu.
    // A new message will be displayed based on the page.
    if (userInput == "a")
    {
        message = myFoodBank.addFoodItem();
    }
    else if (userInput == "d")
    {
        message = myFoodBank.delteFoodItem();
    }
    else if (userInput == "l")
    {
        message = myFoodBank.listFoodItems();
    }
    else if (userInput == "e")
    {
        break;
    }
    else
    {
        message = "Oops! that was an invalid input.";
    }

} while (true);
