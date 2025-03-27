using Assignment_2;
using System.Globalization;

string? carMake = GetInput("Make");
string? carModel = GetInput("Model");
int carYear;
DateTime lastMaintenanceDate;

while (true)
{
    if (int.TryParse(GetInput("Car Year"), out carYear)
        && 1886 <= carYear
        && DateTime.Now.Year >= carYear)
        break;
    Console.WriteLine("Invalid year! Please enter a valid year between 1886 and the current year.");
}


while (true)
{
    if (!DateTime.TryParseExact(GetInput("Last Maintenance Day (yyyy-MM-dd)"), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out lastMaintenanceDate))
    {
        Console.WriteLine("Invalid date format! Please enter a valid date");
        continue;
    }

    if (lastMaintenanceDate > DateTime.Now || lastMaintenanceDate.Year < carYear)
    {
        Console.WriteLine("Maintenace Date not valid! Please enter a valid date");
        continue;
    }

    break;
}

Car car;
while (true)
{
    Console.Write("Is this a fuel car or electric car? (F/E): ");
    string? typeChar = Console.ReadLine();
    if (string.IsNullOrEmpty(typeChar))
    {
        Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar");
        continue;
    }
    typeChar = typeChar.Trim();
    switch (typeChar.ToLower())
    {
        case "f":
            car = new FuelCar();
            break;
        case "e":
            car = new ElectricCar();
            break;
        default:
            Console.WriteLine("Invalid input! Please enter 'F' for FuelCar or 'E' for ElectricCar");
            continue;
    }
    break;
}

car.Make = carMake;
car.Model = carModel;
car.Year = carYear;
car.LastMaintenanceDate = lastMaintenanceDate;
car.DisplayDetails();
RequestRefuelOrCharge(car);

void RequestRefuelOrCharge(Car car)
{
    Console.Write($"Do you want to refuel/charging(Y/N): ");
    string answer = Console.ReadLine();
    if (string.IsNullOrEmpty(answer)) return;
    answer = answer.Trim();
    if (!answer.Equals("Y", StringComparison.OrdinalIgnoreCase)) return;

    DateTime fuelDate;

    while (true)
    {
        if (!DateTime.TryParseExact(GetInput("refuel/charging time (yyyy-MM-dd HH:mm)"), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out fuelDate))
        {
            Console.WriteLine("Invalid date format! Please enter a valid date");
            continue;
        }

        if (fuelDate > DateTime.Now)
        {
            Console.WriteLine("Invalid date! Please enter a valid date");
            continue;
        }

        break;
    }

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