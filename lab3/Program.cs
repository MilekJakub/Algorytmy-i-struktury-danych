using System;
using System.Collections.Generic;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"fib(50):{fib(50, new Dictionary<int, long>())}");
            Console.WriteLine($"fibonnaci(50):{fibonnaci(50)}");


        }
        static long fib(int n, Dictionary<int, long> memo)
        {
            if(memo.ContainsKey(n))
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
                if(i <= 2)
                    result = 1;

                result = n1 + n2;
                n1 = n2;
                n2 = result;
            }
            return result;
        }
    }
}