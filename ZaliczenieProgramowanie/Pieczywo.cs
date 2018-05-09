using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//KLASA ABSTRAKCYJNA PIECZYWO
namespace ZaliczenieProgramowanie
{
   abstract class Pieczywo
    {
        protected string _typ;
        private double _cena;
        public int stan;
        public abstract string typ { get; set; }
        public double cena
        {
            get
            {
                return _cena;
            }
            set
            {
                _cena = value;
            }
        }
        abstract public string Dane();
        virtual public double Sprzedaz()
        {

            double sale;
            Console.WriteLine("Podaj sprzedaną ilość: ");
            sale = double.Parse(Console.ReadLine());
            return sale;

        }
    }
}
