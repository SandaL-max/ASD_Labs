using System;

namespace Lab14;
class Program
{
    static void Main()
    {
        var g = new Graph<char>();
        g.AddNode('a');
        g.AddNode('b');
        g.AddNode('c');
        g.AddNode('d');
        g.AddNode('e');
        g.AddNode('f');
        g.AddEdge('a', 'b', 14);
        g.AddEdge('a', 'c', 9);
        g.AddEdge('a', 'd', 7);
        g.AddEdge('b', 'c', 2);
        g.AddEdge('b', 'e', 9);
        g.AddEdge('c', 'd', 10);
        g.AddEdge('c', 'f', 11);
        g.AddEdge('d', 'f', 15);
        g.AddEdge('f', 'e', 6);


        g.FindPaths('a');
        foreach (var node in g.LLN)
        {
            Console.WriteLine(node);
        }
    }
}