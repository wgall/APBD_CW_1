namespace APDB_CW_1.Models;

public class Student(string name, string surname) : User(name, surname)
{
    public static int maxAvailable = 2;
}