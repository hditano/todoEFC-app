// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using todoEF_App;


static void ListUsers()
{
    using (var con = new DatabaseContext())
    {
        con.Database.EnsureCreated();

        List<User> users = con.Users.ToList();

        foreach(User user in users)
        {
            Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
            Console.WriteLine($"username: {user.userName}");
        }
    }

}


ListUsers();
