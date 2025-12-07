class Person
{
    public string Name { get; set; }
    public string ID { get; set; }
    public int Age { get; set; }

    public Person(string name, string id, int age)
    {
        Name = name;
        ID = id;
        Age = age;
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, Person> people = new Dictionary<string, Person>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string name = parts[0];
            string id = parts[1];
            int age = int.Parse(parts[2]);

            if (people.ContainsKey(id))
            {
                people[id].Name = name;
                people[id].Age = age;
            }
            else
            {
                people.Add(id, new Person(name, id, age));
            }
        }

        foreach (var person in people.Values.OrderBy(p => p.Age))
        {
            Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
        }
    }
}