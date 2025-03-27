using Assignment_2;
using System.Globalization;
using static Assignment_2.Car;

string? carMake = GetInput("Make");
string? carModel = GetInput("Model");
int carYear;
DateTime lastMaintenanceDate;
CarType carType;

do
{
    if (int.TryParse(GetInput("Car Year"), out carYear)
        && 1886 <= carYear
        && DateTime.Now.Year >= carYear)
        break;
    Console.WriteLine("Invalid year! Please enter a valid year between 1886 and the current year.");
} while (true);

do
{
    if (DateTime.TryParseExact(GetInput("Last Maintenance Day (yyyy-MM-dd))"), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastMaintenanceDate)
        && lastMaintenanceDate <= DateTime.Now
        && lastMaintenanceDate.Year >= carYear)
        break;
    Console.WriteLine("Invalid date format! Please enter a valid date");
} while (true);

Car car;
do
{
    Console.Write("Is this a fuel car or electric car? (F/E): ");
    string? typeChar = Console.ReadLine();
    if (string.IsNullOrEmpty(typeChar))
    {
        Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar");
        continue;
    }
    switch (typeChar.ToLower())
    {
        case "f":
            car = new FuelCar() { Make = carMake, Model = carModel, Year = carYear, LastMaintenanceDate = lastMaintenanceDate };
            break;
        case "e":
            car = new ElectricCar() { Make = carMake, Model = carModel, Year = carYear, LastMaintenanceDate = lastMaintenanceDate };
            break;
        default:
            Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar");
            continue;
    }
    break;
} while (true);

car.DisplayDetails();
Ask(car);

void Ask(Car car)
{
    Console.Write($"Do you want to refuel/charging(Y/N): ");
    string answer = Console.ReadLine();
    if (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase)) return;

    DateTime fuelDate;

    do
    {
        if (DateTime.TryParseExact(GetInput("refuel/charging time (yyyy-MM-dd HH:mm)"), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out fuelDate))
        {
            if (fuelDate <= DateTime.Now)
            {
                break;
            }
        }
        Console.WriteLine("Invalid date format! Please enter a valid date");
    } while (true);

    if (car is ElectricCar electricCar)
        electricCar.Charge(fuelDate);
    else if (car is FuelCar fuelCar)
        fuelCar.Refuel(fuelDate);

}

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