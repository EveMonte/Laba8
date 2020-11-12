using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface ICollection<T>
{
    void AddObject(T obj);
    void DeleteObject(T obj);
    void ShowAll();
}

namespace _8lab
{

    //Класс, который хранит значение информационного поля и ссылку на следующий элемент (то есть это наш список)
    internal class Node<T>
    {
        public T Artist { get; set; }
        public Node<T> Next { get; set; }

        
    }



    //Основной класс, в котором определяются методы для работы со списком и т.д.
    class ArtistList<T> : ICollection<T> where T : class
    {



        Node<T>[] Artists;
        public List<T> Collections;
        public void AddObject(T value)
        {
            Collections.Add(value);
        }
        public void DeleteObject(T obj)
        {
            Collections.Remove(obj);
        }
        public void ShowAll()
        {
            foreach (T o in Collections)
            {
                Console.WriteLine(o.ToString());
            }
        }
        public ArtistList(int i)
        {
            Artists = new Node<T>[i];
        }

        //Индексатор
        public T this[int index]
        {
            get
            {
                return Artists[index].Artist;
            }
            set
            {
                Artists[index].Artist = value;
            }
        }
        //Вложенный объект owner
        public class Owner
        {
            private int _Id;
            private string _Name;
            private string _Organization;

            public int ID
            {
                get
                {
                    return _Id;
                }

            }
            public string Name
            {
                get
                {
                    return _Name;
                }

            }
            public string Organization
            {
                get
                {
                    return _Organization;
                }

            }
            public Owner(int Id, string Name, string Organization)
            {
                _Id = Id;
                Name = Name;
                Organization = Organization;
            }
        }

        //Вложенный объект Date
        public class Date
        {
            private string dateOfCreation;

            public string DateOfCreation
            {
                get
                {
                    return dateOfCreation;
                }
            }

            public Date(string _dateOfCreation)
            {
                dateOfCreation = _dateOfCreation;
            }
        }

        private Node<T> Head { get; set; }
        private Node<T> Current { get; set; }
        private int size;
        public int Size { get; set; }
        public static Owner owner;
        public static Date date;

        static ArtistList()
        {
            owner = new Owner(27, "Dmitry", "Yellow Submarine Ltd.");
            date = new Date(DateTime.Now.ToString());
        }
        public static void OwnerInfo()
        {
            Console.WriteLine($"Владелец: {owner.Name}\nИдентификатор владельца: {owner.ID}\nКомпания владельца: {owner.Organization}\nДата создания: {date.DateOfCreation}");
        }



        //Добавление элемента в список
        public void Push(T Artist)
        {
            Size++;
            var node = new Node<T>() { Artist = Artist };
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Current.Next = node;
            }
            Current = node;

        }

        //Вывод значений всех элементов списка
        public void Output()
        {
            Node<T> n = Head;
            while (n != null)
            {
                Console.WriteLine($"Исполнитель: {n.Artist}");
                n = n.Next;
            }
        }

        //Удаление узла
        public void DeleteNode(int number)
        {

            if ((Head != null) && (number < Size) && (number >= 0))
            {
                Node<T> n = Head;
                Node<T> prevNode = null;
                if (number == 0)
                {
                    n = n.Next;
                    Head = n;
                }
                if (number == Size)
                {
                    for (int i = 0; i < number - 2; i++)
                    {
                        n = n.Next;
                    }

                    n.Next = null;
                }
                else
                {
                    for (int i = 0; i < number - 1; i++)
                    {
                        prevNode = n;
                        n = n.Next;

                    }
                    n.Next = n.Next.Next;
                }

            }
        }

        public Node<T> GetHead()
        {
            return this.Head;
        }

