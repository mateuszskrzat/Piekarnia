using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


//KLASA OBSŁUGUJĄCA BAZĘ DANYCH
namespace ZaliczenieProgramowanie
{
    class Stan
    {
        List<Paczek> paczki;
        List<Ciasto> ciasta;
        List<Chleb> chleby;
        Kasa kasa;
        private int lista = 0;
        //------KONSTRUKTOR---------------------------------
        public Stan()
        {
            OdczytXMLCiasto();
            OdczytXMLChleb();
            OdczytXMLPaczek();
            if (ZostawionaKasa() == 1)
            {
                Console.ResetColor();
                Console.Clear();
                double onaCzujeWeMniePiniadz = 0;
                kasa = new Kasa(onaCzujeWeMniePiniadz);
            }
            else
            {
                kasa = new Kasa();
            }
        }
        // -----WYPISANIE LIST PRODUKTÓW--------------------
        public void WyborDostarczonegoProduktu()
        {
            Wybor lista = new Wybor(3);
            lista.pobierzTytul("wybierz dodanie lub edycje");
            lista.Dodaj("Dodaj nowy produkt");
            lista.Dodaj("Edytuj/Aktualizuj produkt");
            lista.Dodaj("Wróć");
            switch (lista.Dzialaj())
            {
                case 0:
                    noweTowary();
                    break;
                case 1:
                    EdycjaDostawy(WypiszProdukty());
                    break;
                case 3:
                    return;
            }
        }
        public int WypiszProdukty()
        {
            int k = -1;
            switch (WyborKategorii())
            {

                case 0:
                    Wybor listaPaczki = new Wybor(paczki.Count);
                    listaPaczki.pobierzTytul("aktualny stan pączków");
                    foreach (Paczek p in paczki)
                    {
                        listaPaczki.Dodaj(p.Dane());
                    }
                    k = listaPaczki.Dzialaj();
                    lista = 1;
                    return k;
                case 1:
                    Wybor listaCiasta = new Wybor(ciasta.Count);
                    listaCiasta.pobierzTytul("aktualny stan ciast");
                    foreach (Ciasto c in ciasta)
                    {
                        listaCiasta.Dodaj(c.Dane());
                    }
                    lista = 2;
                    k = listaCiasta.Dzialaj();
                    return k;
                case 2:
                    Wybor listaChleby = new Wybor(chleby.Count);
                    listaChleby.pobierzTytul("aktualny stan chlebów");
                    foreach (Chleb h in chleby)
                    {
                        listaChleby.Dodaj(h.Dane());
                    }
                    lista = 3;
                    k = listaChleby.Dzialaj();
                    return k;
                default:
                    k = -1;
                    lista = 0;
                    return k;
            }
        }
        // -----EDYCJA/DODAWANIE NOWYCH PRODUKTÓW-----------
        private int WyborKategorii()
        {
            Console.ResetColor();
            Wybor menuWybor = new Wybor(4);
            menuWybor.pobierzTytul("Wybierz kategorię");
            menuWybor.Dodaj("Pączki");
            menuWybor.Dodaj("Ciasta");
            menuWybor.Dodaj("Chleby");
            menuWybor.Dodaj("Wróć");

            while (true)
            {

                switch (menuWybor.Dzialaj())
                {
                    case 0:
                        return 0;

                    case 1:
                        return 1;

                    case 2:
                        return 2;

                    case 3:
                        return 3;
                }
            }
        }
        private void EdycjaDostawy(int k)
        {
            if (lista == 1)
            {
                Paczek p = paczki[k];
                
                
                while (true)
                {
                    Wybor edycjaPaczek = new Wybor(5);
                    edycjaPaczek.pobierzTytul("dostawa pączków");
                    edycjaPaczek.Dodaj("Edytuj typ - " + p.typ);
                    edycjaPaczek.Dodaj("Edytuj cenę - " + p.cena);
                    edycjaPaczek.Dodaj("Edytuj stan - " + p.stan);
                    edycjaPaczek.Dodaj("Zapisz");
                    edycjaPaczek.Dodaj("Wróć");
                    switch (edycjaPaczek.Dzialaj())
                    {
                        case 0:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj typ");
                            p.typ = Console.ReadLine();
                            break;
                        case 1:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj cenę");
                            p.cena = double.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj stan");
                            p.stan = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            paczki[k].typ = p.typ;
                            paczki[k].cena = p.cena;
                            paczki[k].stan = p.stan;
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Zapisano");
                            Console.ReadKey();
                            break;
                        case 4:
                            return;
                    }
                }
            }
            if (lista == 2)
            {
                Ciasto p = ciasta[k];
                
                while (true)
                {
                    Wybor edycjaCiastek = new Wybor(5);
                    edycjaCiastek.pobierzTytul("dostawa ciastek");
                    edycjaCiastek.Dodaj("Edytuj typ - " + p.typ);
                    edycjaCiastek.Dodaj("Edytuj cenę - " + p.cena);
                    edycjaCiastek.Dodaj("Edytuj stan - " + p.stan);
                    edycjaCiastek.Dodaj("Zapisz");
                    edycjaCiastek.Dodaj("Wróć");
                    switch (edycjaCiastek.Dzialaj())
                    {
                        case 0:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj typ");
                            p.typ = Console.ReadLine();
                            break;
                        case 1:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj cenę");
                            p.cena = double.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj stan");
                            p.stan = double.Parse(Console.ReadLine());
                            break;
                        case 3:
                            ciasta[k].typ = p.typ;
                            ciasta[k].cena = p.cena;
                            ciasta[k].stan = p.stan;
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Zapisano");
                            Console.ReadKey();
                            break;
                        case 4:
                            return;
                    }
                }
            }
            if (lista == 3)
            {
                Chleb p = chleby[k];
                Wybor edycjaChleb = new Wybor(5);
                edycjaChleb.pobierzTytul("dostawa chlebów");
                edycjaChleb.Dodaj("Edytuj typ - " + p.typ);
                edycjaChleb.Dodaj("Edytuj cenę - " + p.cena);
                edycjaChleb.Dodaj("Edytuj stan - " + p.stan);
                edycjaChleb.Dodaj("Zapisz");
                edycjaChleb.Dodaj("Wróć");
                while (true)
                {
                    switch (edycjaChleb.Dzialaj())
                    {
                        case 0:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj typ");
                            p.typ = Console.ReadLine();
                            break;
                        case 1:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj cenę");
                            p.cena = double.Parse(Console.ReadLine());
                            break;
                        case 2:
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Podaj stan");
                            p.stan = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            chleby[k].typ = p.typ;
                            chleby[k].cena = p.cena;
                            chleby[k].stan = p.stan;
                            Console.ResetColor();
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - 8) / 2, Console.CursorTop);
                            Console.WriteLine("Zapisano");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
        private void noweTowary()
        {
            string x;
            switch(WyborKategorii())
            {
                case 0:
                    Paczek p = new Paczek();
                    Console.ResetColor();
                    Console.Clear();
                    x = "TWORZENIE NOWEGO RODZAJU PĄCZKA";
                    Console.SetCursorPosition((Console.WindowWidth - x.Length) / 2, Console.CursorTop);
                    Console.WriteLine(x);
                    Console.WriteLine("Podaj typ");
                    p.typ = Console.ReadLine();
                    Console.WriteLine("Podaj cenę");
                    p.cena = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj stan");
                    p.stan = int.Parse(Console.ReadLine());
                    paczki.Add(p);
                    break;
                case 1:
                    Ciasto c = new Ciasto();
                    Console.ResetColor();
                    Console.Clear();
                    x = "TWORZENIE NOWEGO RODZAJU CIASTA";
                    Console.SetCursorPosition((Console.WindowWidth - x.Length) / 2, Console.CursorTop);
                    Console.WriteLine(x);
                    Console.WriteLine("Podaj typ");
                    c.typ = Console.ReadLine();
                    Console.WriteLine("Podaj cenę");
                    c.cena = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj stan");
                    c.stan = double.Parse(Console.ReadLine());
                    ciasta.Add(c);
                    break;
                case 2:
                    Chleb h = new Chleb();
                    Console.ResetColor();
                    Console.Clear();
                    x = "TWORZENIE NOWEGO RODZAJU CHLEBA";
                    Console.SetCursorPosition((Console.WindowWidth - x.Length) / 2, Console.CursorTop);
                    Console.WriteLine(x);
                    Console.WriteLine("Podaj typ");
                    h.typ = Console.ReadLine();
                    Console.WriteLine("Podaj cenę");
                    h.cena = double.Parse(Console.ReadLine());
                    Console.WriteLine("Podaj stan");
                    h.stan = int.Parse(Console.ReadLine());
                    chleby.Add(h);
                    break;
                case 3:
                    return;
            }

        }
        // -----SPRZEDAŻ------------------------------------
        public void Sprzedaz()
        {
            int k = WypiszProdukty();
            if(lista == 1)
            {
                int s = (int)paczki[k].Sprzedaz();
                if (paczki[k].stan - s >= 0)
                {
                    paczki[k].stan = paczki[k].stan - s;
                    kasa.Sprzedaz(s, paczki[k].cena);
                    Console.WriteLine("Pomyślnie sprzedano, aktualny stan pączka " + paczki[k].typ + " to " + paczki[k].stan + " sztuk.");
                    Console.WriteLine();
                    Console.WriteLine("Do zapłaty: " + (s * paczki[k].cena) + " zł.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Próbujesz sprzedać więcej niż jest na stanie! Spróbuj jeszcze raz.");
                    Console.ReadKey();
                    return;
                }
            }
            else if (lista == 2)
            {
                double s = ciasta[k].Sprzedaz();
                if (ciasta[k].stan - s >= 0)
                {
                    ciasta[k].stan = ciasta[k].stan - s;
                    kasa.Sprzedaz(s, ciasta[k].cena);
                    Console.WriteLine("Pomyślnie sprzedano, aktualny stan ciasta " + ciasta[k].typ + " to " + ciasta[k].stan + " kg.");
                    Console.WriteLine();
                    Console.WriteLine("Do zapłaty: " + (s * ciasta[k].cena) + " zł.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Próbujesz sprzedać więcej niż jest na stanie! Spróbuj jeszcze raz.");
                    Console.ReadKey();
                    return;
                }
            }
            else if (lista == 3)
            {
                int s = (int)chleby[k].Sprzedaz();
                if (chleby[k].stan - s >= 0)
                {
                    chleby[k].stan = chleby[k].stan - s;
                    kasa.Sprzedaz(s, chleby[k].cena);
                    Console.WriteLine("Pomyślnie sprzedano, aktualny stan chleba " + chleby[k].typ + " to " + chleby[k].stan + " sztuk.");
                    Console.WriteLine();
                    Console.WriteLine("Do zapłaty: " + (s * chleby[k].cena) + " zł.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Próbujesz sprzedać więcej niż jest na stanie! Spróbuj jeszcze raz.");
                    Console.ReadKey();
                    return;
                }
            }

        }
        public void WyswKasa()
        {
            kasa.WyswietlKasa();
        }
        private int ZostawionaKasa()
        {
            Wybor menu = new Wybor(2);
            menu.pobierzTytul("czy chcesz wczytać poprzedni stan kasy? (wybierz nie, jesli jestes na nowej zmianie)");
            menu.Dodaj("TAK");
            menu.Dodaj("NIE");
            switch(menu.Dzialaj())
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                default:
                    return 20;
            }
        }
        //------ZAPIS XML-----------------------------------
        private void ZapisXMLPaczek()
        {
                XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista pączków"),
                new XElement("paczki",
                from Paczek in paczki
                orderby Paczek.typ, Paczek.stan
                select new XElement("paczek",
                new XElement("typ", Paczek.typ),
                new XElement("cena", Paczek.cena),
                new XElement("stan", Paczek.stan)
                )
             )
                );

                xml.Save("Paczki.xml");
        }
        private void ZapisXMLChlebow()
        {
            XDocument xml = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("Lista chlebów"),
            new XElement("chleby",
            from Chleb in chleby
            orderby Chleb.typ, Chleb.stan
            select new XElement("chleb",
            new XElement("typ", Chleb.typ),
            new XElement("cena", Chleb.cena),
            new XElement("stan", Chleb.stan)
            )
         )
            );

