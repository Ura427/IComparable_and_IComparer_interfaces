using System;

namespace IComparer_and_IComparable_interfaces
{
    public class Person : IComparable
    {
        //Properties
        public byte age { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public string name { get; set; }

        //Constructor of the Person class
        public Person(string name, byte age, double height, double weight)
        {
            this.name = name;
            this.age = age;
            this.height = height;
            this.weight = weight;
        }


        //This method determines how the Person class objects will be compared by default
        int IComparable.CompareTo(object obj)
        {
            Person p = obj as Person;
            if (p != null)
            {

                if (this.age > p.age) return 1;
                else if (this.age < p.age) return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Parameter should be Person type");
        }
    }

    //Auxiliary class for comparing two instances of the Person type on the height field
    public class PersonHeightComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Person p1 = x as Person;
            Person p2 = y as Person;

            if (p1 != null && p2 != null)
            {
                if (p1.height > p2.height) return 1;
                else if (p1.height < p2.height) return -1;
                else return 0;
            }
            else
                throw new ArgumentException("Parameters don't belong to class Person");

        }
    }

    //Auxiliary class for comparing two instances of the Person type on the weight field
    public class PersonWeightComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Person p1 = x as Person;
            Person p2 = y as Person;

            if (p1 != null && p2 != null)
            {
                if (p1.weight > p2.weight) return 1;
                else if (p1.weight < p2.weight) return -1;
                else return 0;
            }
            else
                throw new ArgumentException("Parameters don't belong to class Person");

        }
    }
    //Auxiliary class for comparing two instances of the Person type on the name field
    public class PersonNameComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Person p1 = x as Person;
            Person p2 = y as Person;

            if (p1 != null && p2 != null)
            {
                return String.Compare(p1.name, p2.name); //Вбудований метод, який сортує данні типу string в лексикографічному порядку
            }
            else
                throw new ArgumentException("Parameters don't belong to class Person");

        }
    }




    class Program
    {
        //Returns all data of a particular instance of the Person class
        static void Show(Person[] MD, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Name: " + MD[i].name + " Age: " + MD[i].age + " Height: " + MD[i].height + " Weight: " + MD[i].weight);
            }

            Console.WriteLine(new string('/', 30));
        }

        static void Main(string[] args)
        {
            Console.Write("Input number of members: ");
            int n = Convert.ToInt32(Console.ReadLine());

            //Create an array of the Person type to store objects
            var Dossier = new Person[n];

            //Filling person data
            for (int i = 0; i < n; i++)
            {
                Console.Write("Input person's name: ");
                string name = Console.ReadLine();
                Console.Write("Input person's age: ");
                byte age = Convert.ToByte(Console.ReadLine());
                Console.Write("Input person's height: ");
                double height = Convert.ToDouble(Console.ReadLine());
                Console.Write("Input person's weight: ");
                double weight = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine(new string('*', 30));

                Dossier[i] = new Person(name, age, height, weight);
            }

            Show(Dossier, n);


            while (true)
            {
                Console.WriteLine("Compare by: Name(N), Height(H), Weight(W), Age(A)");
                char compare = Convert.ToChar(Console.ReadLine());
                switch (compare)
                {
                    case 'N':
                        Array.Sort(Dossier, new PersonNameComparer());
                        break;
                    case 'H':
                        Array.Sort(Dossier, new PersonHeightComparer());
                        break;
                    case 'W':
                        Array.Sort(Dossier, new PersonWeightComparer());
                        break;
                    case 'A':
                        Array.Sort(Dossier);
                        break;
                }


                Show(Dossier, n);
            }


        }

    }
}