        /*
        //Перегрузка бинарного оператора +
        public static ArtistList operator +(ArtistList list, string item)
        {
            list.Push(item);
            return list;
        }

        //Попарная перегрузка операторов -- и ++
        public static ArtistList operator --(ArtistList list)
        {
            list.DeleteNode(list.Size - 1);
            //list.Size--;
            return list;
        }
        public static ArtistList operator ++(ArtistList list)
        {
            string artist;
            Console.WriteLine("Введите имя исполнителя/группы: ");
            artist = Console.ReadLine();
            list.Push(artist);
            return list;
        }

        //Попарная перегрузка операторов != и ==
        public static bool operator !=(ArtistList a1, ArtistList a2)
        {
            Node n1 = a1.Head;
            Node n2 = a2.Head;
            if (n1.Artist != n2.Artist)
            {
                return true;
            }
            return false;
        }
        public static bool operator ==(ArtistList a1, ArtistList a2)
        {
            Node n1 = a1.Head;
            Node n2 = a2.Head;
            if (n1.Artist != n2.Artist)
            {
                return false;
            }
            return true;
        }

        //Попарная перегрузка операторов true и false
        public static bool operator true(ArtistList a)
        {
            Node n1 = a.Head;
            Node n2 = a.Head.Next;
            int index = 2;      //показывает на номер (НЕ ИНДЕКС!!!) звена списка, на который указывает n2
            while (index <= a.Size)
            {
                if (String.Compare(n1.Artist, n2.Artist) >= 0)
                {
                    return false;
                }
                else
                {
                    index++;
                    n1 = n1.Next;
                    n2 = n2.Next;
                }
            }
            return true;
        }
        public static bool operator false(ArtistList a)
        {
            Node n1 = a.Head;
            Node n2 = a.Head.Next;
            int index = 2;      //показывает на номер (НЕ ИНДЕКС!!!) звена списка, на который указывает n2
            while (index <= a.Size)
            {
                if (String.Compare(n1.Artist, n2.Artist) >= 0)
                {
                    return true;
                }
                else
                {
                    index++;
                    n1 = n1.Next;
                    n2 = n2.Next;
                }
            }
            return false;
        }*/



    }

    class ListOutOfRange : Exception
    {
        public string message = "Вы вышли за пределы списка!";
        public string diagnostics = "Уберите лишний Push!";
        public ListOutOfRange(string message) : base(message)
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Введите размер списка!");
            int Size = Convert.ToInt32(Console.ReadLine());*/
            ArtistList<string> a1 = new ArtistList<string>(5);
            a1.Push("Linkin Park");
            a1.Push("Mike Shinoda");
            a1.Push("Grey Daze");
            a1.Push("Dead By Sunrise");
            //a1.Push("Fort Minor");

            bool switcher = false;
            try
            {
                ArtistList<string> a2 = new ArtistList<string>(5);
                a2.Push("Yonaka");
                a2.Push("Imagine Dragons");
                a2.Push("twenty one pilots");
                a2.Push("Kasabian");
                a2.Push("grandson");
                a2.Push("Nizkiz");
                if(a2.Size > 5)
                {
                    throw new ListOutOfRange("Вы вышли за пределы списка!");
                }
            }

            catch (ListOutOfRange ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.Source);
                switcher = true;
            }
            finally
            {
                if (switcher)
                {
                    Console.WriteLine("Исключение обработано");
                }
                else
                {
                    Console.WriteLine("Исключение не обработано либо не произошло");
                }
            }

            Console.WriteLine("\nПервый список:");
            a1.Output();
            //Console.WriteLine("\nДобавим-ка Skillet в список");
            //a1 = a1 + "Skillet";
            //a1.Output();

            /*if (a1)
            {
                Console.WriteLine("\nЭлементы списка a1 упорядочены.");
            }
            else
                Console.WriteLine("\nЭлементы списка a1 НЕ упорядочены.");
            */
            /*Console.WriteLine("\nДо использования перегруженного оператора --:");
            a2.Output();
            a2 = a2--;
            //a2.DeleteNode(0);
            Console.WriteLine("\nПосле использования перегруженного оператора --:");
            a2.Output();*/
            ArtistList<string>.OwnerInfo();
            /*Console.WriteLine($"\nStringCounter: {a2.StringCounter()}");
            Console.WriteLine($"isNullElem: {a1.isNullElem()}");
            a2.SumOfStrings();
            a1.FirstAndLastString();*/
        }
    }

    /*public static class myListExtension
    {
        internal static int StringCounter(this ArtistList a)
        {
            return a.Size;
        }
        internal static bool isNullElem(this ArtistList a)
        {
            Node n = a.GetHead();
            for (int i = 0; i < a.Size; i++)
            {
                if (n.Artist == null)
                {
                    return true;
                }
            }
            return false;
        }
    }


    public static class StatisticOperation
    {
        internal static void SumOfStrings(this ArtistList artist)
        {
            string Sum = "";
            Node head = artist.GetHead();
            for (int i = 1; i < artist.Size; i++)
            {
                Sum += head.Artist;
                head = head.Next;
            }
            Console.WriteLine($"Полученный Фрашкенштейн из суммы названий исполнителей: {Sum}");
        }

        internal static void FirstAndLastString(this ArtistList artist)
        {
            Node head = artist.GetHead();
            string first = head.Artist;
            string last = first;
            int key;
            Node next = head.Next;
            while (next.Next != null)
            {
                key = String.Compare(first, next.Artist);
                if (key > 0)
                {
                    first = next.Artist;
                }
                if (key < 0)
                {
                    last = next.Artist;
                }
                next = next.Next;
            }
            Console.WriteLine($"Самое первое слово в алфавитном порядке: {first}");
            Console.WriteLine($"Самое последнее слово в алфавитном порядке: {last}");
        }
    }
*/
}