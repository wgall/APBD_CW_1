namespace APDB_CW_1.Models;

public class Projector(string nazwaSprzet, string opisSprzet, bool hasBattery, float weight) : Sprzet(nazwaSprzet, opisSprzet)
{
    public bool hasBattery { get; set; } = hasBattery;
    public float weight { get; set; } = weight;
    
    public override string ToString()
    {
        return $"{this.nazwaSprzet};{this.opisSprzet};{this.hasBattery};{this.weight};{this.dostepnosc.ToString()}";
    }
}