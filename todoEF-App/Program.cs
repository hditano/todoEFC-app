// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using todoEF_App;
using todoEF_App.Models;

static void MainMenu()
{
    bool isActive = true;

    while (isActive)
    {
        Console.Clear();
        Console.WriteLine("Welcome to todoEF-app");
        Console.WriteLine("Please choose your option");
        Console.WriteLine("-------------------------");
        Console.WriteLine("1. Create new User");
        Console.WriteLine("2. List all Users");
        Console.WriteLine("3. Search for Username");
        Console.WriteLine("4. Quit Program");
        Console.WriteLine("");
        Console.Write("Type your option: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                CreateNewUser();
                break;
            case "2":
                ListUsers();
                break;
            case "3":
                Console.Write("Type userName: ");
                string user = Console.ReadLine();
                SearchUser(user);
                break;
            case "4":
                isActive = false;
                break;
            case "default":
                break;
        }
    }

}

static void ListUsers()
{
    using (var con = new DatabaseContext())
    {
        con.Database.EnsureCreated();

        List<User> users = con.Users.ToList();

        Console.Clear();
        foreach (User user in users)
        {
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
            Console.WriteLine($"username: {user.userName}");
        }
        Console.ReadKey();
    }

}

static void CreateNewUser()
{
    using (var con = new DatabaseContext())
    {
        Console.Write("Please write your First Name: ");
        string fName = Console.ReadLine();
        Console.Write("Please write your Last Name: ");
        string lName = Console.ReadLine();
        Console.Write("Please write your desired username: ");
        string uName = Console.ReadLine();

        var newUser = new User { FirstName = fName, LastName = lName, userName = uName };

        con.Add(newUser);
        con.SaveChanges();

        Console.WriteLine("New User Created");

    }
}

static void SearchUser(string username)
{
    using (var con = new DatabaseContext())
    {
        List<User> users = con.Users.Where(b => b.userName == username).ToList();

        Console.Clear();
        Console.WriteLine($"User Information for {username}");
        Console.WriteLine("");
        foreach (var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName}");
            Console.WriteLine($"{user.UserId}");
        }
        Console.ReadKey();
    }
}

MainMenu();
