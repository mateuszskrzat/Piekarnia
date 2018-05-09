using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//KLASA POCHODNA KLASY PIECZYWO
namespace ZaliczenieProgramowanie
{
    class Ciasto:Pieczywo
    {
        private double _stan;

        public override string typ
        {
            get
            {
                return _typ;
            }
            set
            {
                _typ = value;
            }
        }
        public new double stan
        {
            get
            {
                return _stan;
            }
            set
            {
                _stan = value;
            }
        }
        override public string Dane()
        {
            return "Typ ciata: " + typ + " |Cena: " + cena + " |Aktualny stan: " + stan + " kg.";
        }
        public override double Sprzedaz()
        {
            Console.ResetColor();
            Console.Clear();
            //Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
            Console.WriteLine("Sprzedajesz ciasto (w kilogramach) - " + typ);
            Console.WriteLine();
            return base.Sprzedaz();
        }
    }
}
