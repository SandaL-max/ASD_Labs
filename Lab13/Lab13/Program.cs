using System;

namespace Lab13;
class Program
{
    static void Main()
    {
        var g = new Graph<char>();
        //Task 1
        g.AddNode('a');
        g.AddNode('b');
        g.AddNode('c');
        g.AddNode('d');
        g.AddEdges('a', new char[] { 'b', 'c' });
        g.AddEdge('b', 'c');
        g.AddEdges('c', new char[] { 'b', 'd' });
        g.AddEdge('d', 'b');
        Console.WriteLine("Обход вглубь из вершины 'a':");
        g.DepthFirstTraversal('a');
        //Task 2
        g.AddNode('a');
        g.AddNode('b');
        g.AddNode('c');
        g.AddNode('d');
        g.AddEdge('a', 'b');
        g.AddEdge('a', 'c');
        //g.AddEdge('a', 'd');
        //g.AddEdge('b', 'c');
        Console.WriteLine(g.IsTree());
    }
}