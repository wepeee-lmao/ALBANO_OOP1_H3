using Effects;
using Events;
using Facts;
using FLHANDLING;
using Namotion.Reflection;
using Ports;
using Pstats;
using SelectMain;
using SelectMain;
using Spectre.Console;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using static System.Console;

namespace GTS
{
    public class Program
    {
        public static Random rnd = new Random();

        public static void Main()
        {
            Console.Title = "Galleon Trade Simulator";
            Player playr = GetName();
            Journal j = new Journal();

            while(true)
            {
                Main2(playr, j);
            }
           
        }

        public static Player GetName()
        {
            
            while (true)
            {
                Console.Clear();
                Colors.TypeColor("Hey there! Before starting, please enter your username: ", 135, 255, 0, 10);


                string pn = Console.ReadLine();

                if (pn != null)
                {
                    pn = pn.Trim();
                }
                else
                {
                    pn = "  ";
                }

                if (string.IsNullOrEmpty(pn))
                {
                    AnsiConsole.MarkupLine($"[{Color.Red3.ToMarkup()}]I'm sorry, I don't think you entered anything at all.[/]");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }
                else
                {

                    Player playr = new Player(pn);

                    Console.Clear();

                    Colors.Glow($"Welcome Captain {pn} of Nuestra Señora del Rosario!");

                    Loading.Monkey();

                    return playr;
                }

                
            }
        }


        public static void Main2(Player playr, Journal j)
        {

            bool x = true;
            while (x)
            {
                FWrite fw = new FWrite();
                string fp1 = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{playr.Nm}.stats.txt";
                string fp2 = $@"C:\Users\Kiarra\OneDrive\Desktop\CODES\OOP 1\FINALS_GTS\GTS_FILES\{playr.Nm}.journ.txt";

                if (!File.Exists(fp1))
                {
                    Loading.Voyint();

                }

                string welc = @" GALLEON TRADE SIMULATOR";
                string[] opt;

                if (!File.Exists(fp1))
                {
                    opt = new string[]{ "\u001b[38;2;175;215;0m⚓ Start New Voyage\u001b[0m",
                                 "\u001b[38;2;215;0;255m📝 View Trade Record\u001b[0m",
                                 "\u001b[38;2;133;255;102m📜 Knowledge Journal\u001b[0m",
                                  "\u001b[38;2;95;255;0m🚮 Delete Trade Record\u001b[0m",
                                    "\u001b[38;2;215;0;0m❌ Exit Game\u001b[0m" };
                }
                else
                {
                    opt = new string[]{ "\u001b[38;2;95;255;0m⚓ Continue Voyage\u001b[0m",
                                 "\u001b[38;2;215;0;255m📝 View Trade Record\u001b[0m",
                                 "\u001b[38;2;255;178;102m📜 Knowledge Journal\u001b[0m",
                                  "\u001b[38;2;175;215;0m🚮 Delete Trade Record\u001b[0m",
                                    "\u001b[38;2;215;0;0m❌ Exit Game\u001b[0m" };
                }

                Menu Main = new Menu(opt, welc);
                int ch = Main.MenuRun();

                switch (ch)
                {
                    case 0:
                        if (!File.Exists(fp1) && !File.Exists(fp2))
                        {
                            FNew.FCreate1(playr);
                            FNew.FCreate2(playr, j);
                        }
                        else
                        {
                            FCont.LoadPlayer(playr);
                            FCont.LoadPlayer2(playr, j);
                        }
                       
                        Svoy(playr, j);
                        break;

                    case 1:
                        Console.Clear();
                        FCont.LoadPlayer(playr);
                        playr.DisplayStats();
                        string n = $"  \x1b[6m\u001b[38;2;215;215;0m>> Press any key to return to Main Menu <<\u001b[0m";
                        Border.DrawBoard2(n);
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        FCont.LoadPlayer2(playr, j);
                        j.DispFact();
                        Console.WriteLine($"\x1b[6m\u001b[38;2;215;215;0m Press any key to return to Main Menu\u001b[0m");
                        Console.ReadKey();
                        break;
                    case 3:
                        x = false;
                        Loading.Bye();
                        Console.WriteLine("\n\n\u001b[1m\u001b[38;2;215;0;0mDeleted file successfully.\u001b[0m");
                        FDelete.FDel(playr);
                        Console.WriteLine("\n");
                        Environment.Exit(0);
                        break;
                    case 4:
                        fw.Data(playr);
                        fw.Data2(playr, j);
                        x = false;
                        Loading.Bye();
                        Console.WriteLine("\n");
                        Environment.Exit(0);
                        break;
                }

            }
        }

