using System;

namespace Statki
{
    class Program
    {
        static void Main(string[] args)
        {
            bool start = true;
            while (start)
            {
                Console.WriteLine("Statki");
                Console.WriteLine("Wybierz Opcje");
                Console.WriteLine("1. Graj");
                Console.WriteLine("2. Credits");
                Console.WriteLine("0. Wychodze");
                Console.WriteLine("Podaj Wybór");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":
                        Gra();
                        break;
                    case "2":
                        Credits();
                        break;
                    case "0":
                        start = false;
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        break;
                }
            }
            static void Gra()
            {
                int wielkosc = 10;
                Console.WriteLine("Wybierz wielkość Planszy:");
                Console.WriteLine("Domyślna wartość to 10x10");
                bool z = int.TryParse(Console.ReadLine(),out wielkosc);
                if (z)
                {
                    Console.WriteLine("Dokonano wybor " + wielkosc);
                }
                else
                {
                    Console.WriteLine("brak wyboru");
                }
            }
            static void Credits()
            {
                Console.WriteLine("Projekt na Wprowadzenie do Programowania");
                Console.WriteLine("Oskar Kalata");
                Console.WriteLine("Nr Indeksu: 12626");
                Console.ReadKey();
            }
        }
    }
    public class logic
    {

    }
}
