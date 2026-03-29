using APDB_CW_1.Services;

namespace APDB_CW_1.Models;

public abstract class User
{
    public static List<User> extense = new List<User>();
    
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
        switch (type.ToLower())
        {
            case "student":
                new Student(name, surname);
                break;
            case "employee":
                new Employee(name, surname);
                break;
            default:
                throw new InvalidDataException("Invalid User type provided");
                break;
        }
        Console.WriteLine($"{type} {name} has been added");
    }
}