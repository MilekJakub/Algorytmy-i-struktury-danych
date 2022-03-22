using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var tablicaStringow = new string[] { "Jak", "Kuba", "Bogu", "tak", "Bóg", "Kubie" };
            InsertionSort(tablicaStringow);
            var tablicaIntow = new int[] { 5, 50, 10, 2, 81, 4, 19, 1 };
            InsertionSort(tablicaIntow);
        }
        static void InsertionSort(string[] stringTab)
        {
            for (int i = 0; i < stringTab.Length - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if(stringTab[j - 1].CompareTo(stringTab[j]) == 1)
                    {
                        string temp = stringTab[j - 1];
                        stringTab[j - 1] = stringTab[j];
                        stringTab[j] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted string array:");
            foreach (var item in stringTab)
            {
                Console.WriteLine(item);
            }
        }
        static void InsertionSort(int[] intTab)
        {
            for (int i = 0; i < intTab.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (intTab[j -1] > intTab[j])
                    {
                        int temp = intTab[j - 1];
                        intTab[j - 1] = intTab[j];
                        intTab[j] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted int array:");
            foreach (var item in intTab)
            {
                Console.WriteLine(item);
            }
        }
    }
}