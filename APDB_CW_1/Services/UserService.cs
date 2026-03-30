using APDB_CW_1.Models;

namespace APDB_CW_1.Services;

public class UserService
{

    public static void addUser(string name, string surname, string type)
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
    public static void listAllRentendDevices(User user)
    {
        Wypozyczenie.extent.Where((wypozyczenie => wypozyczenie.client.Equals(user))).ToList().ForEach(Console.WriteLine);
    }
    
}