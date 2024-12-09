using Lab6;
using System;
Console.WriteLine("Print number of vertices: ");
int v = int.Parse(Console.ReadLine());
Graph graph = new Graph(v);
int first, second;
for (int i = 0; i < v - 1; i++)
{
    Console.WriteLine("Print first vertix: ");
    first = int.Parse(Console.ReadLine());
    Console.WriteLine("Print second vertix: ");
    second = int.Parse(Console.ReadLine());
    graph.AddEdge(first, second);
}
while (true)
{
    Console.WriteLine("1 - Print adjacency matrix, 2 - Print adjacency list, 3 - BFS, 4 - DFS, 5 - Prim MST");
    int option;
    if (int.TryParse(Console.ReadLine(), out option))
    {
        int start, target;
        switch (option)
        {
            case 1:
                graph.PrintAdjacencyMatrix();
                break;
            case 2:
                graph.PrintAdjacencyList();
                break;
            case 3:
                Console.WriteLine("Write start vertix: ");
                start = int.Parse(Console.ReadLine());
                Console.WriteLine("Write vertix to find: ");
                target = int.Parse(Console.ReadLine());
                graph.BFSFind(start, target);
                Console.WriteLine();
                break;
            case 4:
                Console.WriteLine("Write start vertix: ");
                start = int.Parse(Console.ReadLine());
                Console.WriteLine("Write vertix to find: ");
                target = int.Parse(Console.ReadLine());
                graph.DFSFind(start, target);
                Console.WriteLine();
                break;
            case 5:
                graph.PrimMST();
                break;
        }
    }

}
