using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statki
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pętla menu
            bool start = true;
            while (start)
            {
                //Tekst Menu
                Console.Clear();
                Console.WriteLine("Statki");
                Console.WriteLine("Wybierz Opcje");
                Console.WriteLine("1. Graj");
                Console.WriteLine("2. Zasady Gry");
                Console.WriteLine("3. Credits");
                Console.WriteLine("0. Wychodze");
                Console.WriteLine("Podaj Wybór");
                string menu = Console.ReadLine();
                Console.Clear();
                switch (menu)
                {
                    case "1":
                        PlanszaStatki b = new PlanszaStatki();
                        gracz g = new gracz();
                        g.Rozloz();
                        int dotrafienia = g.IloscDoTrafienia();
                        while (g.iloscTrafionych() < dotrafienia)
                        {
                            b.PokażPlansze(g.GetPlansza());
                            g.Wspolrzedne();
                        }
                        break;
                    case "2":
                        Zasady();
                        break;
                    case "3":
                        Credits();
                        break;
                    case "0":
                        start = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        Console.ReadKey();
                        break;
                }
            }
            //Wyjaśnienie Reguł Gry
            static void Zasady()
            {
                Console.Clear();
                Console.WriteLine("Gra polega na trafieniu w losowo generowane statki");
                Console.WriteLine("Oznaczenia na planszy:");
                Console.WriteLine("? - Miejsce niepewne");
                Console.WriteLine("T - Trafione");
                Console.WriteLine("N - Nietrafione");
                Console.ReadKey();
            }
            //Dane Twórcy
            static void Credits()
            {
                Console.Clear();
                Console.WriteLine("Projekt na Wprowadzenie do Programowania");
                Console.WriteLine("Oskar Kalata");
                Console.WriteLine("Nr Indeksu: 12626");
                Console.ReadKey();
            }
        }
    }
    public class PlanszaStatki
    {
        public void PokażPlansze(char[,] Plansza)
        {
            int Rzad;
            int Kolumna;
            Console.WriteLine("  | 0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("--+---------------------");
            for(Rzad = 0; Rzad <= 9; Rzad++)
            {
                Console.Write((Rzad).ToString() + " | ");
                for (Kolumna = 0; Kolumna <= 9; Kolumna++)
                {
                    //Do Debugowania, Pokazuje statki
                    Console.Write(Plansza[Kolumna, Rzad] + " ");
                    //switch (Plansza[Kolumna, Rzad])
                    //{
                    //    case 'T':
                    //        Console.Write("T ");
                    //        break;
                    //    case 'N':
                    //        Console.Write("N ");
                    //        break;
                    //    default:
                    //        Console.Write("? ");
                    //        break;
                    //}
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }
    }
    public class gracz
    {
        char[,] Plansza = new char[10, 10];
        public int trafione = 0;
        public int nietrafione = 0;
        int x = 0;
        int y = 0;
        public int iloscTrafionych()
        {
            return trafione;
        }
        public int iloscNietrafionych()
        {
            return nietrafione;
        }
        public void Wspolrzedne()
        {
            Console.WriteLine("Podaj X");
            string a = Console.ReadLine();
            int wartosc;
            if (int.TryParse(a, out wartosc))
            {
                x = wartosc;
            }
            else
            {
                Console.WriteLine("Wprowadzono błędne dane");
            }
            Console.WriteLine("Podaj Y");
            a = Console.ReadLine();
            if (int.TryParse(a, out wartosc))
            {
                y = wartosc;
            }
            else
            {
                Console.WriteLine("Wprowadzono błędne dane");
            }
            try
            {
                if (Plansza[x, y].Equals('S'))
                {
                    Plansza[x, y] = 'T';
                    Console.WriteLine("Trafiony.");
                    trafione += 1;
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Plansza[x, y] = 'N';
                    Console.WriteLine("Nietrafiony.");
                    nietrafione += 1;
                    Console.ReadKey();
                    Console.Clear();
                }
            }catch{
                Console.WriteLine("Błędne dane, Wprowadz liczbe pomiędzy 0 - 10");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public char[,] GetPlansza()
        {
            return Plansza;
        }
        public void SetPlansza(int q, int w)
        {
            Plansza[q, w] = 'S';
        }
        public void Rozloz()
        {
            Random r = new Random();
            int PozycjestatkowX = r.Next(0, 10);
            int PozycjestatkowY = r.Next(0, 10);
            for (int i = 0; i<25; i++)
            {
                SetPlansza(PozycjestatkowX, PozycjestatkowY);
                PozycjestatkowX = r.Next(0, 10);
                PozycjestatkowY = r.Next(0, 10);
            }
        }
        public int IloscDoTrafienia()
        {
            int Ilosc = 0;
            foreach (char s in Plansza)
            {
                if (s == 'S')
                {
                    Ilosc++;
                }
            }
            return Ilosc;
        }
    }
}
