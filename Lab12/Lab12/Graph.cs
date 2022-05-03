using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Graph<T>
    {
        public LinkedList<Node<T>> LLN;
        public Graph() { LLN = new LinkedList<Node<T>>(); }
        public void AddNode(T name, int x, int y)
        {
            foreach (Node<T> n in LLN) if (n.Name.Equals(name)) return;
            var node = new Node<T>(name, x, y);
            LLN.AddLast(node);
        }
        public void AddEdge(T FromName, T ToName)
        {
            foreach(Node<T> a in LLN)
            {
                if (a.Name.Equals(FromName))
                {
                    foreach(Node<T> b in LLN)
                    {
                        if (b.Name.Equals(ToName))
                            a.Neighbors.AddLast(b);
                    }
                    return;
                }
            }
        }
        public void AddEdges(T FromName, T[] ToNames)
        {
            foreach (Node<T> a in LLN)
            {
                if (a.Name.Equals(FromName))
                {
                    foreach(T ToName in ToNames)
                    {
                        foreach (Node<T> b in LLN)
                        {
                            if (b.Name.Equals(ToName))
                                a.Neighbors.AddLast(b);
                        }
                    }
                    return;
                }
            }
        }
        public void MoveNode(T name, int x, int y)
        {
            foreach(Node<T> a in LLN)
            {
                if (a.Name.Equals(name)) { a.X = x; a.Y = y; }
            }
        }
        public void PrintNeighbors(T name)
        {
            foreach (Node<T> a in LLN)
            {
                if (a.Name.Equals(name))
                {
                    foreach(Node<T> m in a.Neighbors)
                    {
                        Console.WriteLine(m.Name + ", ");
                    }
                    return;
                }
            }
        }
        private int GetDistance(Node<T> a, Node<T> b)
        {
            return (int)(Math.Sqrt(Math.Pow(Math.Abs(a.X - b.X), 2) + Math.Pow(Math.Abs(a.Y - b.Y), 2)));
        }
        public void PrintGraph()
        {
            foreach (Node<T> node in LLN)
            {
                Console.Write($"Name: {node.Name}, X: {node.X}, Y: {node.Y}" + " { ");
                foreach (Node<T> neighbor in node.Neighbors)
                {
                    Console.Write($"({neighbor.Name}, {GetDistance(node, neighbor)}), ");
                }
                Console.WriteLine(" };");
            }
        }
        public void PrintMatrix()
        {
            Console.Write("  ");
            var a = LLN.First;
            for (int i = 0; i < LLN.Count; i++)
            {
                Console.Write(a.Value.Name + " ");
                a = a.Next;
            }
            Console.WriteLine();
            a = LLN.First;
            for (int i = 0; i < LLN.Count; i++)
            {
                Console.Write(a.Value.Name + " ");
                var b = LLN.First;
                for (int j = 0; j < LLN.Count; j++)
                {
                    if (i != j && a.Value.Neighbors.Contains(b.Value))
                        Console.Write("1 ");
                    else
                        Console.Write("0 ");
                    b = b.Next;
                }
                a = a.Next;
                Console.WriteLine();
            }
        }
    }
}
