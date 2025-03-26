using Assignment;

List<Car> carCollection = [];

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
            var c = GetCarDetails();
            if (c != null)
            {
                carCollection.Add(c);
                Console.WriteLine("Car added successfully!");
            }
            break;
        case 2:
            ShowCars();
            break;
        case 3:
        case 4:
        case 5:
        case 6:
            return;
        default:
            Console.WriteLine("WRong Choice");
            break;
    }
} while (true);

int GetChoice()
{
    Console.WriteLine("Enter your choice:");
    Console.Write("> ");
    var choice = int.Parse(Console.ReadLine()!);
    return choice;
}

Car? GetCarDetails()
{
    Car c = new();
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
            return null;
    }
    Console.WriteLine("Enter Make:");
    Console.Write("> ");
    c.Make = Console.ReadLine();
    Console.WriteLine("Enter Model:");
    Console.Write("> ");
    c.Model = Console.ReadLine();
    Console.WriteLine("Enter Year:");
    Console.Write("> ");
    c.Year = int.Parse(Console.ReadLine()!);
    return c;
}

void ShowCars()
{
    int length = carCollection.Count;
    for (int i = 0; i < length; i++)
    {
        Console.WriteLine($"Car number {i + 1}");
        ShowCar(carCollection[i]);
    }
}

void ShowCar(Car c)
{
    Console.WriteLine($"Make: {c.Make}");
    Console.WriteLine($"Model: {c.Model}");
    Console.WriteLine($"Year: {c.Year}");
    Console.WriteLine($"Type: {c.Type}");
}

void SearchCarByMake()
{
    Console.WriteLine("Enter Make:");
    Console.Write("> ");
    string make = Console.ReadLine()!;
    var found = carCollection.FindAll(c => c.Make == make);
    for (int i = 0; i < found.Count; i++){
        Console.WriteLine($"Car found number {i + 1}");
        ShowCar(found[i]);
    }
}

void FilterCarByType(){
    
}