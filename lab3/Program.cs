using System;
using System.Collections.Generic;

namespace lab3
{
    class Item
    {
        public int Value { get; set; }
        public int Size { get; set; }
        public Item(int value, int size)
        {
            Value = value;
            Size = size;
        }
        public override string ToString()
        {
            return $"Value: {Value} Size: {Size}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //ZADANIE 1
            Console.WriteLine("ZADANIE 1");
            Console.WriteLine($"fib(50):{fib(50, new Dictionary<int, long>())} fibonnaci(50):{fibonnaci(50)}");


            //ZADANIE 2
            #region zadanie2
            #region dla 6
            //Sprawdzenie poprawności obliczania dla 6. przegródek
            Console.WriteLine("\nZADANIE 2");
            Console.WriteLine("====================");
            Console.WriteLine("Dla 6 przegródek");
            Console.WriteLine("====================\n");
            var Items1_6 = new Item[] { new Item(1, 1), new Item(2, 2), new Item(4, 4) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items1_6)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 6\nPoprawna wartość: 6\nWartość funkcji: {zadanie2(6, Items1_6)}\n");

            var Items2_6 = new Item[] { new Item(3,1), new Item(2,2), new Item(4, 4) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items2_6)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 6\nPoprawna wartość: 7\nWartość funkcji: {zadanie2(6, Items2_6)}\n");

            var Items3_6 = new Item[] { new Item(3, 1), new Item(5, 2), new Item(4, 4) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items3_6)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 6\nPoprawna wartość: 8\nWartość funkcji: {zadanie2(6, Items3_6)}\n");
            #endregion

            #region dla 1
            //Dla 1. przegródki
            Console.WriteLine("\n====================");
            Console.WriteLine("Dla 1 przegródki");
            Console.WriteLine("====================\n");

            var Items1_1 = new Item[] { new Item(1, 1), new Item(2, 2), new Item(4, 4) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items1_1)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 1\nPoprawna wartość: 1\nWartość funkcji: {zadanie2(1, Items1_1)}\n");

            var Items2_1 = new Item[] { new Item(1, 1), new Item(2, 1), new Item(4, 1) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items2_1)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 1\nPoprawna wartość: 4\nWartość funkcji: {zadanie2(1, Items2_1)}\n");
            #endregion

            #region dla 2
            //Dla 2. przgródek
            Console.WriteLine("\n====================");
            Console.WriteLine("Dla 2 przegródek");
            Console.WriteLine("====================\n");

            var Items1_2 = new Item[] { new Item(1, 1), new Item(2, 2), new Item(8, 4) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items1_2)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 2\nPoprawna wartość: 2\nWartość funkcji: {zadanie2(2, Items1_2)}\n");

            var Items2_2 = new Item[] { new Item(1, 2), new Item(2, 2), new Item(8, 4) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items2_2)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 2\nPoprawna wartość: 2\nWartość funkcji: {zadanie2(2, Items2_2)}\n");

            var Items3_2 = new Item[] { new Item(1, 1), new Item(3, 2), new Item(8, 4) };
            Console.WriteLine("======PRZYKŁAD======");
            foreach (Item item in Items3_2)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"Size: 2\nPoprawna wartość: 3\nWartość funkcji: {zadanie2(2, Items3_2)}");
            #endregion
            Console.WriteLine("\n====================");
            Console.WriteLine("Dla 50 przegródek\ni 10 przedmiotów\n");

            var Items = new Item[] { new Item(1, 10), new Item(2, 12), new Item(8, 14), new Item(10, 16), new Item(15, 18), new Item(20, 20), new Item(50, 22), new Item(167, 24), new Item(3, 26), new Item(12, 28) };
            foreach (Item item in Items)
                Console.Write($"|[{item}]| \n");
            Console.WriteLine($"\nSize: 50\nWartość funkcji: {zadanie2(50, Items)}\n");
            #endregion

        }
        //memoizacja z użyciem słownika
        static long fib(int n, Dictionary<int, long> memo)
        {
            if (memo.ContainsKey(n))
                return memo[n];

            if (n <= 2)
                return 1;

            memo[n] = fib(n - 1, memo) + fib(n - 2, memo);
            return memo[n];
        }
        //ZADANIE 1
        static long fibonnaci(int n)
        {
            long result = 0, n1 = 1, n2 = 1;
            for (int i = 1; i < n - 1; i++)
            {
                if (i <= 2)
                    result = 1;

                result = n1 + n2;
                n1 = n2;
                n2 = result;
            }
            return result;
        }
        //ZADANIE 2
        //Program oblicza wartość dla n przegródek
        static int zadanie2(int size, Item[] Items)
        {
            Item mostValuable = null;
            double highestValue = -1;
            int result = 0;

            for (int i = 1; i <= Items.Length; i++)
            {
                foreach (var item in Items)
                {
                    if (mostValuable is not null && (item.Value / item.Size) >= highestValue && item.Size > mostValuable.Size)
                        mostValuable = item;

                    if ((item.Value / item.Size) > highestValue)
                    {
                        mostValuable = item;
                        highestValue = (item.Value / item.Size);
                    }
                }

                if (mostValuable.Size <= size)
                {
                    size -= mostValuable.Size;
                    result += mostValuable.Value;
                    Items[Array.IndexOf(Items, mostValuable)].Value = 0;
                    highestValue = -1;
                }
                else
                {
                    Items[Array.IndexOf(Items, mostValuable)].Value = 0;
                    highestValue = -1;
                }
            }
            return result;
        }
    }
}