using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;


//KLASA OBSŁUGUJĄCA KASĘ
namespace ZaliczenieProgramowanie
{
    class Kasa
    {
        private double kasa;
        //KONSTRUKTOR/ PRZECIĄŻENIE KONSTRUKTORÓW
        public Kasa()
        {
            kasa = 0;
        }
        public Kasa(double k)
        {
            OdczytTXTKasa();
        }
        public void Sprzedaz (int stan, double cena)
        {
            double sell = stan * cena;
            kasa = kasa + sell;
        }
        public void Sprzedaz (double stan, double cena)
        {
            double sell = stan * cena;
            kasa = kasa + sell;
        }
        public void WyswietlKasa()
        {
            Wybor menu = new Wybor(1);
            menu.pobierzTytul("aktualny stan kasy");
            menu.Dodaj("KASA: " + Math.Round(kasa, 2) + " zł");
            while(true)
            {
                switch(menu.Dzialaj())
                {
                    case 0:
                        return;
                }
            }
        }
        //------ZAPIS TXT---------------------------
        private void ZapisTXTKasa()
        {
            string _kasa = kasa.ToString();
            using (StreamWriter outputFile = new StreamWriter(@"KASA.txt"))
            {

                outputFile.WriteLine(_kasa);
            }
        }
        //------ODCZYT TXT--------------------------
        private void OdczytTXTKasa()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("KASA.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    kasa = double.Parse(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Plik z stanem kasy nie może zostać otworzony");
            }
        }
        //DESTRUKTOR
        ~Kasa()
        {
            ZapisTXTKasa();
        }
    }
}
