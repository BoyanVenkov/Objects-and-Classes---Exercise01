class Vehicle
{
    public string Type { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int Horsepower { get; set; }

    public Vehicle(string type, string model, string color, int horsepower)
    {
        Type = type;
        Model = model;
        Color = color;
        Horsepower = horsepower;
    }

    public override string ToString()
    {
        return $"Type: {char.ToUpper(Type[0]) + Type.Substring(1)}\n" +
               $"Model: {Model}\n" +
               $"Color: {Color}\n" +
               $"Horsepower: {Horsepower}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> catalogue = new List<Vehicle>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split();
            string type = parts[0];
            string model = parts[1];
            string color = parts[2];
            int horsepower = int.Parse(parts[3]);

            catalogue.Add(new Vehicle(type, model, color, horsepower));
        }

        string command;
        while ((command = Console.ReadLine()) != "Close the Catalogue")
        {
            Vehicle vehicle = catalogue.FirstOrDefault(v => v.Model == command);
            if (vehicle != null)
            {
                Console.WriteLine(vehicle);
            }
        }

        double carsAvg = catalogue
            .Where(v => v.Type == "car")
            .Select(v => v.Horsepower)
            .DefaultIfEmpty()
            .Average();

        double trucksAvg = catalogue
            .Where(v => v.Type == "truck")
            .Select(v => v.Horsepower)
            .DefaultIfEmpty()
            .Average();

        Console.WriteLine($"Cars have average horsepower of: {carsAvg:F2}.");
        Console.WriteLine($"Trucks have average horsepower of: {trucksAvg:F2}.");
    }
}