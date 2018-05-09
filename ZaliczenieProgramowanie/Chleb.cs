using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//KLASA POCHODNA KLASY PIECZYWO
namespace ZaliczenieProgramowanie
{
    class Chleb:Pieczywo
    {
        //WŁAŚCIWOŚĆ
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
        //NADPISANIE METODY WIRTUALNEJ
        override public string Dane()
        {
            return "Typ chleba: " + typ + " |Cena: " + cena + " |Aktualny stan: " + stan + " sztuk.";
        }
        //UP
        public override double Sprzedaz()
        {
            Console.ResetColor();
            Console.Clear();
            //Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
            Console.WriteLine("Sprzedajesz chleb - " + typ);
            Console.WriteLine();
            return base.Sprzedaz();
        }
    }
}
