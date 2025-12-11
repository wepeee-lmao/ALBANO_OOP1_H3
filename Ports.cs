using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ports
{
    public abstract class prt
    {
        public string Nm { get; set; }
        public Dictionary<string, double> GPrices { get; set; }

        public prt(string name)
        {
            Nm = name;
            GPrices = new Dictionary<string, double>();
        }

    }

    public class Manila : prt
    {
        public Manila() : base("Manila")
        {
            GPrices["Rattan"] = 30;
            GPrices["Porcelain Ware"] = 100;
            GPrices["Cloves & Cinnamon"] = 60;
            GPrices["Lacquerware"] = 80;
            GPrices["Gold Dust"] = 150;
            GPrices["Tortoise Shell"] = 120;
            GPrices["Ebony Wood"] = 70;
            GPrices["Abaca"] = 40;
            GPrices["Coconut Oil"] = 35;
            GPrices["Mother Pearl(Nacre)"] = 90;
        }
        
    }

    public class Malacca : prt
    {
        public Malacca() : base("Malacca")
        {
            GPrices["Black Pepper"] = 70;
            GPrices["Nutmeg"] = 60;
            GPrices["Clove"] = 55;
            GPrices["Tin Ingot"] = 80;
            GPrices["Elephants’ Ivory"] = 150;
            GPrices["Camphor"] = 90;
            GPrices["Silk Blend Cloth"] = 120;
            GPrices["Betel Nuts"] = 25;
            GPrices["Exotic Bird (Parrot)"] = 90;
            GPrices["Sapphire"] = 300;
        }

    }

    public class Macau : prt
    {
        public Macau() : base("Macau")
        {
            GPrices["Silk Embroidered Robe"] = 300;
            GPrices["Jade Jewelry"] = 200;
            GPrices["Porcelain Set"] = 110;
            GPrices["Spices (Star Anise)"] = 60;
            GPrices["Gunpowder"] = 70;
            GPrices["Saltpeter"] = 70;
            GPrices["Lacquer Screen"] = 200;
            GPrices["Persian-style rug"] = 180;
            GPrices["Perfumed Oil"] = 90;
            GPrices["Tea Cake"] = 50;
        }
      
    }

    public class Acapulco : prt
    {
        public Acapulco() : base("Acapulco")
        {
            GPrices["Silver"] = 95;
            GPrices["Cocoa Beans"] = 60;
            GPrices["Cochineal Dye"] = 80;
            GPrices["Leather"] = 60;
            GPrices["Tobacco"] = 40;
            GPrices["Corn & Grains"] = 10;
            GPrices["Wine"] = 120;
            GPrices["Brandy"] = 120;
            GPrices["Paper"] = 70;
            GPrices["Book"] = 80;
        }
      
    }

    public class Cartagena : prt
    {
        public Cartagena() : base("Cartagena")
        {
            GPrices["Gold Bars"] = 1000;
            GPrices["Indigo Dye"] = 600;
            GPrices["Dyewood"] = 400;
            GPrices["Emerald"] = 1200;
            GPrices["Sugar Cane"] = 45;
            GPrices["Vanilla Pods"] = 80;
            GPrices["Pearl"] = 200;
            GPrices["Coffee Beans"] = 60;
            GPrices["Cotton"] = 180;
            GPrices["Cacao"] = 200;
        }
      
    }

    public class Havana : prt
    {
        public Havana() : base("Havana")
        {
            GPrices["Raw Sugar"] = 50;
            GPrices["Indigo Dye"] = 55;
            GPrices["Mahogany Wood"] = 100;
            GPrices["Silver Ore"] = 120;
            GPrices["Salted Meat"] = 120;
            GPrices["Distilled Rum"] = 65;
            GPrices["Coral Jewelry"] = 400;
            GPrices["Cuban Cigar"] = 70;
            GPrices["Salted Fish"] = 20;
        }
      
    }

    public class Lisbon : prt
    {
        public Lisbon() : base("Lisbon")
        {
            GPrices["Cork"] = 25;
            GPrices["Salted Cod /Bacalhau/ "] = 20;
            GPrices["Saffron"] = 120;
            GPrices["Amber"] = 60;
            GPrices["Ceramics (Azulejos)"] = 40;
            GPrices["Port Wine"] = 50;
            GPrices["Figs & Dates"] = 25;
            GPrices["Olive Oil"] = 30;
            GPrices["Linen"] = 35;
            GPrices["Olive Oil Soap"] = 35;
        }
      
    }

    public class Seville : prt
    {
        public Seville() : base("Seville")
        {
            GPrices["European Goldsmith Crafted Jewelry"] = 700;
            GPrices["Venetian glass import"] = 150;
            GPrices["Olive oil"] = 40;
            GPrices["Religious Icon (Cross)"] = 80;
            GPrices["Printing Press Part"] = 500;
            GPrices["Paint Pigment (Ultramarine)"] = 60;
            GPrices["Toledo Steel (Armor)"] = 350;
            GPrices["European textile Cloth"] = 90;
            GPrices["Aged Spirit Barrel "] = 100;
            GPrices["Musical Instrument (Lute)"] = 150;
        }
      
    }
}
