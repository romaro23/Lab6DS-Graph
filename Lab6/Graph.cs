using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Graph
    {
        private readonly int _vertices;
        private readonly List<int>[] _adjacencyList;
        private readonly int[,] _adjacencyMatrix;

        public Graph(int vertices)
        {
            _vertices = vertices;
            _adjacencyList = new List<int>[vertices];
            _adjacencyMatrix = new int[vertices, vertices];

            for (int i = 0; i < vertices; i++)
                _adjacencyList[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            _adjacencyList[v].Add(w);
            _adjacencyList[w].Add(v);

            _adjacencyMatrix[v, w] = 1;
            _adjacencyMatrix[w, v] = 1;
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Adjacency Matrix:");
            for (int i = 0; i < _vertices; i++)
            {
                for (int j = 0; j < _vertices; j++)
                    Console.Write(_adjacencyMatrix[i, j] + " ");
                Console.WriteLine();
            }
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Adjacency List:");
            for (int i = 0; i < _vertices; i++)
            {
                Console.Write(i + ": ");
                foreach (var vertex in _adjacencyList[i])
                    Console.Write(vertex + " ");
                Console.WriteLine();
            }
        }

        public bool BFSFind(int startVertex, int targetVertex)
        {
            bool[] visited = new bool[_vertices];
            Queue<int> queue = new Queue<int>();

            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");
                if (vertex == targetVertex)
                {
                    return true;
                }

                foreach (var neighbor in _adjacencyList[vertex])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return false;
        }


        public bool DFSFind(int startVertex, int targetVertex)
        {
            bool[] visited = new bool[_vertices];
            return DFSFindUtil(startVertex, targetVertex, visited);
        }

        private bool DFSFindUtil(int vertex, int targetVertex, bool[] visited)
        {
            visited[vertex] = true;
            Console.Write(vertex + " ");
            if (vertex == targetVertex)
            {
                return true;
            }

            foreach (var neighbor in _adjacencyList[vertex])
            {
                if (!visited[neighbor])
                {
                    if (DFSFindUtil(neighbor, targetVertex, visited))
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        public void PrimMST()
        {
            int[] parent = new int[_vertices];
            int[] key = new int[_vertices];
            bool[] mstSet = new bool[_vertices];

            for (int i = 0; i < _vertices; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < _vertices - 1; count++)
            {
                int u = MinKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < _vertices; v++)
                {
                    if (_adjacencyMatrix[u, v] != 0 && !mstSet[v] && _adjacencyMatrix[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = _adjacencyMatrix[u, v];
                    }
                }
            }

            PrintMST(parent);
        }

        private int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, minIndex = -1;

            for (int v = 0; v < _vertices; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private void PrintMST(int[] parent)
        {
            Console.WriteLine("Minimum Spanning Tree (using Prim's algorithm):");
            for (int i = 1; i < _vertices; i++)
                Console.WriteLine($"{parent[i]} - {i}");
        }
    }
}
