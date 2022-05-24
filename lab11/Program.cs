using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
{
    interface IGraph
    {
        bool AddDirectedEdge(int source, int target, int weight);
        bool AddUndirectedEdge(int source, int target, int weight);
    }

    class AdMatrix : IGraph
    {
        private int[,] _matrix;

        public AdMatrix(int size)
        {
            _matrix = new int[size, size];
        }

        public bool AddDirectedEdge(int source, int target, int weight)
        {
            _matrix[source, target] = weight;
            return true;
        }

        public bool AddUndirectedEdge(int source, int target, int weight)
        {
            return AddDirectedEdge(source, target, weight) && AddDirectedEdge(target, source, weight);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            for (int row = 0; row < _matrix.GetLength(0); row++)
            {
                stringBuilder.Append($"wierzchołek {row} połączony z: ");
                for (int col = 0; col < _matrix.GetLength(1); col++)
                {
                    if(_matrix[row, col] != 0)
                        stringBuilder.Append(col + " ");
                }
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }
    }

    class AdList : IGraph
    {
        Dictionary<int, HashSet<Edge>> _edges = new Dictionary<int, HashSet<Edge>>();

        public bool AddDirectedEdge(int source, int target, int weight)
        {
            if (!_edges.ContainsKey(source))
                _edges.Add(source, new HashSet<Edge>());

            if (!_edges.ContainsKey(target))
                _edges.Add(target, new HashSet<Edge>());

            _edges[source].Add(new Edge() { Node = target, Weight = weight });

            return true;
        }

        public bool AddUndirectedEdge(int source, int target, int weight)
        {
            return AddDirectedEdge(source, target, weight) && AddDirectedEdge(target, source, weight);
        }

        public void LevelTraversal(int source)
        {

        }
    }

    record Edge
    {
        public int Node { get; set; }
        public double Weight { get; set; }
    }

    class Program
    {
        static void Main()
        {
            IGraph graph = new AdMatrix(4);
            graph.AddDirectedEdge(0, 1, 1);
            graph.AddDirectedEdge(1, 3, 1);
            graph.AddDirectedEdge(3, 0, 1);
            graph.AddDirectedEdge(0, 2, 1);
            graph.AddDirectedEdge(3, 2, 1);

            Console.WriteLine(graph);
        }
    }
}
