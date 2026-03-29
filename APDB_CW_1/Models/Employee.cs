namespace APDB_CW_1.Models;

public class Employee(string name, string surname) : User(name, surname)
{
    public static int maxAvailable = 5;
}