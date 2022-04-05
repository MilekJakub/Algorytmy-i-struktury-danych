using System;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue priorityQueue = new PriorityQueue();

            priorityQueue.Insert(4);
            priorityQueue.Insert(7);
            priorityQueue.Insert(9);
            priorityQueue.Insert(1);

            foreach (var item in priorityQueue._arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
