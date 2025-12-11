using Effects;
using GTS;
using Pstats;
using SelectMain;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Events
{
    class RanEvent
    {
        static evnt GenRdmEvent()
        {
            int ev = Program.rnd.Next(0, 4);

            switch(ev)
            {
                case 0:
                    System.Threading.Thread.Sleep(1000);
                    return new wpool();
                case 1:
                    System.Threading.Thread.Sleep(1000);
                    return new rivtrad();
                case 2:
                    System.Threading.Thread.Sleep(1000);
                    return new pirate();
                case 3:
                    System.Threading.Thread.Sleep(1000);
                    return new evnt();
                default:
                    System.Threading.Thread.Sleep(1000);
                    return new evnt();
            }
        }

        public void Invoke(Player p)
        {
            evnt ev = GenRdmEvent();
            ev.TriggEvent(p);
        }
    }

    public class evnt
    {
        public virtual void TriggEvent(Player p)
        {
            string t = $"Calm voyage ahead...";

            foreach (char c in t)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(50);
            }
        }
    }

    public class wpool : evnt
    {
        public override void TriggEvent(Player p)
        {

            Console.Clear();
            int res = Program.rnd.Next(0, 20);

            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Colors.BoldTypeColor("The sea starts to churn violently.... A whirlpool is forming near your ship!", 175, 255, 255, 30);
            Console.WriteLine("\n");
            
            Console.WriteLine("\n\u001b[1m\u001b[38;2;255;255;102m🌊⚡ QUICK! Press [D] to steer right or [A] to steer left! \u001b[0m\n");
            bool suc2 = false;

            DateTime sec = DateTime.Now.AddSeconds(3);

            while (DateTime.Now < sec)
            {
                int tl = (int)Math.Ceiling((sec - DateTime.Now).TotalSeconds);
                Console.Write($"\r\u001b[1m\u001b[38;2;255;255;102m⏳Time Left: {tl} \u001b[0m");

               
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    var kp = keyInfo.Key;

                    Console.WriteLine("\n\n");
                    if (kp == ConsoleKey.D || kp == ConsoleKey.A)
                    {
                        
                        int r = GTS.Program.rnd.Next(10, 15);
                        int ml = GTS.Program.rnd.Next(10, 20);
                        p.Repu += r;
                        p.Mrl += ml;
                        Colors.BoldTypeColor($"\n\n🚢🌪️ You steer hard and escape the whirlpool! +{r} Reputation +{ml} Crew Morale", 175, 255, 255, 30);

                        suc2 = true;
                        break;
                    }
                }
                Thread.Sleep(100);
            }
            if (!suc2)
            {
                int ls = GTS.Program.rnd.Next(10, 25);
                p.Mrl -= ls;
                Colors.BoldTypeColor($"\n\n😓 The Whirlpool drags your ship! Crew panics!", 215, 0, 0, 30);
                Colors.BoldTypeColor($"\n\n😓 You survived, but the event affected your crew! -{ls} Crew Morale", 0, 128, 255, 30);
                Thread.Sleep(1000);
            }

        }
    }

    public class rivtrad : evnt
    {
        public override void TriggEvent(Player p)
        {
            Console.Clear();
            int res = Program.rnd.Next(0, 30);
            int g = Program.rnd.Next(50, 120);
            int r = Program.rnd.Next(10, 15);
            int m = Program.rnd.Next(10, 15);

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string s = $"A rival trader challenges you! What will you do, Captain?";
            string[] opt = { $"\u001b[38;2;255;255;0m😡 Compete\u001b[0m", "\u001b[38;2;255;255;0m🤝 Deal\u001b[0m", "\u001b[38;2;255;255;0m😒 Ignore\u001b[0m" };

            Menu men = new Menu(opt, s);

            int ch = men.MenuRun();
            switch (ch)
            {
                case 0:
                    Colors.BoldTypeColor($"\n😏 You decide to compete with the rival trader!", 215, 0, 0, 30);
                    Thread.Sleep(800);

                    Console.WriteLine("\n\n\u001b[1m\u001b[38;2;255;255;102m⚡ Press [N] within 3 seconds to negotiate better!\u001b[0m\n");
                    bool suc = false;
                    
                    DateTime sec = DateTime.Now.AddSeconds(3);

                    while (DateTime.Now < sec)
                    {
                        int tl = (int)Math.Ceiling((sec - DateTime.Now).TotalSeconds);
                        Console.Write($"\r\u001b[1m\u001b[38;2;255;255;102m⏳Time Left: {tl} \u001b[0m");

                        
                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            var kp = keyInfo.Key;

                            Console.WriteLine("\n\n");
                            if (kp == ConsoleKey.N)
                            {
                                string[] at = { "💰", "📦", "🛒", "🤝" };

                                for (int i = 0; i < at.Length; i++)
                                {
                                    Console.Write($"    {at[i]}");
                                    Thread.Sleep(500);
                                }

                                p.Gld += g;
                                p.Repu += r;
                                p.Mrl += m;
                                Colors.BoldTypeColor($"\n\n🔥 Your prices undercut theirs, and customers flock to your goods! +{g} Silver, +{r} Reputation, +{m} Morale", 95, 255, 0, 30);
                                suc = true;
                                break;
                            }
                        }
                        Thread.Sleep(50);
                    }
                    if (!suc)
                    {
                        p.Gld -= g;
                        p.Repu -= r;
                        Colors.BoldTypeColor($"\n\n💸 The rival outsmarts you, taking your best clients away! -{g} Silver, -{r} Reputation", 255, 50, 50, 30);
                        Thread.Sleep(1000);
                    }

                    break;

                
                case 1:
                    Colors.BoldTypeColor("\n\n🤔 You offer to make a trade deal instead of fighting for profit.", 204, 255, 153 , 30);
                    Thread.Sleep(800);

                    Console.WriteLine("\n\n\u001b[1m\u001b[38;2;255;255;102m⚡ Press [D] within 3 seconds to land a good deal!\u001b[0m\n");
                    bool suc2 = false;

                    sec = DateTime.Now.AddSeconds(3);

                    while (DateTime.Now < sec)
                    {
                        int tl = (int)Math.Ceiling((sec - DateTime.Now).TotalSeconds);

                        Console.Write($"\r\u001b[1m\u001b[38;2;255;255;102m⏳Time Left: {tl} \u001b[0m");


                        if (Console.KeyAvailable)
                        {
                            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                            var kp = keyInfo.Key;

                            Console.WriteLine("\n\n");
                            if (kp == ConsoleKey.D)
                            {
                                string[] at = { "💰", "📦", "🛒", "🤝" };

                                for (int i = 0; i < at.Length; i++)
                                {
                                    Console.Write($"    {at[i]}");
                                    Thread.Sleep(500);
                                }

                                Console.WriteLine("\n");
                                p.Gld += g;
                                p.Repu += r;
                                Colors.BoldTypeColor($"\n\n💰 The deal turns out profitable for both sides! +{g} Silver, +{r} Reputation", 153, 255, 153, 30);

                                suc2 = true;
                                break;
                            }
                        }
                        Thread.Sleep(100);
                    }
                    if (!suc2)
                    {
                        p.Gld -= g;
                        p.Repu -= r;
                        Colors.BoldTypeColor($"\n\n🕵️‍♂️ The rival tricked you with fake goods! -{g} Silver, -{r} Reputation ", 255, 50, 50, 30);
                        Thread.Sleep(1000);
                    }

                    break;

                case 2:
                    Colors.BoldTypeColor($"\n\n😒 You ignore the rival trader and continue your voyage....", 51, 255, 255, 30);
                    Thread.Sleep(800);

                    if (res < 10)
                    {
                        p.Mrl += m;
                        Colors.BoldTypeColor($"\n\n⛵ Your calm decision pays off , phew! +{m} Morale", 95, 255, 0, 30);
                    }
                    else if (res < 20)
                    {
                        Colors.BoldTypeColor("\n\n🌤️ Nothing happens, and your journey continues peacefully.", 153, 255, 153, 30);
                    }
                    else
                    {
                        p.Repu -= r;
                        Colors.BoldTypeColor($"\n\n😠 YIKES! The rival spreads rumors about you, damaging your reputation! -{r} Reputation", 255, 153, 153, 30);
                    }
                    break;
            }

        }
    
    }
    public class pirate : evnt
    {

        public override void TriggEvent(Player p)
        {
            Console.Clear();

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool suc = Program.rnd.NextDouble() < 0.5;
            int res = Program.rnd.Next(10, 15);
            int mrl = Program.rnd.Next(15, 20);
            int gld = Program.rnd.Next(80, 180);

            string s = $"🔥 The Pirate Captain is aiming a cannon at your ship!";
            string[] opt = { $"\u001b[38;2;215;0;0m😡 Fire Cannon\u001b[0m ", "\u001b[38;2;255;255;128m🏃‍♂ Dodge Attack\u001b[0m", "\u001b[38;2;144;238;144m🛡  Raise Shield\u001b[0m" };

            Menu men = new Menu(opt, s);
            int ch = men.MenuRun();


            switch (ch)
            {
                case 0:
                    
                    string comp = $"Pirate Ship Damaged! Do you want to steal their goods?";
                    string[] o = { $"\u001b[38;2;255;255;0m🤑 Loot their Goods\u001b[0m", "\u001b[38;2;255;255;0m😬 Skip Looting, Focus on your goods\u001b[0m" };

                    Menu me = new Menu(o, comp);
                    int s1 = me.MenuRun();

                    switch (s1)
                    {
                        case 0:
                            PirateFight(p);
                            break;
                        case 1:
                            Colors.BoldTypeColor("\n\n🤓 Wise Choice! You and your crew are safe.", 95, 255, 255, 30);
                            break;

                    }
                    Thread.Sleep(1000);
                    break;
                case 1:
                    if (suc)
                    {
                        p.Repu += res;
                        p.Mrl += mrl ;
                        Colors.BoldTypeColor($"\n\n🏴‍ You escaped successfully! +{res} Reputation +{mrl} Crew Morale", 95, 255, 0, 30);
                    }
                    else
                    {
                        p.Repu -= res;
                        p.Gld -= gld;
                        p.Mrl -= mrl;
                        Colors.BoldTypeColor($"\n\n💥 Your ship got hit while escaping!  -{res} Reputation - {gld} Silver -{mrl} Crew Morale ", 255, 0, 0, 30);
                    }
                    Thread.Sleep(1000);
                    break;

                case 2:

                    if (suc)
                    {
                        p.Repu += res;
                        Colors.BoldTypeColor($"\n\n🏴‍ You protected your ship successfully! +{res} Reputation", 95, 255, 0, 30);
                    }
                    else
                    {
                        p.Repu -= res;
                        p.Gld -= gld;
                        p.Mrl -= mrl;
                        Colors.BoldTypeColor($"\n\n💥 Your ship took a hit!  -{res} Reputation - {gld} Silver -{mrl} Crew Morale", 255, 0, 0, 30);
                    }
                    Thread.Sleep(1000);
                    break;
            }

        }

        public static void PirateFight(Player p)
        {
            int rv = Program.rnd.Next(10, 15);
            int gld = Program.rnd.Next(80, 180);
            int mrl = Program.rnd.Next(10, 15);

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n\u001b[1m\u001b[38;2;255;255;102m⚡ Press [A] within 3 seconds to strike!\u001b[0m\n");
            bool suc = false;

            DateTime sec = DateTime.Now.AddSeconds(3);
           
            while (DateTime.Now < sec)
            {
                int tl = (int) Math.Ceiling((sec - DateTime.Now).TotalSeconds);
                Console.Write($"\r\u001b[1m\u001b[38;2;255;255;102m⏳Time Left: {tl} \u001b[0m");

              
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    var kp = keyInfo.Key;

                    Console.WriteLine("\n\n");
                    if (kp == ConsoleKey.A)
                    {
                        string[] at = { "🏴‍☠️ 🤺        ⚔️        🤺 🏴‍☠️", "🏴‍☠️ 🤺💥⚔️💥🤺 🏴‍☠️", "🏴‍☠️ 🤺      💨🤺 🏴‍☠️" };

                        for (int i = 0; i < at.Length; i++)
                        {
                            Console.WriteLine($"{at[i]}");
                            Thread.Sleep(500);
                        }

                        Colors.BoldTypeColor("\n\n⚔ Critical Hit! ", 95, 255, 0, 30);
                        Colors.BoldTypeColor($"\n\n💥 You charge back at the pirates!", 255, 0, 0, 30);

                        p.Repu += rv;
                        p.Gld += gld;
                        p.Mrl += mrl;
                        Colors.BoldTypeColor($"\n\n💪 Victory!  +{rv} Reputation +{gld} Silver +{mrl} Crew Morale", 95, 255, 0, 30);

                        suc = true;
                        break;
                    }
                }
                Thread.Sleep(100);
            }
            if(!suc)
            {
                p.Repu -= rv;
                p.Gld -= gld;
                p.Mrl -= mrl;
                Colors.BoldTypeColor($"\n\n😱 Defeat! Your crew takes a hit. -{rv} Reputation -{gld} Silver -{mrl} Crew Morale", 255, 0, 0, 30);

                Thread.Sleep(1000);
            }
        }
    }

}
