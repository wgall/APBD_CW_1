using System.Runtime.CompilerServices;
using APDB_CW_1.Services;

namespace APDB_CW_1.Models;

public class Wypozyczenie
{
    public static List<Wypozyczenie> extent = new List<Wypozyczenie>();
    public User client { get; set; }
    public Sprzet rentedGear { get; set; }
    public int howManyDays { get; set; }
    public DateTime startDate { get; set; } = DateTime.UtcNow;
    public DateTime expectedEndDate { get; set; }
    public DateTime? endDate { get; set; } = null;
    public float? penalties { get; set; } = null;

    public Wypozyczenie(User client, Sprzet rentedGear, int howManyDays)
    {
        this.client = client;
        this.rentedGear = rentedGear;
        this.howManyDays = howManyDays;
        this.expectedEndDate = DateTime.UtcNow.AddDays(howManyDays);
        extent.Add(this);
    }
    
    public static void rentDevice(User user, Sprzet sprzet, int forHowLong)
    {
        WypozyczenieService.rent(user, sprzet, forHowLong);
    }

    public void returnDevice(DateTime returnDate)
    {
        WypozyczenieService.returnDevice(this.client, this.rentedGear, returnDate);
    }

    public static void listExpiredRents()
    {
        Console.WriteLine("Listing expired rents");
        WypozyczenieService.listRents(false);
    }

    public static void listRents()
    {
        Console.WriteLine("Listing rents");
        WypozyczenieService.listRents(true);
    }
    
    public override string ToString()
    {
        if(penalties != null){
            return $"Client {this.client.id}, Device {this.rentedGear.sprzetID}, Fine: {this.penalties}, ExpectedEndDate: {this.expectedEndDate}, EndDate: {this.endDate}";
        }
        else if (endDate == null)
        {
            return $"Client {this.client.id}, Device {this.rentedGear.sprzetID}, ExpectedEndDate: {this.expectedEndDate}";
        }
        else
        {
            return $"Client {this.client.id}, Device {this.rentedGear.sprzetID}, ExpectedEndDate: {this.expectedEndDate}, EndDate: {this.endDate}";
        }
    }
}