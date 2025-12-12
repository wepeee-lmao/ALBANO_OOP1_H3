using Events;
using SelectMain;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pstats;

namespace Effects
{
    public class Colors
    {
        public static void Glow(string text)
        {
            var colors = new[] { Color.Red, Color.Yellow, Color.Green, Color.Aquamarine1, Color.Gold1, Color.Yellow2, Color.SkyBlue3, Color.Orchid, Color.PaleGreen1 };
            foreach (var c in colors)
            {
                AnsiConsole.MarkupLine($"[{c.ToMarkup()}]{text}[/]");
                Thread.Sleep(200);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        public static void TypeColor(string text, int r, int g, int b, int delay = 50)
        {
            string comp = $"\u001b[38;2;{r};{g};{b}m{text}\u001b[0m";

            foreach (var c in comp)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }

        public static void BoldTypeColor(string text, int r, int g, int b, int delay = 50)
        {
            string comp = $"\u001b[1m\u001b[38;2;{r};{g};{b}m{text}\u001b[0m";

            foreach (var c in comp)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
        }

    }

    public class Loading
    {

        public static void Monkey()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n");
            string[] s = { "🙈", "🙉", "🙊" };
            for (int i = 0; i < 21; i++)
            {
                Console.Write($"\r{s[i % s.Length]} \u001b[1m\u001b[38;2;175;215;135mLoading.....\u001b[0m");
                Thread.Sleep(200);
            }
            Thread.Sleep(1000);
        }

        public static void Earth()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("\n");
            string[] s = { "🌍", "🌎", "🌏" };
            for (int i = 0; i < 18; i++)
            {
                Console.Write($"\r{s[i % s.Length]} \u001b[1m\u001b[38;2;175;215;135mLoading.....\u001b[0m");
                Thread.Sleep(200);
            }
            Thread.Sleep(1000);
        }

        public static void Voyint()
        {
            Console.Clear();
            Colors.BoldTypeColor("\n🌊 NIGHT BEFORE THE NEXT VOYAGE…", 150, 200, 255, 40);
            Thread.Sleep(800);

            Colors.TypeColor(
                "\nThe sea is unnaturally quiet.\n" +
                "Even the crew whisper as if the waves themselves are listening.",
                220, 220, 255, 30);
            Thread.Sleep(500);

            Colors.TypeColor(
                "\nIn the lantern’s dim glow, an old helmsman approaches you.",
                255, 230, 200, 30);
            Thread.Sleep(500);

            Colors.BoldTypeColor(
                "\nCaptain… word spreads across these waters.",
                255, 180, 180, 40);
            Thread.Sleep(500);

            Colors.TypeColor(
                "\nA shadow follows us. A man who claims you're not worthy of your own ship.",
                255, 200, 200, 25);
            Thread.Sleep(500);

            Colors.TypeColor(
                "\nThey say it is Captain Varela… the Silver Wolf of the Galleons.",
                255, 120, 120, 30);
            Thread.Sleep(500);

            Colors.BoldTypeColor(
                "\nThe crew tighten their grips on ropes, blades, and rosaries.",
                255, 255, 180, 35);
            Thread.Sleep(500);

            Colors.TypeColor(
                "\nTomorrow’s voyage will decide more than treasure—",
                255, 255, 255, 30);
            Thread.Sleep(500);

            Colors.BoldTypeColor(
                "\n⚔️ It will decide your legend.",
                255, 230, 100, 40);

            Thread.Sleep(5000);
        }


        public static void Bye()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] s =
                {
                        "👋     ",
                        "  👋   ",
                        "    👋 ",
                        "  👋   ",
                    };

            for (int i = 0; i < 21; i++)
            {
                Console.Write($"\r{s[i % s.Length]} \u001b[1m\u001b[38;2;215;175;0mFarewell, Captain! See you again next time!\u001b[0m");
                Thread.Sleep(200);
            }
            Thread.Sleep(1000);
        }

        public static void Boat()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string s1 = @"
                                     )_)  )_)  )_)
                                    )___))___))___)\
                                   )____)____)_____)\\
                            _____|____|____|____\\\___
~~~~~~~~~~~~~~~~~~~~~~~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string s2 = @"
                               )_)  )_)  )_)
                              )___))___))___)\
                             )____)____)_____)\\
                      _____|____|____|____\\\___
~~~~~~~~~~~~~~~~~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string s3 = @"
                        )_)  )_)  )_)
                       )___))___))___)\
                      )____)____)_____)\\
               _____|____|____|____\\\___
~~~~~~~~~~~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string s4 = @"
                  )_)  )_)  )_)
                 )___))___))___)\
                )____)____)_____)\\
         _____|____|____|____\\\___
~~~~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            string s5 = @"
                     )_)  )_)  )_)
                    )___))___))___)\
                   )____)____)_____)\\
            _____|____|____|____\\\___
~~~~~~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
      ||   ||      ||   ||     ||
      ||   ||      ||   ||     ||
  ================================
  |      PORT TERMINAL           |
  |        [====]   [====]       |
  |______________________________|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            string s6 = @"
                )_)  )_)  )_)
               )___))___))___)\
              )____)____)_____)\\
       _____|____|____|____\\\___
