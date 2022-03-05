using System;

namespace lab1_algorytmy
{
    class Program
    {
        static void Main(string[] args)
        {
            var tab = new int[] { 234, 1, 23, 56, 1234, 67 };
            Console.WriteLine(zadanie1(tab));

            var tab2 = new int[] { 1, 224, 2345, 2 };
            var k = 3;
            Console.WriteLine(zadanie2(tab2, k));

            var tab3 = new int[] { 1, 2, 4, 2, 4 };
            k = 2;
            Console.WriteLine(zadanie3(tab3, k));
        }

        static int zadanie1(int[] tab)
        {
            var min = 99;
            int index = -1;

            for (var i = 0; i < tab.Length; i++)
            {
                if (tab[i] < min && tab[i] >= 10)
                {
                    min = tab[i];
                    index = i;
                }
            }
            return index;
        }

        static int zadanie2(int[] tab, int k)
        {
            var sum = 0;
            foreach (var number in tab)
            {
                sum += number;
            }

            var average = sum / tab.Length;
            sum = 0;

            for (int i = 0; i < tab.Length; i++)
            {
                var digit = tab[i].ToString().Length;
                if (tab[i] < 0)
                    digit--;

                if (tab[i] < average && digit == k)
                    sum += tab[i];
            }
            return sum;
        }

        static int? zadanie3(int[] tab, int k)
        {
            var min = -1;
            var counter = 0;

            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] > min)
                {
                    min = tab[i];
                    counter++;
                }
            }

            var exitTab = new int[counter];
            min = -1;
            counter = 0;

            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] > min)
                {
                    exitTab[counter] = tab[i];
                    min = tab[i];
                    counter++;
                }
            }

            if (min == -1)
            {
                return null;
            }

            return exitTab[k - 1];
        }
    }
}