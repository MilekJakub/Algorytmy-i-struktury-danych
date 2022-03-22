using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            //ZADANIE 1
            Console.WriteLine("ZADANIE 1");
            var tablicaStringow = new string[] { "Jak", "Kuba", "Bogu", "tak", "Bóg", "Kubie" };
            InsertionSort(tablicaStringow);

            //ZADANIE 2
            Console.WriteLine("\nZADANIE 2");
            var tablicaIntow = new int[] { 5, 50, 10, 2, 81, 4, 19, 1 };
            InsertionSort(tablicaIntow);

            //ZADANIE 3
            Console.WriteLine("\nZADANIE 3");
            var tablicaStringow2 = new string[] { "Pan", "Jerzyna", "ze", "Szczecina" };
            SelectionSort(tablicaStringow2);

            //ZADANIE 4
            Console.WriteLine("\nZADANIE 4");
            SelectionSort(tablicaIntow);
        }
        //ZADANIE 1
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
        //ZADANIE 2
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
        //ZADANIE 3
        static void SelectionSort(string[] stringTab)
        {
            for(int i = 0; i < stringTab.Length; i++)
            {
                int min = stringTab[i].Length;
                for (int j = i; j < stringTab.Length; j++)
                {
                    if (stringTab[j].Length < min)
                    {
                        min = stringTab[j].Length;;
                        string temp = stringTab[j];
                        stringTab[j] = stringTab[i];
                        stringTab[i] = temp;
                    }
                }
            }
            foreach (var item in stringTab)
            {
                Console.WriteLine(item);
            }
        }
        //ZADANIE 4
        static void SelectionSort(int[] intTab)
        {
            for (int i = 0; i < intTab.Length; i++)
            {
                int max = intTab[i];
                for (int j = i; j < intTab.Length; j++)
                {
                    if (intTab[j] > max)
                    {
                        max = intTab[j];
                        int temp = intTab[j];
                        intTab[j] = intTab[i];
                        intTab[i] = temp;
                    }
                }
            }
            foreach (var item in intTab)
            {
                Console.WriteLine(item);
            }
        }
    }
}