~~~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
      ||   ||      ||   ||     ||
      ||   ||      ||   ||     ||
  ================================
  |      PORT TERMINAL           |
  |   [====]   [====]   [====]   |
  |______________________________|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string s7 = @"
             )_)  )_)  )_)
            )___))___))___)\
           )____)____)_____)\\
    _____|____|____|____\\\___
~~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
      ||   ||      ||   ||     ||
      ||   ||      ||   ||     ||
  ================================
  |      PORT TERMINAL           |
  |   [====]   [====]   [====]   |
  |______________________________|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string s8 = @"
          )_)  )_)  )_)
         )___))___))___)\
        )____)____)_____)\\
    _____|____|____|____\\\___
~~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
      ||   ||      ||   ||     ||
      ||   ||      ||   ||     ||
  ================================
  |      PORT TERMINAL           |
  |   [====]   [====]   [====]   |
  |______________________________|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string s9 = @"
       )_)  )_)  )_)
      )___))___))___)\
     )____)____)_____)\\
    _____|____|____|____\\\___
~~~~\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
      ||   ||      ||   ||     ||
      ||   ||      ||   ||     ||
  ================================
  |      PORT TERMINAL           |
  |   [====]   [====]   [====]   |
  |______________________________|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string s10 = @"
   )_)  )_)  )_)
  )___))___))___)\
 )____)____)_____)\\
_|____|____|____\\\______
\_________________________/~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
      ||   ||      ||   ||     ||
      ||   ||      ||   ||     ||
  ================================
  |      PORT TERMINAL           |
  |   [====]   [====]   [====]   |
  |______________________________|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            string[] s = { $"{s1}", $"{s2}", $"{s3}", $"{s4}", $"{s5}", $"{s6}", $"{s7}", $"{s8}", $"{s9}", $"{s10}" };

            for(int i = 0;i < 10;i++)
            {
                Console.Clear();
                Console.Write($"{s[i % s.Length]}");
                Thread.Sleep(190);
            }
            Thread.Sleep(1000);
        }

    }

    public static class Border
    {
        public static string C1(string text, int wid)
        {
            if (text.Length >= wid)
            {
                return text.Substring(0, wid);
            }

            int leftPad = (wid - text.Length) / 2;
            int rightPad = wid - text.Length - leftPad;

            return new string(' ', leftPad) + text + new string(' ', rightPad);
        }

        public static void B2(string[] line)
        {
            int inWid = Console.WindowWidth - 4;
            var top = "╔" + new string('═', Console.WindowWidth - 2) + "╗";
            var bottom = "╚" + new string('═', Console.WindowWidth - 2) + "╝";

            Console.WriteLine(top);
            foreach (var lin in line)
            {
                string pad = C1(lin, inWid);
                Console.WriteLine($"             {pad}");
            }
            Console.WriteLine(bottom);
        }


        public static void DrawBoard(string title)
        {
            if (Console.WindowWidth < 80)
            {
                Console.WindowWidth = 80;
            }
         
            string t = $"\u001b[1m\x1b[38;2;255;203;98m{title}\u001b[0m         ";
            string headLine = "╔" + new string('═', Console.WindowWidth - 2) + "╗";
            string headtitle = "║" + C1(t, Console.WindowWidth + 24) + "║";
            string headBot = "╚" + new string('═', Console.WindowWidth - 2) + "╝";

            Console.WriteLine(headLine);
            Console.WriteLine(headtitle);
            Console.WriteLine(headBot);

            Console.WriteLine();
        }
        
        public static void DrawBoard2(string title)
        {
            if (Console.WindowWidth < 80)
            {
                Console.WindowWidth = 80;
            }

            string t = $"{title}";
            string headL = "╔" + new string('═', Console.WindowWidth - 2) + "╗";
            string headt = "║" + C1(t, Console.WindowWidth + 23) + "║";
            string headBot = "╚" + new string('═', Console.WindowWidth - 2) + "╝";

            Console.WriteLine(headL);
            Console.WriteLine(headt);
            Console.WriteLine(headBot);

            Console.WriteLine();
        }
        public static void DrawBoard3(string title)
        {
            if (Console.WindowWidth < 80)
            {
                Console.WindowWidth = 80;
            }

            string t = $"{title}";
            string headLine = "╔" + new string('═', Console.WindowWidth - 2) + "╗";
            string headtitle = "║" + C1(t, Console.WindowWidth + 25) + "║";
            string headBot = "╚" + new string('═', Console.WindowWidth - 2) + "╝";

            Console.WriteLine(headLine);
            Console.WriteLine(headtitle);
            Console.WriteLine(headBot);

            Console.WriteLine();
        }

        public static void DrawBNC(string[] lines)
        {
           
            int inWid = Console.WindowWidth + 25;

            string top = "╔" + new string('═', Console.WindowWidth - 2) + "╗";
            string bottom = "╚" + new string('═', Console.WindowWidth - 2) + "╝";

            Console.WriteLine(top);
            foreach (var line in lines)
            {
                string pad = C1(line, inWid);
                Console.WriteLine($"{pad}\n");
            }
            Console.WriteLine(bottom);
        }

    }


}
