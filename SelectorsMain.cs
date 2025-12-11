using Effects;
using Ports;
using Pstats;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SelectMain
{
    
    public class Menu
    {
        private int SelIndex;
        private string[] Opts;
        private string Prompt;

        public Menu(string[] opt, string prompt)
        {
            Opts = opt;
            Prompt = prompt;
            SelIndex = 0;
        }

        private void DisplayOpts()
        {
            Border.DrawBoard(Prompt);

            List<string> sel = new ();
            for (int i = 0; i < Opts.Length; i++)
            {
                string ch;
                string curOpt = Opts[i];

                if (i == SelIndex)
                {
                    ch = $"     ❯❯    \u001b[1m\x1b[6m{curOpt}\u001b[0m     ❮❮\n";     
                }
                else
                {
                    ch = $"    \u001b[1m{curOpt}\u001b[0m    \n";

                }
               
                sel.Add(ch);
            }

            Border.B2(sel.ToArray());

        }

        public int MenuRun()
        {
            ConsoleKey kp;
            do
            {
                Console.Clear();
                DisplayOpts();
 
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                kp = keyInfo.Key;

                if(kp == ConsoleKey.UpArrow)
                {
                    SelIndex--;

                    if( SelIndex == -1 )
                    {
                        SelIndex = Opts.Length - 1;
                    }
                }
                else if(kp == ConsoleKey.DownArrow)
                {
                    SelIndex++;

                    if (SelIndex == Opts.Length)
                    {
                        SelIndex = 0;
                    }
                }

            } while (kp != ConsoleKey.Enter);
            return SelIndex;
        }
        
    }

   
    public class Menu2
    {
        private int SelIndex;
        private string[] Opts;
        private string Prompt;

        public Menu2(string[] opt, string prompt)
        {
            Opts = opt;
            Prompt = prompt;
            SelIndex = 0;
        }

        private void DisplayOpts()
        {
            Border.DrawBoard(Prompt);

            List<string> sel = new();
            for (int i = 0; i < Opts.Length; i++)
            {
                string ch;
                string curOpt = Opts[i];

                if (i == SelIndex)
                {
                    ch = $"❯❯❯    \x1b[1m\u001b[1m\u001b[38;2;215;175;0m{curOpt}\u001b[0m    ❮❮❮\n";
                }
                else
                {
                    ch = $"\x1b[1m\u001b[1m\u001b[38;2;208;230;10m{curOpt}\u001b[0m\n";

                }

                sel.Add(ch);
            }
            Border.B2(sel.ToArray());
        }
        public int MenuRun()
        {
            ConsoleKey kp;
            do
            {
                Console.Clear();
                DisplayOpts();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                kp = keyInfo.Key;

                if (kp == ConsoleKey.UpArrow)
                {
                    SelIndex--;

                    if (SelIndex == -1)
                    {
                        SelIndex = Opts.Length - 1;
                    }
                }
                else if (kp == ConsoleKey.DownArrow)
                {
                    SelIndex++;

                    if (SelIndex == Opts.Length)
                    {
                        SelIndex = 0;
                    }
                }

            } while (kp != ConsoleKey.Enter);
            return SelIndex;
        }

    }
    public class BGoods
    {
        private int SelIndex;
        private Dictionary<string, double> Opts{ get; set; }
        private string Prompt;

        public BGoods(Dictionary<string, double> opts, string prompt)
        {
            Opts = opts;
            Prompt = prompt;
            SelIndex = 0;
        }

        private void DisplayOpts()
        {
            Border.DrawBoard(Prompt);

            List<string> sel = new();
            for (int i = 0; i < Opts.Count; i++)
            {
                var curOpt = Opts.ElementAt(i);
                string ch;

                if (i == SelIndex)
                {
                    ch = $"❯❯❯  \u001b[1m\u001b[38;2;255;255;0m{curOpt.Key} -> {curOpt.Value} silver\u001b[0m   ❮❮❮\n";

                }
                else
                {
                    ch = $"\u001b[1m\u001b[38;2;215;175;0m {curOpt.Key} -> {curOpt.Value} silver\u001b[0m       \n";

                }

                sel.Add(ch);
            }
            Border.B2(sel.ToArray());
        }


        public int MenuRun()
        {
            ConsoleKey kp;
            do
            {
                Console.Clear();
                DisplayOpts();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                kp = keyInfo.Key;

                if (kp == ConsoleKey.UpArrow)
                {
                    SelIndex--;

                    if (SelIndex == -1)
                    {
                        SelIndex = Opts.Count - 1;
                    }
                }
                else if (kp == ConsoleKey.DownArrow)
                {
                    SelIndex++;

                    if (SelIndex == Opts.Count)
                    {
                        SelIndex = 0;
                    }
                }

            } while (kp != ConsoleKey.Enter);
            return SelIndex;
        }
    }

    public class SGoods
    {
        private int SelIndex;
        public List<(string Name, double Price, int Qty)> Opts { get; set; }
        private string Prompt;

        public SGoods(List<(string Name, double Price, int Qty)> opts, string prompt)
        {
            Prompt = prompt;
            SelIndex = 0;
            Opts = opts;
        }

        private void DisplayOpts()
        {
            Border.DrawBoard(Prompt);

            List<string> sel = new();
            for (int i = 0; i < Opts.Count; i++)
            {
                var curOpt = Opts.ElementAt(i);
                string ch;

                if (i == SelIndex)
                {
                    ch = $"❯❯❯  \u001b[1m\u001b[38;2;255;255;0m[{curOpt.Item3}] {curOpt.Item1} -> {curOpt.Item2} silver\u001b[0m    ❮❮❮\n";

                }
                else
                {
                    ch = $"\u001b[1m\u001b[38;2;215;175;0m[{curOpt.Item3}] {curOpt.Item1} -> {curOpt.Item2} silver\u001b[0m\n";
                    
                }

                sel.Add(ch);
            }
            Border.B2(sel.ToArray());

        }

        public int MenuRun()
        {
            ConsoleKey kp;
            do
            {
                Console.Clear();
                DisplayOpts();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                kp = keyInfo.Key;

                if (kp == ConsoleKey.UpArrow)
                {
                    SelIndex--;

                    if (SelIndex == -1)
                    {
                        SelIndex = Opts.Count - 1;
                    }
                }
                else if (kp == ConsoleKey.DownArrow)
                {
                    SelIndex++;

                    if (SelIndex == Opts.Count)
                    {
                        SelIndex = 0;
                    }
                }

            } while (kp != ConsoleKey.Enter);
            return SelIndex;
        }
    }
}
