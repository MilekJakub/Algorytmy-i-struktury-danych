using System;
using System.Collections;
using System.Collections.Generic;
using zadanie;

namespace lab_9
{
    class HashTable : IEnumerable<int>
    {
        List<int>[] arr = new List<int>[101];

        public bool Add(int value)
        {
            int hashCode = HashCode(value);
            if (arr[hashCode] == null)
                arr[hashCode] = new List<int>();

            if (arr[hashCode].Contains(value))
                return false;

            arr[hashCode].Add(value);
            return true;
        }

        public bool Remove(int value)
        {
            int hashCode = HashCode(value);
            if (arr[hashCode] == null || !arr[hashCode].Contains(value))
                return false;

            return arr[hashCode].Remove(value);
        }

        public bool Contains(int value)
        {
            int hashCode = HashCode(value);
            if (arr[hashCode] != null && arr[hashCode].Contains(value))
                return true;
            else
                return false;
        }

        private int HashCode(int value)
        {
            return value.GetHashCode() % arr.Length;
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var list in arr)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ZAJECIA();
            Zadanie.ZadanieMain();
        }

        private static void ZAJECIA()
        {
            HashTable table = new HashTable();
            Console.WriteLine(table.Add(3));
            Console.WriteLine(table.Add(3));
            table.Add(4);
            table.Add(5);
            table.Add(6);

            foreach (var item in table)
            {
                Console.WriteLine(item);
            }
        }
    }
}