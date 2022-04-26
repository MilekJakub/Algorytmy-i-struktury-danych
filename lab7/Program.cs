using System;

namespace lab7
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }

    class Stack<T>
    {
        private Node<T> _head;

        public void Push(T value)
        {
            Node<T> newNode = new Node<T> { Value = value, Next = _head };
            newNode.Next = _head;
            _head = newNode;
        }

        public bool isEmpty()
        {
            return _head == null;
        }

        public T Pop()
        {
            if (isEmpty())
            {
                throw new Exception();
            }
            T result = _head.Value;
            _head = _head.Next;
            return result;
        }

        public void Reverse()
        {

        }
    }

    class Queue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count = 0;

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Insert(T value)
        {
            Node<T> node = new Node<T> { Value = value };
            if (IsEmpty())
            {
                _head = node;
                _tail = _head;
                _count++;
                return;
            }
            _count++;
            _tail.Next = node;
            _tail = node;
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is empty.");
            }
            T result = _head.Value;
            _head = _head.Next;
            _count--;
            return result;
        }

        public T[] ToArray()
        {
            if (IsEmpty())
            {
                return new T[0];
            }
            T[] array = new T[_count];
            Node<T> node = _head;
            int i = 0;
            while (node != null)
            {
                array[i++] = node.Value;
                node = node.Next;
            }
            return array;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stos = new Stack<string>();
            stos.Push("jeden");
            stos.Push("dwa");
            stos.Push("trzy");
            stos.Push("cztery");
            stos.Push("pięć");

            while (!stos.isEmpty())
            {
                Console.WriteLine(stos.Pop());
            }

            Queue<string> kolejka = new Queue<string>();
            kolejka.Insert("jeden");
            kolejka.Insert("dwa");
            kolejka.Insert("trzy");
            kolejka.Insert("cztery");
            kolejka.Insert("pięć");
            Console.WriteLine();

            string[] arr = kolejka.ToArray();
            Console.WriteLine(String.Join(", ",arr));
            while (!kolejka.IsEmpty())
            {
                Console.WriteLine(kolejka.Remove());
            }

            //Zadanie 4
            //Nie działa
            Stack<char> stosik = new Stack<char>();
            string wyrazenie = "()";
            char[] charArr = wyrazenie.ToCharArray();
            bool isValid = true;

            foreach (char character in charArr)
            {
                    switch (character)
                    {
                        case '[':
                        case '(':
                        case '{':
                            stosik.Push(character);
                            break;

                        case ']':
                            if (stosik.Pop() != '[')
                                isValid = false;
                            break;

                        case ')':
                            if (stosik.Pop() != '(')
                                isValid = false;
                            break;

                        case '}':
                            if (stosik.Pop() != '{')
                                isValid = false;
                            break;
                    }

                    if (!stosik.isEmpty())
                        isValid = false;
            }

            Console.WriteLine(isValid);
        }
    }
}
