using Effects;
using GTS;
using Pstats;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facts
{
    public class facts
    {
        public static string[] genfacts =
        {
                "The Mexican silver dollar was an important international currency in East Asia markets during this period. ",
                "The Manila–Acapulco Galleon Trade lasted for 250 years (1565–1815). It is one of the longest continuous trade routes in world history.",
                "The trade route was a prime example of mercantilism, tightly controlled by the Spanish Crown to maximize imperial wealth.",
                "The galleons created a merchant elite in Manila, including Spanish officials and local Chinese traders (the SANGLEY community).",
                "A single galleon’s cargo could be worth millions of pesos (equivalent to billions today).",
                "Silver was the main global currency; Chinese merchants wanted silver, and New World colonies had plenty from mines in Potosí (Bolivia) and Mexico.",
                "Goods from Manila were transferred to Spain via Atlantic treasure fleets, making the Philippines a vital link in Spain’s global empire.",
                "The galleons were sometimes called “Nao de China” because they carried Chinese goods to Mexico",
                "Navigation relied on celestial maps and trade winds. Ships used the Kuroshio Current (North Pacific Drift) to reach Acapulco.",
                "The last galleon, Magallanes, sailed in 1815, ending the route forever.",
                "The heavy silver flow caused inflation in Manila and made silver more common than copper or gold.",
                "Despite their defenses, only four galleons were ever captured at sea in 250 years, showing their resilience against pirates and rival nations.",
                "The galleons were armed merchant ships, carrying cannons and soldiers to defend against pirates and rival nations.",

            };

    }

    public class RanFacts : facts
    {
        public void Grfacts(Journal j)
        {
            Colors.BoldTypeColor("Did you know? ", 255, 215, 0, 30);
            string y = genfacts[GTS.Program.rnd.Next(0, genfacts.Length)];
            j.AddGen(y);
            Colors.TypeColor(y, 255, 215, 0, 30);
        }
    }

    public class mfacts
    {
        public static string[] mf =
        {
                "Manila was the central hub of the Galleon Trade, acting as the main port for goods from Asia.",
                "Silk, porcelain, and spices were major imports from China.",
                "Local products like tropical hardwoods, coconut wine, and sugar were exported.",
                "The city had a mix of Spanish, Chinese, and local Filipino merchants, creating a cosmopolitan trade environment.",
                "Manila’s Intramuros walls were built partly to protect traders and goods from raids.",
                "The galleons often waited months for favorable winds to cross the Pacific.",
                "Chinese traders dominated many of the local marketplaces.",
                "Manila’s harbor was one of the most strategic in Asia.",
                "Currency often included Chinese coins, Mexican pesos, and barter goods.",
                "Manila had strict trade regulations imposed by the Spanish crown."
            };
    }

    public class Ranfacts1 : mfacts
    {
        public void Mfacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Manila, ", 255, 135, 215, 30);

            string y = mf[GTS.Program.rnd.Next(0, mf.Length)];
            j.AddPort("Manila", y);
            Colors.TypeColor(y, 255, 135, 215, 30);
        }
    }

    public class mlfacts
    {
        public static string[] mlf =
        {
                "Malacca controlled the Straits of Malacca, a crucial choke point for spice trade.",
                "Traders dealt heavily in pepper, nutmeg, cloves, and tin.",
                "The port was a melting pot of Malay, Chinese, Indian, and Arab merchants.",
                "Portuguese had conquered Malacca in 1511, influencing local trade rules.",
                "Malacca exported sago, sugar, and tropical fruits.",
                "Ships stopped here to resupply before heading to the Indian Ocean or Manila.",
                "Malay craftsmanship, especially in textiles and boat-making, was highly prized.",
                "Local markets offered spices at lower prices than European ports.",
                "The city had fortified walls and strategic watchtowers to protect trade.",
                "Malacca’s harbor was shallow, requiring smaller ships to ferry goods."
            };
    }

    public class Ranfacts2 : mlfacts
    {
        public void Mlfacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Malacca, ", 215, 255, 175, 30);
            string y = mlf[GTS.Program.rnd.Next(0, mlf.Length)];
            j.AddPort("Malacca", y);
            Colors.TypeColor(y, 215, 255, 175, 30);
        }
    }

    public class macfacts
    {
        public static string[] mcf =
        {
                "Macau was under Portuguese control and acted as a gateway to China.",
                "Major trade included silk, porcelain, and tea.",
                "The port was heavily taxed by the Portuguese, making some goods expensive.",
                "Jesuit missionaries often accompanied traders, spreading European knowledge.",
                "Macau had one of the earliest European-style urban layouts in Asia.",
                "Chinese merchants dominated local trade with strict regulations.",
                "Ships from Japan occasionally brought silver and copper.",
                "Macau’s docks were crowded with traders from multiple nations.",
                "Exotic spices and herbs were sold at premium prices.",
                "Gambling and entertainment were common in the port city, attracting sailors."
            };
    }

    public class Ranfacts3 : macfacts
    {
        public void Macfacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Macau, ", 215, 0, 95, 30);
            string y = mcf[GTS.Program.rnd.Next(0, mcf.Length)];
            j.AddPort("Macau", y);
            Colors.TypeColor(y, 215, 0, 95, 30);
        }
    }

    public class acafacts
    {
        public static string[] acf =
        {
                "Acapulco was the Pacific terminus of the Manila Galleons.",
                "Goods from Manila were traded for silver, cocoa, and local textiles.",
                "The port was famous for its steep cliffs and natural harbor.",
                "Pirates frequently raided the bay, so galleons often traveled in convoys.",
                "Local markets sold corn, beans, and tropical fruits.",
                "Acapulco hosted large fairs to trade Asian goods inland.",
                "Indigenous laborers often helped load and unload galleons.",
                "Local craftsmen produced wooden carvings and pottery for trade.",
                "Galleons could stay weeks in port waiting for favorable winds.",
                "Acapulco was connected by mule trails to Mexico City, linking Asian goods to Europe."
            };
    }

    public class Ranfacts4 : acafacts
    {
        public void Acafacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Acapulco, ", 215, 95, 0, 30);
            string y = acf[GTS.Program.rnd.Next(0, acf.Length)];
            j.AddPort("Acapulco", y);
            Colors.TypeColor(y, 215, 95, 0, 30);
        }
    }

    public class cartafacts
    {
        public static string[] ctf =
        {
                "Cartagena was a fortified port city on the Caribbean coast.",
                "Major exports included gold, silver, and emeralds from South America.",
                "The city had huge fortresses and cannons to fend off pirates.",
                "Local products like cocoa, tobacco, and rum were traded.",
                "Cartagena served as a stopover for ships heading to Havana or Spain.",
                "The port hosted a busy market for European imports like wine and olive oil.",
                "Indigenous and African laborers worked in loading and unloading cargo.",
                "Ships often waited for months due to hurricane season.",
                "Cartagena had strict customs regulations under Spanish rule.",
                "The city was known for its vibrant festivals and religious processions."
            };
    }

    class Ranfacts5 : cartafacts
    {
        public void Cartafacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Cartagena, ", 175, 255, 255, 30);
            string y = ctf[GTS.Program.rnd.Next(0, ctf.Length)];
            j.AddPort("Cartagena", y);
            Colors.TypeColor(y, 175, 255, 255, 30);
        }
    }

    class havfacts
    {
        public static string[] hvf =
        {
                "Havana was the most important Caribbean port for Spanish treasure fleets.",
                "Silver from the Americas was stored here before being shipped to Spain.",
                "Havana exported sugar, tobacco, and rum.",
                "The city had fortified walls and watchtowers for protection.",
                "Pirates and privateers often targeted ships near Havana.",
                "The harbor was deep and safe, attracting many transatlantic fleets.",
                "Local markets traded both European and African goods.",
                "Havana was a cultural hub with music, art, and religious traditions.",
                "The port facilitated trade between the Americas and Europe.",
                "Cuban coffee was becoming an important trade commodity."
            };
    }

    class Ranfacts6 : havfacts
    {
        public void Havfacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Havana, ", 255, 95, 135, 30);
            string y = hvf[GTS.Program.rnd.Next(0, hvf.Length)];
            j.AddPort("Havana", y);
            Colors.TypeColor(y, 255, 95, 135, 30);
        }

    }

    public class lisfacts
    {
        public static string[] lsf =
        {
                "Lisbon was the main European entry point for goods from Asia and the Americas.",
                "The city imported spices, silk, porcelain, and exotic woods.",
                "Portuguese merchants controlled trade routes to India and Brazil.",
                "Lisbon had large marketplaces and warehouses for storage.",
                "Exotic animals and plants were sometimes imported for royal collections.",
                "The city was a hub for shipbuilding and navigation expertise.",
                "Portuguese explorers often returned with rare artifacts and maps.",
                "Gold from Brazil passed through Lisbon before Europe.",
                "Guilds regulated trade and prices strictly.",
                "Lisbon was a financial center, using bills of exchange to facilitate trade."
            };
    }

    public class Ranfacts7 : lisfacts
    {
        public void Lisfacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Lisbon, ", 255, 255, 95, 30);
            string y = lsf[GTS.Program.rnd.Next(0, lsf.Length)];
            j.AddPort("Lisbon", y);
            Colors.TypeColor(y, 255, 255, 95, 30);
        }
    }

    public class sevfacts
    {
        public static string[] svf =
        {
                "Seville was the European hub for transatlantic trade with the Americas.",
                "Silver from Mexico and Peru flowed into Seville, funding Spanish empires.",
                "The Casa de Contratación regulated all trade with the New World.",
                "Goods included textiles, wine, olive oil, and exotic spices.",
                "Seville had canals and warehouses for storing imported goods.",
                "Traders often waited months for cargo to clear customs.",
                "Seville was home to wealthy merchant families who funded galleons.",
                "The city had rich architecture influenced by Moorish and Gothic styles.",
                "Market fairs attracted merchants from all over Europe.",
                "Seville’s port eventually declined as Cádiz grew more prominent."
            };
    }
    public class Ranfacts8 : sevfacts
    {
        public void Sevfacts(Journal j)
        {
            Colors.BoldTypeColor("\n\nFun fact about Seville, ", 0, 255, 95, 30);
            string y = svf[GTS.Program.rnd.Next(0, svf.Length)];
            j.AddPort("Seville", y);
            Colors.TypeColor(y, 0, 255, 95, 30);

        }
    }
}
