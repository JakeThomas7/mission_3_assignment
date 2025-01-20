namespace mission_3_assignment;

public class FoodItem
{
    private string name;
    private string category;
    private int quantity;
    private DateTime expDate;

    // Constructor. Initate the object by assigning all values
    public FoodItem(string name, string category, int quantity, DateTime expDate)
    {
        this.name = name;
        this.category = category;
        this.quantity = quantity;
        this.expDate = expDate;
    }

    // this will be used to print out the table of food item. 
    public string printDetails()
    {
        return $"{Truncate(name, 20).PadRight(20)} | {Truncate(category, 20).PadRight(20)} | {quantity.ToString().PadRight(20)} | {Truncate(expDate.ToShortDateString(), 20).PadRight(20)}";
    }
    
    // the table can only display up to 20 characters in a column in order to look nice let's restrict it down to that.
    string Truncate(string value, int maxLength)
    {
        if (value.Length > maxLength)
        {
            return value.Substring(0, 16) + "...";
        }
        return value;
    }
}