// See https://aka.ms/new-console-template for more information

using APDB_CW_1.Models;
using APDB_CW_1.Services;

User.addUser("Foo","Bar","student");
User.addUser("John","Doe","employee");
Sprzet.addSprzet("Lenovo ThinkPad","laptop","laptop",new Dictionary<string, string>{ {"maxBatteryCapacity", "5"}, {"screenSize", "14,2"} } );
Sprzet.addSprzet("Cannon EOS2000D","camera","camera",new Dictionary<string, string>{ {"resolution", "hd"}, {"megaPixels","40"} } );
Sprzet.addSprzet("Lenovo","ThinkPad","laptop",new Dictionary<string, string>{ {"maxBatteryCapacity", "5"}, {"screenSize", "14,2"} } );
Sprzet.addSprzet("Lenovo","ThinkPad","laptop",new Dictionary<string, string>{ {"maxBatteryCapacity", "5"}, {"screenSize", "14,2"} } );
Sprzet.addSprzet("Cannon EOS2000D","camera","camera",new Dictionary<string, string>{ {"resolution", "hd"}, {"megaPixels","40"} } );
Sprzet.addSprzet("Lenovo","ThinkPad","laptop",new Dictionary<string, string>{ {"maxBatteryCapacity", "5"}, {"screenSize", "14,2"} } );



Sprzet.listSprzet();
Wypozyczenie.rentDevice(User.extense[1], Sprzet.extent[0],7 );
Wypozyczenie.rentDevice(User.extense[1], Sprzet.extent[2],7);
Wypozyczenie.rentDevice(User.extense[0], Sprzet.extent[3],7);
Wypozyczenie.rentDevice(User.extense[0], Sprzet.extent[4],7);

Console.WriteLine("================================================================");

Wypozyczenie.rentDevice(User.extense[0], Sprzet.extent[5],7);

Console.WriteLine("================================================================");

Sprzet.extent[1].markAsUnavailable();


Wypozyczenie.rentDevice(User.extense[1], Sprzet.extent[1],7 );

Console.WriteLine("================================================================");

Wypozyczenie.extent[3].returnDevice(DateTime.UtcNow.AddDays(2));

Wypozyczenie.extent[1].returnDevice(DateTime.UtcNow.AddDays(9));

Console.WriteLine("================================================================");

User.extense[1].listAllRentendDevices();

Console.WriteLine("================================================================");

Wypozyczenie.listExpiredRents();

Console.WriteLine("================================================================");

Wypozyczenie.listRents();

Sprzet.listSprzet();