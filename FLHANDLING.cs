using Events;
using Pstats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FLHANDLING
{
    public class FNew
    {
        public static void FCreate1(Player p)
        {
            string fp = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.stats.txt";

            try
            {
                using (StreamWriter writer = File.CreateText(fp))
                {
                    writer.WriteLine("⚓ Captain's Log ⚓");
                    writer.WriteLine($"Captain: {p.Nm}");
                    writer.WriteLine($"Gold: {p.Gld}");
                    writer.WriteLine($"Reputation: {p.Repu}");
                    writer.WriteLine($"Crew Morale: {p.Mrl} %");
                    writer.WriteLine($"Completed Voyages: {p.Compvoy}");
                    writer.WriteLine($"Inventory: {p.nvent.Count} / 10");

                    if (p.nvent.Count == 0)
                    {
                        writer.WriteLine("  (No items in cargo hold)");
                    }
                    else
                    {
                        writer.WriteLine("  Cargo Manifest:");
                        foreach (var item in p.nvent)
                        {
                            writer.WriteLine($"   - {item.Item1} | Price: {item.Item2} | Qty: {item.Item3}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create file.");
            }
        }

        public static void FCreate2(Player p, Journal j)
        {
            string fp = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.journ.txt";

            try
            {
                using (StreamWriter writer = File.CreateText(fp))
                {
                    if (j.GFact.Count == 0 && j.PFact.Count == 0)
                    {
                        writer.WriteLine("(No collected facts yet)");
                    }
                    else
                    {
                        writer.WriteLine("Knowledge Collected\n");
                        writer.WriteLine("  ");
                        writer.WriteLine("General Facts:");
                        foreach (var ent in j.GFact)
                        {
                            writer.WriteLine($"GF : {ent}");
                        }

                        writer.WriteLine("\n============================================================\n");

                        foreach (var ent2 in j.PFact)
                        {
                            writer.WriteLine($"Port : {ent2.Key}");
                            foreach (var fact in ent2.Value)
                            {
                                writer.WriteLine($"PF : {fact}");

                            }
                        }

                        writer.WriteLine("\n============================================================\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write file.");
            }
        }
    }

    public class FWrite
    {
        public void Data(Player p)
        {
            try
            {
                string fp = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.stats.txt";

                using (StreamWriter writer = new StreamWriter(fp, false))
                {
                    writer.WriteLine("⚓ Captain's Log ⚓");
                    writer.WriteLine($"Captain: {p.Nm}");
                    writer.WriteLine($"Gold: {p.Gld}");
                    writer.WriteLine($"Reputation: {p.Repu}");
                    writer.WriteLine($"Crew Morale: {p.Mrl} %");
                    writer.WriteLine($"Completed Voyages: {p.Compvoy}");

                    if (p.nvent.Count == 0)
                    {
                        writer.WriteLine("  (No items in cargo hold)");
                    }
                    else
                    {
                        writer.WriteLine("  Cargo Manifest:");
                        foreach (var item in p.nvent)
                        {
                            writer.WriteLine($"   - {item.Item1} | Price: {item.Item2} | Qty: {item.Item3}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write file.");
            }
        }

        public void Data2(Player p, Journal j)
        {
            string fp = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.journ.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(fp, false))
                {
                    if (p.nvent.Count == 0)
                    {
                        writer.WriteLine("  (No collected facts yet)");
                    }
                    else
                    {
                        writer.WriteLine("Knowledge Collected");

                        writer.WriteLine("General Facts:");
                        foreach (var ent in j.GFact)
                        {
                            writer.WriteLine($"GF : {ent}");
                        }

                        writer.WriteLine("\n============================================================\n");

                        foreach (var ent2 in j.PFact)
                        { 
                            writer.WriteLine($"Port : {ent2.Key}");

                            foreach (var fact in ent2.Value)
                            {
                                writer.WriteLine($"PF : {fact}");
                            }
                            writer.WriteLine("\n============================================================\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write file.");
            }
        }
    }
    public class FCont
    {
        public static void LoadPlayer(Player p)
        {
            try
            {
                string fp = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.stats.txt";

                if (!File.Exists(fp))
                {
                    return;
                }

                string[] lines = File.ReadAllLines(fp);
                p.nvent.Clear();


                foreach (string line in lines)
                {
                    if (line.StartsWith("Gold:"))
                    {
                        p.Gld = int.Parse(line.Split(':')[1].Trim());
                    }
                    else if (line.StartsWith("Reputation:"))
                    {
                        p.Repu = int.Parse(line.Split(':')[1].Trim());
                    }
                    else if (line.StartsWith("Crew Morale:"))
                    {
                        p.Mrl = int.Parse(line.Split(':')[1].Replace("%", "").Trim());
                    }
                    else if (line.StartsWith("Completed Voyages:"))
                    {
                        p.Compvoy = int.Parse(line.Split(':')[1].Trim());
                    }
                    else if (line.TrimStart().StartsWith("-"))
                    {
                        var parts = line.Split('|');
                        string name = parts[0].Replace("-", "").Trim();

                        double price = double.Parse(parts[1].Replace("Price:", "").Trim());
                        int qty = int.Parse(parts[2].Replace("Qty:", "").Trim());

                        p.nvent.Add((name, price, qty));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load file.");
            }
        }


        public static void LoadPlayer2(Player p, Journal j)
        {
            try
            {
                string fp = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.journ.txt";

                if (!File.Exists(fp))
                {
                    return;
                }

                string[] lines = File.ReadAllLines(fp);
                
                j.GFact.Clear();
                j.PFact.Clear();

                string cp = null;
              
                foreach(var line in lines)
                {
                    if(line.StartsWith("GF : "))
                    {
                        string fact = line.Substring(5).Trim();
                        j.AddGen(fact);
                    }
                    else if(line.StartsWith("Port :"))
                    {
                        cp = line.Substring(7).Trim();
                    }
                    else if(line.StartsWith("PF :") && cp != null)
                    {
                        string fact = line.Substring(5).Trim();
                        j.AddPort(cp, fact);

                    }
                    else if(line.Trim() == "============================================================")
                    {
                        cp = null;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load file.");
            }
        }
    }
    public class FDelete
    {
        public static void FDel(Player p)
        {
            string fp1 = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.stats.txt";
            string fp2 = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{p.Nm}.journ.txt";

            try
            {
                File.Delete(fp1);
                File.Delete(fp2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to delete file");
            }
        }
    }
}
