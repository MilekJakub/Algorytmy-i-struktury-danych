using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var tablicaStringow = new string[] { "Jak", "Kuba", "Bogu", "tak", "Bóg", "Kubie" };
            InsertionSort(tablicaStringow);
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
            Console.WriteLine("Sorted array:");
            foreach (var item in stringTab)
            {
                Console.WriteLine(item);
            }
        }
    }
}
