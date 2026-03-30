using APDB_CW_1.Services;

namespace APDB_CW_1.Models;

public class Laptop(string nazwaSprzet, string opisSprzet, int maxBatteryCapacity, float screenSize) : Sprzet(nazwaSprzet, opisSprzet)
{
    public int maxBatteryCapacity { get; set; } = maxBatteryCapacity;
    public float screenSize { get; set; } = screenSize;
    
    public override string ToString()
    {
        return $"{this.nazwaSprzet};{this.opisSprzet};{this.maxBatteryCapacity};{this.screenSize};{this.dostepnosc.ToString()}";
    }
    
    
}