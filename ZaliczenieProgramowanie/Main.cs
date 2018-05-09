using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaliczenieProgramowanie
{
    class Main
    {
        public Main() {
            Console.ResetColor();
            Wybor menuWybor = new Wybor(5);
            Stan stan = new Stan();

            menuWybor.pobierzTytul("piekarnia zapiecek");
            menuWybor.Dodaj("Kasa");
            menuWybor.Dodaj("Sprzedaż");
            menuWybor.Dodaj("Stan magazynu");
            menuWybor.Dodaj("Dostawa");
            menuWybor.Dodaj("Zakończ");
            while (true)
            {
                switch (menuWybor.Dzialaj())
                {
                    case 0:
                        stan.WyswKasa();

                        break;
                    case 1:
                        stan.Sprzedaz();
                        break;
                    case 2:
                        stan.WypiszProdukty();
                        break;
                    case 3:
                        stan.WyborDostarczonegoProduktu();
                        break;
                    case 4:
                        return;
                }
            }
        }
    }
}
