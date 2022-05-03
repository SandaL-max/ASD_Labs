using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Node<T>
    {
        public T Name;
        public int X;
        public int Y;
        public LinkedList<Node<T>> Neighbors = new LinkedList<Node<T>>();
        public Node(T name, int x, int y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
