using System.Diagnostics;
using APDB_CW_1.Enums;
using APDB_CW_1.Models;

namespace APDB_CW_1.Services;

public class SprzetService
{
    public static void addSprzet(String nazwaSprzet, String opisSprzet, String type,
        Dictionary<String, String> specificParams)
    {
        switch (type.ToLower())
        {
            case "laptop":
                if (specificParams.ContainsKey("maxBatteryCapacity") && specificParams.ContainsKey("screenSize"))
                {
                    new Laptop(nazwaSprzet, opisSprzet, Int32.Parse(specificParams["maxBatteryCapacity"]), float.Parse(specificParams["screenSize"]));
                }
                else
                {
                    throw new InvalidDataException($"Missing {type} specific data");
                }
                break;
            case "projector":
                if (specificParams.ContainsKey("hasBattery") && specificParams.ContainsKey("weight"))
                {
                    new Projector(nazwaSprzet, opisSprzet, Boolean.Parse(specificParams["hasBattery"]), float.Parse(specificParams["weight"]));
                }
                else
                {
                    throw new InvalidDataException($"Missing {type} specific data");
                }
                break;
            case "camera":
                if (specificParams.ContainsKey("megaPixels") && specificParams.ContainsKey("resolution"))
                {
                    new Camera(nazwaSprzet, opisSprzet, Int32.Parse(specificParams["megaPixels"]), parseResolution(specificParams["resolution"]));
                }
                else
                {
                    throw new InvalidDataException($"Missing {type} specific data");
                }
                break;
        }
        
    }
    
    public static Resolution parseResolution(String resolution)
    {
        return resolution.ToLower() switch
        {
            "full_hd" => Resolution.FULL_HD,
            "hd" => Resolution.HD,
            "ultra_hd" => Resolution.ULTRA_HD
        };
    }

    public static void listSprzet(bool listUnAvailable)
    {
        foreach (var sprzet in Sprzet.extent)
        {
            if (listUnAvailable || sprzet.dostepnosc == Availibility.AVAILABLE)
            {
                Console.WriteLine(sprzet.ToString());
            }        
        }
    }

    public static void markAsUnavailable(Sprzet sprzet)
    {
        if (sprzet.dostepnosc == Availibility.AVAILABLE)
        {
            sprzet.dostepnosc = Availibility.UNAVAILABLE;
        }
        else
        {
            Console.WriteLine("Following device is already Unavailable");
        }
    }
    
}