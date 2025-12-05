class Team
{
    public string Name { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }

    public Team(string name, string creator)
    {
        Name = name;
        Creator = creator;
        Members = new List<string>();
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Team> teams = new List<Team>();

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split("-");

            string creator = data[0];
            string teamName = data[1];

            bool teamExists = teams.Any(t => t.Name == teamName);
            bool creatorExists = teams.Any(t => t.Creator == creator);

            if (teamExists)
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }

            if (creatorExists)
            {
                Console.WriteLine($"{creator} cannot create another team!");
                continue;
            }

            Team team = new Team(teamName, creator);
            teams.Add(team);
            Console.WriteLine($"Team {teamName} has been created by {creator}!");
        }

        string command;
        while ((command = Console.ReadLine()) != "end of assignment")
        {
            string[] data = command.Split("->");
            string user = data[0];
            string teamName = data[1];

            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            bool userIsCreator = teams.Any(t => t.Creator == user);
            bool userIsMember = teams.Any(t => t.Members.Contains(user));

            if (team == null)
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (userIsCreator || userIsMember)
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
                continue;
            }

            team.Members.Add(user);
        }

        List<Team> validTeams = teams
            .Where(t => t.Members.Count > 0)
            .OrderByDescending(t => t.Members.Count)
            .ThenBy(t => t.Name)
            .ToList();

        List<Team> disbandTeams = teams
            .Where(t => t.Members.Count == 0)
            .OrderBy(t => t.Name)
            .ToList();

        foreach (var team in validTeams)
        {
            Console.WriteLine(team.Name);
            Console.WriteLine($"- {team.Creator}");

            foreach (var member in team.Members.OrderBy(m => m))
            {
                Console.WriteLine($"-- {member}");
            }
        }

        Console.WriteLine("Teams to disband:");
        foreach (var team in disbandTeams)
        {
            Console.WriteLine(team.Name);
        }
    }
}