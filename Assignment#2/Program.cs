string? carMake = GetInput("Make");
string? carModel = GetInput("Model");
int? carYear;
DateTime? lastMaintenanceDay;
do
{
    if (int.TryParse(GetInput("Car Year"), out var result))
    {
        if (1886 <= result && DateTime.Now.Year >= result)
        {
            carYear = result;
            break;
        }
    }
    Console.WriteLine("Invalid year! Please enter a valid year between 1886 and the current year.");
} while (true);

string GetInput(string name)
{
    string? input;
    do
    {
        Console.Write($"Enter {name}: ");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
            break;
        Console.WriteLine("Input invalid");
    } while (true);
    return input;
}