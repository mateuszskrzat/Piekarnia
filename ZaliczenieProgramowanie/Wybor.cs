using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//W TEJ KLASIE JEST OBSŁUGIWANE MENU

namespace ZaliczenieProgramowanie
{
    class Wybor
    {
        string[] elementy;
        int liczbaElementow;
        string tytul;
        public int zaznaczony = 0;

        public Wybor(int liczbaElementow)
        {
            elementy = new string[liczbaElementow];
        }
        public void Dodaj(string element)
        {

            if (liczbaElementow < elementy.Length)
            {
                elementy[liczbaElementow++] = element;
            }

        }
        public void pobierzTytul(string tytul1)
        {
            if (tytul == null)
            {
                tytul = tytul1;
            }
        }
        private void Rysuj()
        {
            for (int i = 0; i < liczbaElementow; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - elementy[i].Length) / 2, Console.CursorTop);
                if (i == zaznaczony)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine(elementy[i].PadLeft(elementy[i].Length + 1).PadRight(elementy[i].Length + 2));
            }
        }
        private void RysujTytul()
        {
            Console.SetCursorPosition((Console.WindowWidth - tytul.Length) / 2, Console.CursorTop);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            tytul = tytul.ToUpper();
            Console.WriteLine(tytul.PadLeft(tytul.Length + 1).PadRight(tytul.Length + 2));
            Console.WriteLine();
        }
        public int Dzialaj()
        {
            while (true)
            {
                Console.ResetColor();
                Console.Clear();
                if (tytul != null)
                {
                    RysujTytul();
                }
                Rysuj();
                ConsoleKeyInfo k = Console.ReadKey();
                switch (k.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (zaznaczony > 0)
                        {
                            zaznaczony--;
                        }
                        else
                        {
                            zaznaczony = liczbaElementow - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (zaznaczony < liczbaElementow - 1)
                        {
                            zaznaczony++;
                        }
                        else
                        {
                            zaznaczony = 0;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return zaznaczony;

                }
            }
        }
    }
}
