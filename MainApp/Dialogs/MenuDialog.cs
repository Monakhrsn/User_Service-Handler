using Business.Interfaces;
using Business.Models;
using Business.Services;

namespace MainApp.Dialogs;

public class MenuDialog(IUserService userService)
{
    private readonly IUserService _userService = userService;

    public void NewRegularUserOption()
    {
        var user = new RegularUser();
        
        Console.Clear();
        Console.WriteLine("-------- NEW Regular USER");
        Console.Write("Insert a name: ");
        user.Name = Console.ReadLine()!;
        
        _userService.AddUser(user);
    }

    public void NewAdminUserOption()
    {
        var user = new AdminUser();
        
        Console.Clear();
        Console.WriteLine("-------- NEW ADMIN USER");
        Console.Write("Insert a name: ");
        user.Name = Console.ReadLine()!;
        
        _userService.AddUser(user);
    }
    
    public void ViewAllUsersOption()
    {
        Console.WriteLine();
        Console.WriteLine("-------- VIEW ALL USERS --------");
        
        foreach(var user in _userService.GetAllUsers())
            Console.WriteLine($"{user.Name} - ({user.GetRole()})");

        Console.ReadKey();
    }
}