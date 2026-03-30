namespace APDB_CW_1.Models;

using APDB_CW_1.Enums;

public class Camera(string nazwaSprzet, string opisSprzet, int megaPixels, Resolution resolution) :  Sprzet(nazwaSprzet, opisSprzet)
{
    public int megaPixels { get; set; } = megaPixels;
    public Resolution resolution { get; set; } = resolution;
    
    public override string ToString()
    {
        return $"{this.nazwaSprzet};{this.opisSprzet};{this.megaPixels};{this.resolution};{this.dostepnosc.ToString()}";
    }
}