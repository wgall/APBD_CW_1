using System.Runtime.CompilerServices;
using APDB_CW_1.Enums;
using APDB_CW_1.Models;

namespace APDB_CW_1.Services;

public class WypozyczenieService
{
    public static void rent(User user, Sprzet sprzet, int forHowLong)
    {
        if (forHowLong > 0)
        {
            if (sprzet.dostepnosc != Availibility.UNAVAILABLE)
            {
                int limit = user.GetType().Name switch
                {
                    "Student" => Student.maxAvailable,
                    "Employee" => Employee.maxAvailable
                };
                if (Wypozyczenie.extent.Where((wypozyczenie => wypozyczenie.client.Equals(user))).Count() < limit)
                {
                    new Wypozyczenie(user, sprzet, forHowLong);
                    sprzet.dostepnosc = Availibility.UNAVAILABLE;
                    Console.WriteLine($"Device {sprzet.nazwaSprzet} has been rented for {forHowLong} days");
                }
                else
                {
                    Console.WriteLine("User has reached the maximum number of rented devices");
                }
            }
            else
            {
                Console.WriteLine("The following device is unavailable");
            }
        }
        else
        {
            Console.WriteLine("Invalid rent time value, must be greater than 0");
        }
    }

    public static void returnDevice(User user, Sprzet device, DateTime date)
    {
        Wypozyczenie? rent = Wypozyczenie.extent
            .Where(wypozyczenie => wypozyczenie.client.Equals(user) && wypozyczenie.rentedGear.Equals(device))
            .FirstOrDefault();
        if (rent != null)
        {
            if (rent.expectedEndDate < date)
            {
                Console.WriteLine("Device is returned after the expected end date, ");
                rent.penalties = (date - rent.expectedEndDate).Days * 1.5f;
            }
            rent.rentedGear.dostepnosc = Availibility.AVAILABLE;
            rent.endDate = date;
        }
        else
        {
            throw new InvalidDataException("Following device was not rented to this specific user");
        }
    }

    public static void listRents(bool all)
    {
        Wypozyczenie.extent.Where((wypozyczenie =>  all || (wypozyczenie.expectedEndDate <= DateTime.UtcNow.AddDays(8) && (wypozyczenie.endDate >= wypozyczenie.expectedEndDate )))).ToList().ForEach(Console.WriteLine);
    }
}