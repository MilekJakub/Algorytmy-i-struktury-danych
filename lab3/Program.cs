using System;
using System.Collections.Generic;

namespace lab3
{
    public class SinusZadanie
    {
        private const int max = 360;
        static public double[] sinTable = new double [max];
        static SinusZadanie()
        {
            
            //wypełnić sinTable dla degree od 0 do 359
            for (int i = 0; i < max; i++)
            {
                sinTable[i] = Math.Sin(i * Math.PI / 180);
            }
        }
        public static double Sin(int degree)
        {
            //zwróć sinTable od degree, ale dla dowolnych kątów
            if (degree > 0)
                return sinTable[degree % max];
            else
                return -sinTable[degree % max];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(fibbonaci(42));
            Console.WriteLine(SinusZadanie.Sin(0) == 0);
            Console.WriteLine(SinusZadanie.Sin(90) == 1);
            Console.WriteLine(SinusZadanie.Sin(180) == 0);
            Console.WriteLine(SinusZadanie.Sin(-90) == -1);
            Console.WriteLine(SinusZadanie.Sin(-180) == 0);
        }
        static long fib(int n, long[] mem)
        {
            if (n < 2)
                return 1;
            if (mem[n - 1] == -1)
                mem[n - 1] = fib(n - 1, mem);
            if (mem[n - 2] == -1)
                mem[n - 2] = fib(n - 2, mem);
            return mem[n - 1] + mem[n - 2];
        }
        static long fibbonaci(int n)
        {
            long[] mem = new long[n];
            Array.Fill<long>(mem, -1);
            return fib(n, mem);
        }
    }
}
