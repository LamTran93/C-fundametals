using Assignment;

List<Car> cars = [];

do
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. Add a Car");
    Console.WriteLine("2. View all Cars");
    Console.WriteLine("3. Search Car by Make");
    Console.WriteLine("4. Filter Car by Type");
    Console.WriteLine("5. Remove a Car by Model");
    Console.WriteLine("6. Exit");
    int choice = GetChoice();
    switch (choice)
    {
        case 1:
            AddCar();
            break;
        case 2:
            ShowCars();
            break;
        case 3:
            SearchCarByMake();
            break;
        case 4:
            FilterCarByType();
            break;
        case 5:
            RemoveCarByModel();
            break;
        case 6:
            return;
        default:
            Console.WriteLine("Invalid Choice");
            break;
    }
} while (true);

int GetChoice()
{
    Console.WriteLine("Enter your choice:");
    Console.Write("> ");
    var choice = Console.ReadLine();
    if (!string.IsNullOrEmpty(choice) && int.TryParse(choice, out int result))
        return result;
    else return 0;
}

void AddCar()
{
    Car c = new();
    do
    {
        Console.WriteLine("Enter car type (Fuel/Electric):");
        Console.Write("> ");
        string type = Console.ReadLine()!;
        switch (type.ToLower())
        {
            case "fuel":
                c.Type = Car.CarType.Fuel;
                break;
            case "electric":
                c.Type = Car.CarType.Electric;
                break;
            default:
                Console.WriteLine("Input invalid");
                continue;
        }
        break;
    } while (true);

    do
    {
        Console.WriteLine("Enter Make:");
        Console.Write("> ");
        c.Make = Console.ReadLine();
        if (string.IsNullOrEmpty(c.Make))
        {
            Console.WriteLine("Input invalid");
            continue;
        }
        break;
    } while (true);

    do
    {
        Console.WriteLine("Enter Model:");
        Console.Write("> ");
        c.Model = Console.ReadLine();
        if (string.IsNullOrEmpty(c.Model))
        {
            Console.WriteLine("Input invalid");
            continue;
        }
        break;
    } while (true);
    do
    {
        Console.WriteLine("Enter Year:");
        Console.Write("> ");
        var year = Console.ReadLine();
        if (string.IsNullOrEmpty(year))
        {
            Console.WriteLine("Input invalid");
            continue;
        }
        c.Year = int.Parse(year);
        if (c.Year < 1900 || c.Year > DateTime.Now.Year)
        {
            Console.WriteLine("Input invalid");
            continue;
        }
        break;
    } while (true);

    cars.Add(c);
}

void ShowCars()
{
    for (int i = 0; i < cars.Count; i++)
    {
        Console.WriteLine(cars[i].ToString());
    }
}

void SearchCarByMake()
{
    string? make;
    do
    {
        Console.WriteLine("Enter Make:");
        Console.Write("> ");
        make = Console.ReadLine();
    } while (string.IsNullOrEmpty(make));
    var result = cars.Where(c => c.Make.Equals(make, StringComparison.OrdinalIgnoreCase) || c.Make.Contains(make, StringComparison.OrdinalIgnoreCase));
    foreach (var car in result)
    {
        Console.WriteLine(car.ToString());
    }
}

void FilterCarByType()
{
    string? userEnterType;
    do
    {
        Console.WriteLine("Enter type to search:");
        userEnterType = Console.ReadLine();
    } while (string.IsNullOrEmpty(userEnterType));

    Console.WriteLine($"Found cars:");
    var filteredCars = cars.FindAll(c => c.Type.ToString().Contains(userEnterType, StringComparison.OrdinalIgnoreCase));
    for (int i = 0; i < filteredCars.Count; i++)
    {
        Console.WriteLine(filteredCars[i].ToString());
    }
}

void RemoveCarByModel()
{
    Console.WriteLine("Enter model to remove:");
    Console.Write("> ");
    string model = Console.ReadLine()!;
    if (string.IsNullOrEmpty(model))
    {
        Console.WriteLine("Input invalid");
        return;
    }
    Car? foundCar = cars.Find(c => c.Model.Equals(model, StringComparison.OrdinalIgnoreCase));
    if (foundCar == null)
    {
        Console.WriteLine("Model not found!");
        return;
    }
    cars.Remove(foundCar);
    Console.WriteLine("Remove successfully");
}