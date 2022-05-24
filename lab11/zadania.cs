using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_11
{

    interface IGraph{
        bool AddEdge(int start, int end, int weight = 1);
        bool AddDirectedEdge(int s, int e, int w = 1);
        bool RemoveEdge(int s, int e);
        bool RemoveDirectedEdge(int s, int e);
    }

    class AdGraph:IGraph
    {
        int[,] _matrix;

        public AdGraph(int n)
        {
            _matrix = new int[n, n];
        }

        public bool AddDirectedEdge(int start, int end, int weight = 1)
        {
            //kod testujący poprawność start i end
            //zwróć false jeśli start lub end są poza zakresem indeksów _matrix
            _matrix[start, end] = weight;
            return true;
        }

        public bool AddEdge(int start, int end, int weight = 1)
        {
            return 
                AddDirectedEdge(start, end, weight) 
                && 
                AddDirectedEdge(end, start, weight);

        }

        public bool RemoveDirectedEdge(int start, int end)
        {
            //kod testujący poprawność start i end
            //zwróć false jeśli start lub end są poza zakresem indeksów _matrix
            //sprawdź czy nie istnieje taka krawędź i zwróc false
            _matrix[start, end] = 0;
            return true;
        }

        public bool RemoveEdge(int start, int end)
        {
            return
                RemoveDirectedEdge(start, end)
                &&
                RemoveDirectedEdge(end, start);
        }

        public override string ToString()
        {
            string r = "";
            for (int row = 0; row < _matrix.GetLength(0); row++)
            {
                for (int col = 0; col < _matrix.GetLength(1); col++)
                {
                    if (_matrix[row, col] != 0)
                    {
                        r += $"edge between {row} and {col}\n";
                    }
                }
            }
            return r;
        }
    }


    class AdListGraph : IGraph
    {
        internal int count;
        private List<List<Edge>> _edges = new List<List<Edge>>();

        public AdListGraph(int count)
        {
            this.count = count;
            for(int i = 0; i < count; i++)
            {
                _edges.Add(new List<Edge>());
            }
        }

        public bool AddDirectedEdge(int start, int end, int weight = 1)
        {
            if (_edges[start] == null)
            {
                _edges[start] = new List<Edge>();
            }
            _edges[start].Add(new Edge() { Desc = end, Weight = weight });
            return true;
        }

        public bool AddEdge(int start, int end, int weight = 1)
        {
            throw new NotImplementedException();
        }

        public bool RemoveDirectedEdge(int start, int end)
        {
            if (_edges[start] == null)
            {
                return false;
            }
            Edge edge = _edges[start].FirstOrDefault(e => e.Desc == end);
            return _edges[start].Remove(edge);
        }

        public bool RemoveEdge(int s, int e)
        {
            throw new NotImplementedException();
        }

        private class Edge: IComparable<Edge>
        {
            public int Desc { get; init; }
            public int Weight { get; init; }

            public int CompareTo(Edge other)
            {
                return Weight.CompareTo(other.Weight);
            }
        }

        public override string ToString()
        {
            string r = "";
            for(int vertex = 0; vertex < _edges.Count; vertex++)
            {
                List<Edge> edges = _edges[vertex];
                foreach(Edge edge in edges)
                {
                    r += $"edge between {vertex} and {edge.Desc}\n";
                }
            }
            return r;
        }
    }
    class App
    {
        static void AppMain(string[] args)
        {
            Console.WriteLine("Adjacency matrix graph");
            IGraph graph = new AdGraph(4);
            graph.AddDirectedEdge(0, 1);
            graph.AddDirectedEdge(1, 2);
            graph.AddDirectedEdge(2, 0);
            graph.AddDirectedEdge(2, 3);
            Console.WriteLine(graph);
            Console.WriteLine("Adjacency list graph");
            graph = new AdListGraph(5);
            graph.AddDirectedEdge(0, 1);
            graph.AddDirectedEdge(1, 2);
            graph.AddDirectedEdge(2, 0);
            graph.AddDirectedEdge(2, 3);
            Console.WriteLine(graph);
        }
    }
}
