using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//KLASA POCHODNA KLASY PIECZYWO
namespace ZaliczenieProgramowanie
{
    class Paczek:Pieczywo
    {
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
        override public string Dane()
        {
            return "Typ pączka: " + typ + " |Cena: " + cena + " |Aktualny stan: " + stan + " sztuk.";
        }
        public override double Sprzedaz()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("Sprzedajesz pączka - " + typ);
            Console.WriteLine();
            return base.Sprzedaz();
        }


    }
}
