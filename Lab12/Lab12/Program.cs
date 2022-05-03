using System;

namespace Lab12;
class Program
{
    static void Main()
    {
        var graph = GenerateGraph(5, 6);
        graph.PrintMatrix();
    }
    public static Graph<char> GenerateGraph(int NumVertices, int NumEdges)
    {
        if (NumVertices > NumEdges + 1)
            throw new ArgumentException("Слишком мало ребер для построения графа");

        if ((NumVertices * (NumEdges - 1) >> 1) < NumEdges)
            throw new ArgumentException("Слишком много ребер для построения графа");
        var graph = new Graph<char>();
        for (int i = 0; i < NumVertices; i++)
        {
            graph.AddNode((char)(i + 65), 0, 0);
        }
        int CurrNumEdges = 0;
        var a = graph.LLN.First;
        var b = a.Next;
        for (int i = 0; i < NumVertices - 1; i++)
        {
            a.Value.Neighbors.AddLast(b!.Value);
            b.Value.Neighbors.AddLast(a.Value);
            CurrNumEdges++;
            a = a!.Next;
            b = a!.Next;
        }
        a = graph.LLN.First;
        b = a.Next;
        for (int j = 1; j < (NumVertices >> 1); j++)
            b = b.Next;
        for (int i = 0; i < NumVertices >> 1; i++)
        {
            if (CurrNumEdges < NumEdges)
            {
                a.Value.Neighbors.AddLast(b.Value);
                b.Value.Neighbors.AddLast(a.Value);
                CurrNumEdges++;
            }
            else break;
            a = a.Next;
            b = b.Next;
        }
        return graph;
    }
}