            xml.Save("Chleby.xml");
        }
        private void ZapisXMLCiast()
        {
            XDocument xml = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("Lista ciast"),
            new XElement("paczki",
            from Ciasto in ciasta
            orderby Ciasto.typ, Ciasto.stan
            select new XElement("ciasto",
            new XElement("typ", Ciasto.typ),
            new XElement("cena", Ciasto.cena),
            new XElement("stan", Ciasto.stan)
            )
         )
            );

            xml.Save("Ciasta.xml");
        }
        //------ODCZYT XML----------------------------------
        private void OdczytXMLPaczek()
        {
            XDocument xml = XDocument.Load("Paczki.xml");
            List<Paczek> paczkiXML = (from p in xml.Descendants("paczek")
                                      select new Paczek
                                      {
                                          typ = (string)p.Element("typ").Value,
                                          cena = double.Parse(p.Element("cena").Value, CultureInfo.InvariantCulture),
                                          stan = int.Parse(p.Element("stan").Value)
                                      }).ToList();

            paczki = new List<Paczek>(paczkiXML);
        }
        private void OdczytXMLChleb()
        {
            XDocument xml = XDocument.Load("Chleby.xml");
            List<Chleb> chlebyXML = (from h in xml.Descendants("chleb")
                                     select new Chleb
                                     {
                                         typ = (string)h.Element("typ").Value,
                                         cena = double.Parse(h.Element("cena").Value, CultureInfo.InvariantCulture),
                                         stan = int.Parse(h.Element("stan").Value)
                                     }).ToList();

            chleby = new List<Chleb>(chlebyXML);
        }
        private void OdczytXMLCiasto()
        {
            XDocument xml = XDocument.Load("Ciasta.xml");
            List<Ciasto> ciastaXML = (from c in xml.Descendants("ciasto")
                                      select new Ciasto
                                      {
                                          typ = (string)c.Element("typ").Value,
                                          cena = double.Parse(c.Element("cena").Value, CultureInfo.InvariantCulture),
                                          stan = double.Parse(c.Element("stan").Value, CultureInfo.InvariantCulture)
                                      }).ToList();

            ciasta = new List<Ciasto>(ciastaXML);
        }
        //------DESTRUKTOR----------------------------------
        ~Stan() {
            ZapisXMLChlebow();
            ZapisXMLCiast();
            ZapisXMLPaczek();
            lista = 0;
        }
    }
}
