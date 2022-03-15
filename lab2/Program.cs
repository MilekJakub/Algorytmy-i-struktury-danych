using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ZADANIE 1");
            int[] arr = { 2, 2, 2, 2, 2, 2 };
            var sum = Zadanie1(arr, arr.Length);
            Console.WriteLine($"Sum: {sum}");

            Console.WriteLine("ZADANIE 2");
            int[] arr2 = { 1, 2, 2, 2, 4, 6 };
            var counter = Zadanie2(arr2, arr2.Length, 2);
            Console.WriteLine(counter);

            Console.WriteLine("ZADANIE 3");
            Zadanie3(0,0); //Do poprawy, liczba 99 nie działa
        }
        static int Zadanie1(int[] tab, int tabLenght)
        {
            var sum = 0;
            tabLenght -= 1;
            if (tabLenght >= 0)
                sum = tab[tabLenght] + Zadanie1(tab, tabLenght);
            
            return sum;
        }
        static int Zadanie2(int[] tab, int tabLenght, int element)
        {
            var counter = 0;
            var sum = 0;
            tabLenght -= 1;
            if(tabLenght >= 0)
            {
                if (tab[tabLenght] == element)
                    counter++;
                sum = counter + Zadanie2(tab, tabLenght, element);
            }
            return sum;
        }
        static void Zadanie3(int start, int counter)
        {
            int edge = 100;
            counter++;
            start += 1;
            if(edge >= start)
            {
                if (counter == 3 && start.ToString().EndsWith("0") || start.ToString().EndsWith("5"))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (start.ToString().EndsWith("0") || start.ToString().EndsWith("5"))
                {
                    Console.WriteLine("Buzz");
                }
                else if (counter == 3)
                {
                    Console.WriteLine("Fizz");
                    counter = 0;
                }
                else
                    Console.WriteLine(start);
                Zadanie3(start, counter);
            }
            return;
        }
    }
}
