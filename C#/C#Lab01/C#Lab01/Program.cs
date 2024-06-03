using System;
using System.Diagnostics;

namespace C_Lab01
{
    class PewnaKlasa<T>
    {
        public T Zmienna1;
        public T Zmienna2;
        public PewnaKlasa(T zmienna1, T zmienna2)
        {
            Zmienna1 = zmienna1;
            Zmienna2 = zmienna2;
        }
    }
    class Odcinek : IComparable<Odcinek>
    {
        public double x1, y1, x2, y2;
        public Odcinek(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public double Dlugosc()
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
        public int CompareTo(Odcinek odc)
        {
            if (this.Dlugosc() < odc.Dlugosc()) return 1;
            else return -1;
        }
    }
    class Para<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Para(T x, T y)
        {
            X = x; Y = y;
        }
    }
    class Para1
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Para1(int x, int y)
        {
            X = x; Y = y;
        }
    }
    class Osoba : IComparable<Osoba>
    {
        public string Imię { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public Osoba(string imię, string nazwisko, int wiek)
        {
            Imię = imię;
            Nazwisko = nazwisko;
            Wiek = wiek;
        }
        public int CompareTo(Osoba o)
        {
            if (this.Wiek < o.Wiek) return 1;
            else return -1;
        }
        public override string ToString()
        {
            return $"Osoba: {Imię} {Nazwisko} / {Wiek}";
        }
    }
    internal class Program
    {
        static void Zamiana<T>( ref T x, ref T y)
        {
            T tmp = x;
            x = y; 
            y = tmp;
        }
        public static void sortuj<T>(T[] tablica) where T : IComparable<T> //Ograniczenie (constraints)
        {
            T tmp;
            bool zamiana = true;
            while (zamiana)
            {
                zamiana = false;
                for (int i = 0; i < tablica.Length - 1; i++)
                {
                    if (tablica[i].CompareTo(tablica[i + 1]) == 1)
                    {
                        zamiana = true;
                        tmp = tablica[i];
                        tablica[i] = tablica[i + 1];
                        tablica[i + 1] = tmp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---------- Zamiana ----------");
            int x = 10, y = 20;
            Zamiana(ref x, ref y);
            Console.WriteLine($"x = {x} , y = {y}");
            Console.WriteLine("---------- Klasa Generyczna ----------");
            PewnaKlasa<int> pewnaKlasa = new PewnaKlasa<int>(10, 20);
            Console.WriteLine($"Zmienna 1 = {pewnaKlasa.Zmienna1},zmienna 2 = {pewnaKlasa.Zmienna2}");
            Console.WriteLine("---------- Stoper ----------");
            Stopwatch stoper = new Stopwatch();
            stoper.Start();
            int tmp;
            for(int i = 0; i<100000000; i++)
            {
                tmp = i % 3;
            }
            stoper.Stop();
            Console.WriteLine($"Czas wykonania = {stoper.ElapsedMilliseconds} ms");
            Console.WriteLine("---------- Sortowanie ----------");
            Odcinek o1 = new Odcinek(0, 0, 1, 1);
            Odcinek o2 = new Odcinek(0, 0, 2, 2);
            Odcinek o3 = new Odcinek(0, 0, 0.5, 0.5);
            Odcinek o4 = new Odcinek(0, 0, 3, 4);
            Odcinek[] tab = { o1, o3, o2, o4 };
            int[] tab2 = { 3, 4, -2, 5, 6 };
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine($"dlugosc = "+tab[i].Dlugosc());
            }
            sortuj<Odcinek>(tab);
            Console.WriteLine("--------------------");
            for (int i = 0;i < tab.Length; i++)
            {
                Console.WriteLine($"dlugosc = " + tab[i].Dlugosc());
            }
            Console.WriteLine("---------- Porównanie szybkości ----------");
            stoper.Restart();
            stoper.Start();
            Para<int> para = new Para<int>(5, 10);
            for (int i = 0; i <10000000; i++)
            {
                tmp = para.X+para.Y;
            }
            stoper.Stop();
            Console.WriteLine($"Czas wykonania dla klasy generycznej: {stoper.ElapsedMilliseconds} ms");
            stoper.Restart();
            stoper.Start();
            Para1 para1 = new Para1(5, 10);
            for (int i = 0; i < 10000000; i++)
            {
                tmp = para1.X + para1.Y;
            }
            stoper.Stop();
            Console.WriteLine($"Czas wykonania dla klasy generycznej: {stoper.ElapsedMilliseconds} ms");

            Console.WriteLine("---------- Sortowanie osób ----------");
            Osoba[] osoby =
            {
                new Osoba("Pawel", "Domagal", 15),
                new Osoba("Pawel1", "Domagal1", 25),
                new Osoba("Pawel2", "Domagal2", 14),
            };
            foreach (Osoba o in osoby)
            {
                Console.WriteLine(o.ToString());
            }
            sortuj<Osoba>(osoby);
            Console.WriteLine("-------------------------");
            foreach (Osoba o in osoby)
            {
                Console.WriteLine(o.ToString());
            }
        }
    }
}