        public static void Svoy(Player p, Journal j)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    string welc = "Choose Continent";

                    string[] opt = { "\x1b[1m\u001b[38;2;246;147;111m⛩️ ASIA\u001b[0m", 
                                    "\u001b[1m\u001b[38;2;247;185;38m🏜️ LATIN AMERICA\u001b[0m", 
                                    "\u001b[1m\u001b[38;2;111;246;196m🏰 EUROPE\u001b[0m", 
                                    "\u001b[38;2;255;255;0mReturn to Main Menu\u001b[0m" };

                    Menu Main = new Menu(opt, welc);
                    int ch = Main.MenuRun();

                    switch (ch)
                    {
                        case 0:
                            SvoyAsia(p, j);
                            break;
                        case 1:
                            SvoyAme(p, j);
                            break;
                        case 2:
                            SvoyEu(p, j);
                            break;
                        case 3:
                            Main2(p, j);
                            return;
                        default:
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                }
            }
        }

        public static void SvoyAsia(Player p, Journal j)
        {
            Console.Clear();
            Colors.TypeColor("You have chosen to sail to Asia! Prepare your ship for the voyage ahead!", 0, 175, 215, 30);
            Thread.Sleep(200);

            string welc = "Choose your destination port in Asia";

            string[] opt1 = { "\u001b[38;2;255;135;215m🏝️ Manila (Philippines, Central Hub)\u001b[0m",
                                     "\u001b[38;2;215;255;175m🕌 Malacca (Malaysia)\u001b[0m",
                                     "\u001b[38;2;215;0;95m🏯 Macau (China)\u001b[0m",
                                     "\u001b[38;2;255;255;0mReturn to Continents\u001b[0m"};
            Menu menu = new Menu(opt1, welc);
            int ch = menu.MenuRun();

            prt currentPort;

            switch (ch)
            {
                case 0:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Manila();
                    break;
                case 1:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Malacca();
                    break;
                case 2:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Macau();
                    break;
                case 3:
                    Svoy(p, j);
                    return;
                default:
                    return;
            }

            Svoy2As(p, currentPort, j);
        }

        public static void SvoyAme(Player p, Journal j)
        {
            Console.Clear();
            Colors.TypeColor("You have chosen to sail to Latin America! Prepare your ship for the voyage ahead!", 0, 175, 215, 30);
            Thread.Sleep(200);

            prt currentPort;
            string welc = "Choose your destination port in Latin America";

            string[] opt1 = { "\u001b[38;2;215;95;0m🌶️ Acapulco (Mexico)\u001b[0m",
                              "\u001b[38;2;175;255;255m💃 Cartagena (Colombia)\u001b[0m",
                              "\u001b[38;2;255;95;135m🌴 Havana (Cuba)\u001b[0m",
                              "\u001b[38;2;255;255;0mReturn to Continents\u001b[0m"};
            Menu menu = new Menu(opt1, welc);
            int ch = menu.MenuRun();

            switch (ch)
            {
                case 0:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Acapulco();
                    break;
                case 1:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Cartagena();
                    break;
                case 2:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Havana();
                    break;
                case 3:
                    Svoy(p, j);
                    return;
                default:
                    return;
            }
            Svoy2Am(p, currentPort, j);
        }

        public static void SvoyEu(Player p, Journal j)
        {
            Console.Clear();
            Colors.TypeColor("You have chosen to sail to Europe! Prepare your ship for the voyage ahead!", 0, 175, 215, 30);
            Thread.Sleep(500);

            prt currentPort;
            string welc = "Choose your destination port in Europe";
            string[] opt1 = { "\u001b[38;2;255;255;95m🍻 Lisbon (Portugal)\u001b[0m",
                              "\u001b[38;2;0;255;95m⚔️ Seville (Spain)\u001b[0m",
                              "\u001b[38;2;255;255;0mReturn to Continents\u001b[0m"};
            Menu menu = new Menu(opt1, welc);
            int ch = menu.MenuRun();

            switch (ch)
            {
                case 0:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Lisbon();
                    break;
                case 1:
                    new RanEvent().Invoke(p);
                    Loading.Boat();
                    currentPort = new Seville();
                    break;
                case 2:
                    Svoy(p, j);
                    return;
                default:
                    return;
            }
            Svoy2Eur(p, currentPort, j);
        }

        public static void Svoy2As(Player p, prt currentPort, Journal j)
        {
            FWrite fw = new FWrite();
            p.Compvoy++;
            fw.Data(p);
            fw.Data2(p, j);

            if (p.Compvoy == 4)
            {
                Colors.BoldTypeColor("\n⚠️ Something stirs in the horizon…", 255, 80, 80, 30);
                Thread.Sleep(1200);

                BRival.Triggready(p);
            }

            while (true)
            {
                Console.Clear();

                new RanFacts().Grfacts(j);

                if (currentPort.Nm == "Manila")
                {
                    new Ranfacts1().Mfacts(j);
                }
                else if (currentPort.Nm == "Malacca")
                {
                    new Ranfacts2().Mlfacts(j);
                }
                else if (currentPort.Nm == "Macau")
                {
                    new Ranfacts3().Macfacts(j);
                }

                Loading.Earth();
                
                string welc = $"Welcome to {currentPort.Nm}, What would you like to do?";
                string[] opt = { "\u001b[38;2;0;175;95m💰 Buy Goods\u001b[0m", "\u001b[38;2;95;215;215m🪙 Sell Goods\u001b[0m",
                                 "\u001b[38;2;133;255;102m📜 Knowledge Journal\u001b[0m", "\u001b[38;2;255;255;0m Return to Ports\u001b[0m" };

                Menu Main = new Menu(opt, welc);
                int ch = Main.MenuRun();

                switch (ch)
                {
                    case 0:
                        BuyGoods(p, currentPort, j);
                        fw.Data(p);
                        fw.Data2(p, j);
                        Console.WriteLine("\n");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case 1:
                        SellGoods(p, currentPort, j);
                        fw.Data(p);
                        fw.Data2(p, j);
                        Console.WriteLine("\n");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        FCont.LoadPlayer2(p, j);
                        j.DispFact();
                        Console.WriteLine($"\x1b[6m\u001b[38;2;215;215;0m Press any key to return to Main Menu\u001b[0m");
                        Console.ReadKey();
                        break;
                    case 3:
                        SvoyAsia(p, j);
                        return;
                    default:
                        break;
                }
            }
        }

        public static void Svoy2Am(Player p, prt currentPort, Journal j)
        {
            FWrite fw = new FWrite();
            p.Compvoy++;
            fw.Data(p);
            fw.Data2(p, j);

            if (p.Compvoy == 4)
            {
                Colors.BoldTypeColor("\n⚠️ Something stirs in the horizon…", 255, 80, 80, 30);
                Thread.Sleep(1200);

                BRival.Triggready(p);
            }

            while (true)
            {
                Console.Clear();

                new RanFacts().Grfacts(j);

                if (currentPort.Nm == "Acapulco")
                {
                    new Ranfacts4().Acafacts(j);

                }
                else if (currentPort.Nm == "Cartagena")
                {
                    new Ranfacts5().Cartafacts(j);
                }
                else if (currentPort.Nm == "Havana")
                {
                    new Ranfacts6().Havfacts(j);
                }
                
                Loading.Earth();

                string welc = $"Welcome to {currentPort.Nm}, What would you like to do?";
                string[] opt = { "\u001b[38;2;0;175;95m💰 Buy Goods\u001b[0m", "\u001b[38;2;95;215;215m🪙 Sell Goods\u001b[0m",
                                 "\u001b[38;2;133;255;102m📜 Knowledge Journal\u001b[0m", "\u001b[38;2;255;255;0m Return to Ports\u001b[0m" };

                Menu Main = new Menu(opt, welc);
                int ch = Main.MenuRun();

                switch (ch)
                {
                    case 0:
                        BuyGoods(p, currentPort, j);
                        fw.Data(p);
                        fw.Data2(p, j);
                        Console.WriteLine("\n");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case 1:
                        SellGoods(p, currentPort, j);
                        fw.Data(p);
                        fw.Data2(p, j);
                        Console.WriteLine("\n");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        FCont.LoadPlayer2(p, j);
                        j.DispFact();
                        Console.WriteLine($"\x1b[6m\u001b[38;2;215;215;0m Press any key to return to Main Menu\u001b[0m");
                        Console.ReadKey();
                        break;
                    case 3:
                        SvoyAme(p, j);
                        return;
                    default:
                        break;
                }
            }
        }

        public static void Svoy2Eur(Player p, prt currentPort, Journal j)
        {
            FWrite fw = new FWrite();
            p.Compvoy++;
            fw.Data(p);
            fw.Data2(p, j);

            if (p.Compvoy == 4)
            {
                Colors.BoldTypeColor("\n⚠️ Something stirs in the horizon…", 255, 80, 80, 30);
                Thread.Sleep(1200);

                BRival.Triggready(p);
            }
                while (true)
                {
                    Console.Clear();
                    new RanFacts().Grfacts(j);

                    if (currentPort.Nm == "Lisbon")
                    {
                        new Ranfacts7().Lisfacts(j);
                    }
                    else if (currentPort.Nm == "Seville")
                    {
                        new Ranfacts8().Sevfacts(j);
                    }

                    Loading.Earth();

                    string welc = $"Welcome to {currentPort.Nm}, What would you like to do?";
                    string[] opt = { "\u001b[38;2;0;175;95m💰 Buy Goods\u001b[0m", "\u001b[38;2;95;215;215m🪙 Sell Goods\u001b[0m",
                                 "\u001b[38;2;133;255;102m📜 Knowledge Journal\u001b[0m", "\u001b[38;2;255;255;0m Return to Ports\u001b[0m" };

                    Menu Main = new Menu(opt, welc);
                    int ch = Main.MenuRun();
                    switch (ch)
                    {
                        case 0:
                            BuyGoods(p, currentPort, j);
                            fw.Data(p);
                            fw.Data2(p, j);
                            Console.WriteLine("\n");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        case 1:
                            SellGoods(p, currentPort, j);
                            fw.Data(p);
                            fw.Data2(p, j);
                            Console.WriteLine("\n");
                            System.Threading.Thread.Sleep(3000);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            FCont.LoadPlayer2(p, j);
                            j.DispFact();
                            Console.WriteLine($"\x1b[6m\u001b[38;2;215;215;0m Press any key to return to Main Menu\u001b[0m");
                            Console.ReadKey();
                            break;
                        case 3:
                            SvoyEu(p, j);
                            return;
                        default:
                            break;
                    }
                }
            
        }
        
        
        public static void BuyGoods(Player p, prt port, Journal j)
        {
                Console.Clear();

                string welc = $"Goods available in {port.Nm}";
                var opt = port.GPrices;

                BGoods bg = new BGoods(opt, welc);
                var ch = bg.MenuRun();

                var sel = opt.ElementAt(ch);

                string t = "How many would you like to buy?";
                string[] opt2 = { "1", "2", "3", "4", "5", "Return to list of Items" };
                Menu2 men = new Menu2(opt2, t);
                var it = men.MenuRun();

            if (it == 5)
            {
                BuyGoods(p, port, j);
            }
            else
            {
                int[] hm = { 1, 2, 3, 4, 5 };

                double price = sel.Value * hm[it];

                if (p.Gld >= price)
                {
                    p.Gld -= price;

                    var id = p.nvent.FindIndex(x => x.Item1 == sel.Key);

                    if (id != -1)
                    {
                        var ex = p.nvent[id];
                        p.nvent[id] = (ex.Item1, ex.Item2, ex.Item3 + hm[it]);
                    }
                    else
                    {
                        p.nvent.Add((sel.Key, sel.Value, hm[it]));
                    }

                    FWrite fw = new FWrite();
                    fw.Data(p);
                    Console.WriteLine("\n");
                    Colors.BoldTypeColor($"💵 You bought {hm[it]} {sel.Key} for {price} silver!", 175, 255, 95, 30);
                    return;
                }
                else
                {
                    Colors.BoldTypeColor("Not enough silver! ", 175, 0, 0, 50);
                }
            }
        }
            
        
        public static void SellGoods(Player p, prt port, Journal j)
        {
            
            Console.Clear();

            if (p.nvent.Count == 0)
            {
                Console.WriteLine("\n");
                Colors.BoldTypeColor("Did you forget to check your inventory? You have nothing to sell! ", 175, 0, 0, 50);
                System.Threading.Thread.Sleep(1000);
            }
            else if (p.nvent.Count > 10)
            {
                Console.WriteLine("\n");
                Colors.BoldTypeColor("You're carrying too many items! ", 175, 0, 0, 50);
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                string welc = "Inventory";
                var opts = p.nvent;
                SGoods sg = new SGoods(opts, welc);
                var ch = sg.MenuRun();

                var sel = opts.ElementAt(ch);

                string t = "How many would you like to Sell?";
                string[] opt2 = { "1", "2", "3", "4", "5", "Return to Inventory" };

                Menu2 men = new Menu2(opt2, t);

                var mn = men.MenuRun();

                if (mn == 5)
                {
                    SellGoods(p, port, j);
                }

                int[] hm = { 1, 2, 3, 4, 5 };

                double price = sel.Item2 * hm[mn];

                if (sel.Item3 < hm[mn])
                {
                    Colors.BoldTypeColor("Not enough items to sell! ", 175, 0, 0, 50);
                }
                else
                {
                    string[] asia = { "Manila", "Macau", "Malacca" };
                    string[] us = { "Acapulco", "Havana", "Cartagena" };
                    string[] eu = { "Seville", "Lisbon" };

                    if (port.GPrices.ContainsKey(sel.Item1))
                    {
                        price *= 0.9;
                    }
                    else if (asia.Contains(port.Nm))
                    {
                        price *= 3;

                    }
                    else if (us.Contains(port.Nm))
                    {
                        price *= 5;
                    }
                    else
                    {
                        price *= 4;

                    }

                    p.Gld += price;

                    if (sel.Item3 > hm[mn])
                    {
                        p.nvent[ch] = (sel.Item1, sel.Item2, sel.Item3 - hm[mn]);
                    }
                    else
                    {
                        p.nvent.RemoveAt(ch);
                    }

                    FWrite fw = new FWrite();
                    fw.Data(p);
                    Colors.BoldTypeColor($"💵 Nice! You sold {hm[mn]} {sel.Item1} for {price:F2} silver !", 175, 255, 95, 30);
                }
            }
                
        }

    }
}
