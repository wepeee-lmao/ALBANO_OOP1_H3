using Effects;
using FLHANDLING;
using GTS;
using Ports;
using SelectMain;
using Spectre.Console;
using Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Pstats
{
    public class Player
    {
        private string nm;
        private double gld;
        private int repu;
        private int compvoy;
        private int mrl;

        public string Nm { get { return nm; } private set { nm = value; } }
        public double Gld { get { return gld; } set { gld = value; } }
        public int Repu { get { return repu; } set { repu = value; } }
        public int Compvoy { get { return compvoy; } set { compvoy = value; } }

        public int Mrl { get { return mrl; } set { mrl = value; } }

        public List<(string, double, int)> nvent { get; set; }

        public Player(string name)
        {
            nm = name;
            gld = 1000;
            repu = 50;
            compvoy = 0;
            mrl = 60;
            nvent = new List<(string, double, int)>();
        }

     
        public void DisplayStats()
        {
            Console.Clear();

            string t = $"⚓ \x1b[1m\u001b[38;2;102;220;255mCaptain {nm}'s Log\u001b[0m ⚓";

            Effects.Border.DrawBoard2(t);


            string[] ds = { $"💰 \u001b[1m\u001b[38;2;244;244;244mSilver: {gld}\u001b[0m",
                            $"⭐  \u001b[1m\u001b[38;2;255;153;153mReputation: {repu}\u001b[0m", 
                            $"💪 \u001b[1m\u001b[38;2;255;204;153mCrew Morale: {mrl} %\u001b[0m", 
                            $"⛵ \u001b[1m\u001b[38;2;153;255;255mCompleted Voyages: {compvoy}\u001b[0m", 
                            $"📦 \u001b[1m\u001b[38;2;255;255;153mTypes of Items in Inventory: {nvent.Count} / 10\u001b[0m"};


            Effects.Border.DrawBNC(ds);

            if (nvent.Count == 0)
            {
                string l = $"  📦     \u001b[1m\u001b[38;2;255;255;204mCargo Manifest\u001b[0m    📦     ";
                Effects.Border.DrawBoard3(l);

                string[] n = { "\x1b[1m\u001b[38;2;215;0;0mIt's empty....\u001b[0m" };
                Effects.Border.DrawBNC(n);
            }
            else
            {
                string l = $"  📦     \u001b[1m\u001b[38;2;255;255;204mCargo Manifest\u001b[0m    📦     ";
                Effects.Border.DrawBoard3(l);
                var invLines = new List<string> {};

                foreach (var (iname, pc, hm) in nvent)
                {
                    invLines.Add($"\u001b[1m\u001b[38;2;255;205;102m{hm} {iname} ({pc} silver)\u001b[0m");
                }
                Border.DrawBNC(invLines.ToArray());
            }
        }

    }

    public class Journal
    {
        public List<string> GFact { get; set; } = new List<string>();
        public Dictionary<string, List<string>> PFact { get; set; } = new Dictionary<string, List<string>>();

        public void AddGen(string fact)
        {
            if (!GFact.Contains(fact))
            {
                GFact.Add(fact);
            }
        }

        public void AddPort(string port, string fact)
        {
            if (!PFact.ContainsKey(port))
            {
                PFact[port] = new List<string>();
            }
            if (!PFact[port].Contains(fact))
            {
                PFact[port].Add(fact);
            }
        }

        public void DispFact()
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string welc = "Knowledge Journal";
            Border.DrawBoard(welc);

            if (GFact.Count == 0)
            {
                string n = "You don't have enough collected knowledge yet. Keep on sailing and trading! ";
                Colors.TypeColor(n, 102, 255, 255, 30);
                return;
            }

            if (GFact.Count > 0)
            {
                AnsiConsole.MarkupLine("\n[bold cyan]General Facts Collected: [/]");
                var table = new Table();
                table.Border(TableBorder.Ascii2);
                table.Centered();
                table.AddColumn("[bold cyan]No.[/]");
                table.AddColumn("[bold cyan]Facts[/]");

                int i = 1;

                foreach (var f in GFact)
                {
                    table.AddRow(i.ToString(), f);
                    i++;
                }
                AnsiConsole.Write(table);
            }

            if (PFact.Count > 0)
            {
                foreach (var prt in PFact.Keys)
                {
                    AnsiConsole.MarkupLine($"\n[bold yellow]{prt} Facts Collected: [/]");

                    Table table = new();

                    table.Border(TableBorder.Ascii);
                    table.Centered();
                    table.Expand();
                    table.AddColumn("[bold yellow]No.[/]");
                    table.AddColumn("[bold yellow]Facts[/]");

                    int i = 1;

                    foreach (var f in PFact[prt])
                    {
                        table.AddRow(i.ToString(), f);
                        i++;
                    }
                    AnsiConsole.Write(table);
                }
            }
        }
    }

    public class BRival()
    {
        
        static readonly int reqrep = 30;
        static readonly int reqmrl = 30;
        static readonly int reqgld = 100;
        static readonly int voyneed = 4;

        public static void Triggready(Player p)
        {
            if(p.Compvoy == voyneed)
            {
                Console.Clear();
                Colors.TypeColor(".....The sea is awfully quiet, but a faint silhouette shined through the horizon", 153, 255, 255, 30);
                Thread.Sleep(800);
                Colors.TypeColor("\n.....A ship with black tattered sails. ", 153, 255, 255, 30);
                Thread.Sleep(500);
                Colors.BoldTypeColor("\n\nAt last, you and Captain Alonso de Varela meet once again. \n", 255, 102, 102, 30);
                Thread.Sleep(500);

                Colors.BoldTypeColor("A chilling loud voice boomed from Captain Varela:  \n", 255, 102, 102, 30);
                Colors.BoldTypeColor("\nSo I heard, you're trying to dominate this seas? YOU STOLE MY COMMAND AND HONOR!", 255, 255, 51, 30);

                if(p.Repu < reqrep)
                {
                    Colors.TypeColor("\n\nYour reputation is not enough.", 255, 128, 0, 30);
                    Thread.Sleep(500);
                    Colors.TypeColor("\nYour crew doubts you. Your crew decides to form a mutiny and rejoin Captain Varela.", 255, 128, 0, 30);
                    Colors.BoldTypeColor("\n\n☠️ GAME OVER ☠️", 255, 0, 0, 30);
                    Thread.Sleep(2000);
                    FDelete.FDel(p);
                    Environment.Exit(0);
                }

                if (p.Mrl < reqmrl)
                {
                    Colors.TypeColor("\n\nYour crew's morale is dangerously low. They refuse to fight for you.", 255, 128, 0, 30);
                    Thread.Sleep(500);
                    Colors.TypeColor("\nMorale collapsed. Your crew decides to form a mutiny and to leave you behind.", 255, 128, 0, 30);
                    Colors.BoldTypeColor("\n\n☠️ GAME OVER ☠️", 255, 0, 0, 30);
                    Thread.Sleep(2000);
                    FDelete.FDel(p);
                    Environment.Exit(0);
                }

                if (p.Gld < reqgld)
                {
                    Colors.TypeColor("\n\nYour gold is not enough.", 255, 128, 0, 30);
                    Thread.Sleep(500);
                    Colors.TypeColor("\nYour abandons you. Your crew decides to form a mutiny and rejoin Captain Varela.", 255, 128, 0, 30);
                    Colors.BoldTypeColor("\n\n☠️ GAME OVER ☠️", 255, 0, 0, 30);
                    Thread.Sleep(2000);
                    FDelete.FDel(p);
                    Environment.Exit(0);
                }

                Colors.BoldTypeColor("\nYou gaze at the rival. This is your chance for final reckoning.", 0, 255, 0, 30);

               
                int bhp = 100;
                int php = 100;

              
                while (bhp > 0 && php > 0)
                {
                    string welc = "Choose how to approach Captain Varela";
                    string[] opt = { "\u001b[38;2;215;0;0mCharge head-on (riskier, relies on QTE)\u001b[0m",
                                     "\u001b[38;2;0;255;0mTry to outmaneuver and defend (safer, relies on QTE)\u001b[0m",
                                     "\u001b[38;2;51;255;255mAttempt a knowledge taunt to unsettle them (quiz)\u001b[0m" };


                    Menu men = new Menu(opt, welc);
                    int ch = men.MenuRun();

                    switch (ch)
                    {
                        case 0:

                            Console.WriteLine("\n\u001b[1m\u001b[38;2;255;255;102m⚡ Quick-Time! Press [A] FAST to strike!\u001b[0m\n");
                            bool suc = false;

                            DateTime sec = DateTime.Now.AddSeconds(3);

                            while (DateTime.Now < sec)
                            {
                               
                                int tl = (int)Math.Ceiling((sec - DateTime.Now).TotalSeconds);
                                Console.Write($"\r\u001b[1m\u001b[38;2;255;255;102m⏳Time Left: {tl} \u001b[0m");

                                int dmg = Program.rnd.Next(20, 30);

                                if (Console.KeyAvailable)
                                {
                                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                                    var kp = keyInfo.Key;

                                    Console.WriteLine("\n\n");
                                    if (kp == ConsoleKey.A)
                                    {
                                        string[] at = { "☠️ 🤺        ⚔️        🤺 ", "🤺💥⚔️💥🤺 ", " 🤺      💨🤺" };

                                        for (int i = 0; i < at.Length; i++)
                                        {
                                            Console.Write($"\r{at[i]}");
                                            Thread.Sleep(500);
                                        }

                                        bhp -= dmg;
                                        Colors.BoldTypeColor("\n\n⚔ Critical Hit! ", 95, 255, 0, 30);
                                        Colors.BoldTypeColor($"\n\n💥 Perfect timing! {dmg} damage dealt.!", 255, 0, 0, 30);
                                        suc = true;
                                        
                                    }
                                }
                                Thread.Sleep(100);
                            }
                            if (!suc)
                            {
                                int dmg = Program.rnd.Next(30, 50);
                                php -= dmg;
                                Colors.BoldTypeColor($"\n\n❌ You fumbled the timing! You leave an opening and take {dmg} damage.", 255, 0, 0, 30);
                                Thread.Sleep(1000);
                            }
                            break;
                        case 1:
                            Console.WriteLine("\n\u001b[1m\u001b[38;2;255;255;102m⚡ Quick-Time! Press [D] FAST to defend!\u001b[0m\n");

                            bool suc2 = false;

                            DateTime sec1 = DateTime.Now.AddSeconds(3);

                            while (DateTime.Now < sec1)
                            {
                                int tl = (int)Math.Ceiling((sec1 - DateTime.Now).TotalSeconds);
                                Console.Write($"\r\u001b[1m\u001b[38;2;255;255;102m⏳Time Left: {tl} \u001b[0m");

                                int dmg = Program.rnd.Next(30, 50);

                                if (Console.KeyAvailable)
                                {
                                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                                    var kp = keyInfo.Key;

                                    Console.WriteLine("\n\n");
                                    if (kp == ConsoleKey.D)
                                    {
                                        string[] at = { "☠️ 🤺        ⚔️        🤺 ", "🤺🛡️💥🤺 ", " 🤺🛡️      💨🤺" };

                                        for (int i = 0; i < at.Length; i++)
                                        {
                                            Console.Write($"\r{at[i]}");
                                            Thread.Sleep(500);
                                        }

                                        Colors.BoldTypeColor("\n\n 🛡️ You successfully brace! Damage will be reduced this turn ", 95, 255, 0, 30);
                                        suc2 = true;

                                    }
                                }
                                Thread.Sleep(100);
                            }
                            if (!suc2)
                            {
                                int dmg = Program.rnd.Next(30, 50);
                                php -= dmg;
                                Colors.BoldTypeColor($"\n\n❌ Failed defense! You take {dmg} damage.", 255, 0, 0, 30);
                                Thread.Sleep(1000);

                            }
                            break;

                        case 2:
                            Console.Clear();
                            Colors.BoldTypeColor("\n🧠 Captain Varela smirks…", 255, 102, 102, 30);
                            Colors.TypeColor("\n\nYou think you're worthy? Then answer me THIS, supposed ‘Captain’...", 255, 200, 200, 30);
                            Thread.Sleep(800);

                            string[] fvers =
                            {
                                "It is FALSE that",
                                "Contrary to common belief,",
                                "Some claim (incorrectly) that",
                                "This statement is NOT true:",
                                "Historians dispute this:",
                            };

                            string[] allfacts = 
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

                            int cor = 0;

                            for (int q = 1; q <= 3; q++)
                            {
                                Console.Clear();
                                string fact = allfacts[GTS.Program.rnd.Next(allfacts.Length)];
                               
                                bool ATrue = Program.rnd.Next(2) == 0;

                                string dp;

                                if (ATrue)
                                {
                                    dp = fact;
                                }
                                else
                                {
                                    string prefix = fvers[Program.rnd.Next(fvers.Length)];
                                    dp = prefix + " " + fact;
                                }

                                Colors.BoldTypeColor($"\nQuestion {q}: TRUE or FALSE?", 255, 255, 102, 30);
                                Console.WriteLine($"\n🔹 {dp}");
                                Console.Write("\nPress T for true, F for false ");

                                ConsoleKey kp;
                                do
                                {
                                    kp = Console.ReadKey(true).Key;
                                } while (kp != ConsoleKey.T && kp != ConsoleKey.F);

                                bool pTrue = kp == ConsoleKey.T;

                                Console.WriteLine();

                                if (pTrue == ATrue)
                                {
                                    cor++;
                                    Colors.BoldTypeColor("\n✔  Correct! Varela looks annoyed...", 0, 255, 0, 30);
                                }
                                else
                                {
                                    Colors.BoldTypeColor("\n✘  Wrong! Varela laughs mockingly.", 255, 0, 0, 30);
                                }

                                Thread.Sleep(900);
                            }

                            Console.Clear();

                            if (cor >= 2)
                            {
                                int dmg = Program.rnd.Next(35, 50);
                                bhp -= dmg;

                                Colors.BoldTypeColor("\n🔥 Your knowledge SHAKES Captain Varela!", 0, 255, 128, 30);
                                Colors.BoldTypeColor($"He loses {dmg} HP from sheer humiliation!", 255, 255, 0, 30);
                            }
                            else
                            {
                                int dmg = Program.rnd.Next(35, 40);
                                php -= dmg;

                                Colors.BoldTypeColor("\n💀 You fail the taunt!", 255, 0, 0, 30);
                                Colors.TypeColor($"Varela mocks you and fires a volley!\nYou take {dmg} damage!", 255, 150, 150, 30);
                            }
                            Thread.Sleep(1500);
                            break;
                            

                    }
                }

                if (php > 0)
                {
                    Colors.BoldTypeColor("\n🏴‍☠️ Victory! Captain Alonso de Varela is defeated. The seas are yours!", 128, 255, 0, 30);
                    Thread.Sleep(2000);
                    FDelete.FDel(p);
                    Environment.Exit(0);
                }
                else
                {
                    Colors.BoldTypeColor("\n💀 You have been defeated. Your crew abandons you. ☠️ GAME OVER ☠️", 255, 0, 0, 30);
                    Thread.Sleep(2000);
                    FDelete.FDel(p);
                    Environment.Exit(0);
                }
            }
        }

}

}
