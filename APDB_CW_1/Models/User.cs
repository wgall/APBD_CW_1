using APDB_CW_1.Services;

namespace APDB_CW_1.Models;

public abstract class User
{
    public static List<User> extense = new List<User>();
    
    public static int? maxAvailable = 2;
    
    public string id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }

    public User(string name, string surname)
    {
        this.id = GenerateID.generate(5);
        this.name = name;
        this.surname = surname;
        extense.Add(this);
    }

    public static void addUser(String name, String surname, String type)
    {
        UserService.addUser(name, surname,type);
    }

    public void listAllRentendDevices()
    {
        Console.WriteLine($"Listing all Rentend devices for user {this.name}");
        UserService.listAllRentendDevices(this);
    }
}