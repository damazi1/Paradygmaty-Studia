namespace Lab02
{
    class Odcinek : IComparable<Odcinek>
    {
        public double x1, y1, x2, y2;
        public Odcinek(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1; this.x2 = x2; this.y1 = y1; this.y2 = y2;
        }
        public double Dlugosc()
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1)+(y2 - y1)*(y2-y1));
        }
        public int CompareTo(Odcinek odc) {
            if (this.Dlugosc() < odc.Dlugosc())
                return 1;
            else
                return 0;
        }
    }
    class Osoba : IComparable<Osoba>
    {
        public string imie, nazwisko;
        public int wiek;
        public Osoba(string imie, string nazwisko,  int wiek)
        {
            this.imie = imie; this.nazwisko = nazwisko; this.wiek = wiek;
        }
        public int CompareTo(Osoba os)
        {
            if (this.wiek < os.wiek)
                return 1;
            else
                return 0;
        }
        public override string ToString()
        {
            return $"{imie} {nazwisko} / wiek: {wiek}";
        }
    }
    class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
    class BinartSearchTree<T> where T : IComparable<T>
    {
        private Node<T> root;
        public BinartSearchTree()
        {
            root = null;
        }
        public void Insert(T value)
        {
            root = InsertRec(root, value);
        }
        private Node<T> InsertRec(Node<T> root, T value)
        {
            if (root == null)
            {
                root = new Node<T>(value);
                return root;
            }
            if (value.CompareTo(root.Value) < 0)
            {
                root.Left = InsertRec(root.Left, value);
            }
            else if (value.CompareTo(root.Value) > 0)
            {
                root.Right = InsertRec(root.Right, value);
            }
            return root;
        }
        public void InOrderTravarsal(Action<T> action)
        {
            InOrderRec(root,action);
        }
        private void InOrderRec(Node<T> root, Action<T> action) { 
            if(root != null)
            {
                InOrderRec(root.Left, action);
                action(root.Value);
                InOrderRec(root.Right,action);
            }
        }
    
    }
    internal class Program
    {
        public static void sortuj<T>(T[] tablica) where T : IComparable<T> {
            T tmp;
            bool zmienna = true;
            while (zmienna)
            {
                zmienna = false;
                for (int i = 0; i < tablica.Length - 1; i++)
                {
                    if (tablica[i].CompareTo(tablica[i + 1]) == 1)
                    {                        
                            zmienna = true;
                            tmp = tablica[i];
                            tablica[i] = tablica[i + 1];
                            tablica[i + 1] = tmp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("+++++ Przyklad 1 +++++");
            Odcinek o1 = new Odcinek(0,0,1,1);
            Odcinek o2 = new Odcinek(0,0,2,2);
            Odcinek o3 = new Odcinek(0,0,0.5,0.5);
            Odcinek o4 = new Odcinek(0,0,3,4);
            Odcinek o5 = new Odcinek(0, 0, 5, 5);

            Odcinek[] tab = { o1, o2, o3, o4, o5 };
            int[] tab2 = { 3, 4, -2, 5, 6 };
            for (int i = 0; i < tab.Length; i++)
                Console.WriteLine("dlugosc = " + tab[i].Dlugosc());
            sortuj<Odcinek>(tab);
            Console.WriteLine("------------------------------");
            for (int i = 0; i < tab.Length; i++)
                Console.WriteLine("dlugosc = " + tab[i].Dlugosc());
            sortuj<int>(tab2);


            Console.WriteLine("+++++ Zad 1.4 +++++");
            Osoba os1 = new Osoba("Jan", "Nowak", 15);
            Osoba os2 = new Osoba("Hubert", "Pawlik", 59);
            Osoba os3 = new Osoba("Krzysztof", "Kowalski", 11);
            Osoba os4 = new Osoba("Anna", "Mala", 20);
            Osoba[] ostab = { os1, os2, os3, os4 };
            for (int i = 0; i < ostab.Length; i++)
                Console.WriteLine(ostab[i].ToString());
            sortuj<Osoba>(ostab);
            Console.WriteLine("------------------------------");
            for (int i = 0; i < ostab.Length; i++)
                Console.WriteLine(ostab[i].ToString());

            Console.WriteLine("------------------------------");

            
        }
    }
}
