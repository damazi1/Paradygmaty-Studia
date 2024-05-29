namespace lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] peopleArray = new Person[3]
            {
                new Person("Jan", "Nowak"),
                new Person("Jan1", "Nowak1"),
                new Person("Jan2", "Nowak2"),
            };
            People peopleList = new People(peopleArray);
            var e1 = peopleList.GetEnumerator();
            while (e1.MoveNext())
            {
                Console.WriteLine($"Rekord= {e1.Current.firstNmae}");
            }
            foreach (Person person in peopleList)
            {
                Console.WriteLine($"{person.firstNmae} {person.lastName}");
            }
        }
    }
}
