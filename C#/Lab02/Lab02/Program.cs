using System;
using System.Collections.Generic;

namespace lab02
{
    class OperacjeNaLiscie
    {
        public static List<T> Zmiana<T>(List<T> lista, Func<T, T> operacja)
        {
            List<T> rezultat = new List<T>();
            for (int i = 0; i < lista.Count; i++)
            {
                rezultat.Add(operacja(lista[i]));
            }
            return rezultat;
        }
    }
    class OperacjeNaLiscie1
    {
        public static List<T> Zmiana<T>(List<T> lista, char znak, Func<T,char, bool> warunek)
        {
            List<T> rezultat = new List<T>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (warunek(lista[i], znak)) rezultat.Add(lista[i]);
            }
            return rezultat;
        }
    }
    public class Program
    {
        static int PodniesDoKwadratu(int x) => x * x;
        static bool TylkoNaP(string wartosc, char znak) => wartosc[0] == znak;
        public static Func<T, T, T> odwroc<T>(Func<T, T, T> Funk) => (T a, T b) => Funk(b, a);
        static Func<double, double, double> fun1 = (a, b) => a / b;
        public static Func<double, double> zloz(Func<double, double> f1, Func<double, double> f2) => (double x) => f1(f2(x));
        public static Func<double, double> fun3 = (double a) => a * a;
        public static Func<double, double> fun4 = (double a) => a + a;

        public static void Main(String[] args)
        {
            Console.WriteLine("---------- Operacje na liczbach ----------");
            List<int> liczby = new List<int>() { 1, 2, 3, 4, 5 };
            for (int i = 0;i < liczby.Count;i++) Console.WriteLine(liczby[i]);
            Console.WriteLine("------------------------------");
            List<int> liczby2 = OperacjeNaLiscie.Zmiana(liczby, PodniesDoKwadratu);
            for (int i = 0; i<liczby2.Count; i++) Console.WriteLine(liczby2[i]);

            Console.WriteLine("---------- Operacje na stringach ----------");
            List<string> lista1 = new List<string>()
             {
             "jakis tekst",
             "pewien tekst",
             "przypakowy tekst",
             "dziwny tekst"
             };

            for (int i = 0; i < lista1.Count; i++)
                Console.WriteLine(lista1[i]);
            Console.WriteLine("-------------------");
            List<string> lista2 =
            OperacjeNaLiscie1.Zmiana(lista1, 'p', TylkoNaP);
            for (int i = 0; i < lista2.Count; i++)
                Console.WriteLine(lista2[i]);

            Console.WriteLine("---------- Operacje na Funkcjach ----------");
            var x1 = 10;
            var x2 = 2;
            var wynik1 = fun1(x1, x2);
            var fun2 = odwroc(fun1);
            var wynik2 = fun2(x2, x1);
            Console.WriteLine($"Wynik 1 = {wynik1}, Wynik 2 = {wynik2}");

            var wynik3 = zloz(fun3, fun4);
            double result = wynik3(5);
            Console.WriteLine($"Wynik zlozenia = {result}");

        }
    }
}