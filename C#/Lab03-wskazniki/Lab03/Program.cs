namespace Lab03
{
    public class OperacjeNaLiscie
    {
        public static List<T> Zmiana<T>(List<T> lista, Func<T,T>operacja) 
        {
            List<T> result = new List<T>();
            for(int i = 0; i < lista.Count; i++)
            {
                result.Add(operacja(lista[i]));
            }
            return result;
        }
    }

    public class OperacjeNaLiscie1
    {
        public static List<T> Zmiana<T, T2>(List<T> lista,T2 znak, Func<T,T2, bool> warunek)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (warunek(lista[i],znak))
                    result.Add(lista[i]);
            }
            return result;
        }
    }

    public class OperacjeNaLiscie2
    {
        public static List<T> Zmiana<T>(List<T> lista, Func<T, bool> warunek)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (warunek(lista[i]))
                    result.Add(lista[i]);
            }
            return result;
        }
    }


    internal class Program
    {
        static int PodniesDoKwadratu(int x) => x * x;
        static int Dodaj3(int x) => x + 3;
        static bool TylkoNaP(string wartosc, char znak) => wartosc[0] == znak;
        static Func<string, bool> OdDanejLitry(char znak) => (string wartosc) => wartosc[0] == znak;
        static Func<double, double, double> funkcja1 = (a,b) => a/b;
        static Func <double, double, double> odwroc(Func<double, double, double> funk) => (double a, double b) => funk(b, a);
        static Func<int, int> zloz(Func<int,int> f1, Func<int,int> f2) => (int x) => f1(f2(x));
        static void Main(string[] args)
        {
            List<int> liczby = new List<int>() {1,2,3,4,5};

            for(int i = 0; i< liczby.Count; i++ )
            {
                Console.WriteLine(liczby[i]);
            }
            Console.WriteLine("------------------------------");
            List<int> liczby2 = OperacjeNaLiscie.Zmiana(liczby, PodniesDoKwadratu);
            for (int i = 0;i< liczby2.Count; i++)
            {
                Console.WriteLine(liczby2[i]);
            }

            Console.WriteLine("----- Przyklad 2 String -----");
            List<string> lista1 = new List<string>() { "tekst1", "prawdopodobnie tekst 2", "bardzo mozliwe ze tekst 3", "przypadkowy tekst 4" };
            for (int i=0;i< lista1.Count;i++)
                Console.WriteLine(lista1[i]);
            Console.WriteLine("------------------------------");
            List<string> lista2 = OperacjeNaLiscie1.Zmiana(lista1,'p', TylkoNaP);
            for (int i=0; i< lista2.Count; i++)
            {
                Console.WriteLine(lista2[i]);
            }

            Console.WriteLine("----- Przyklad 3 Dodanie Funkcji -----");
            lista2 = OperacjeNaLiscie2.Zmiana(lista1, OdDanejLitry('p'));
            for (int i=0; i<lista2.Count;i++)
                Console.WriteLine(lista2[i]);

            Console.WriteLine("----- Zadanie 3.1 -----");
            var x1 = 10;
            var x2 = 2;
            var w1 = funkcja1(x1, x2);
            var funkcja2 = odwroc(funkcja1);
            var w2 = funkcja2(x2, x1);
            Console.WriteLine("Wynik1 = "+w1);
            Console.WriteLine("Wynik2 = " + w2);

            Console.WriteLine("----- Zadanie 3.2 -----");
            int res = zloz(PodniesDoKwadratu, Dodaj3)

        }
    }
}
