using APDB_CW_1.Enums;
using APDB_CW_1.Services;

namespace APDB_CW_1.Models;

public abstract class Sprzet
{
   public static List<Sprzet> extent = new List<Sprzet>();
   
   public string sprzetID { get; set; } = GenerateID.generate(7);
   public string nazwaSprzet { get; set; }
   public string opisSprzet { get; set; }
   public Availibility dostepnosc { get; set; } = Availibility.AVAILABLE;

   public Sprzet(string nazwaSprzet, string opisSprzet)
   {
      this.nazwaSprzet = nazwaSprzet;
      this.opisSprzet = opisSprzet;
      extent.Add(this);
   }
   
   public static void addSprzet(String nazwaSprzet, String opisSprzet, String type,Dictionary<String, String> specificParams)
   {
      try
      {
         SprzetService.addSprzet(nazwaSprzet, opisSprzet, type, specificParams);
      }
      catch (InvalidDataException e)
      {
         Console.WriteLine(e.Message);
      }
   }

   public static void listSprzet()
   {
      SprzetService.listSprzet(true);
   }

   public static void listAvailableSprzet()
   {
      SprzetService.listSprzet(false);
   }

   public void markAsUnavailable()
   {
      SprzetService.markAsUnavailable(this);
   }
   
   public override string ToString()
   {
      return $"{this.nazwaSprzet};{this.opisSprzet}";
   }
}