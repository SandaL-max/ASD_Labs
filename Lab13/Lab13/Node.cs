using System;
namespace Lab13;
public class Node<T>
{
    public T Name;
    public LinkedList<Node<T>> Neighbors = new LinkedList<Node<T>>();
    public Node(T name) { Name = name; }
}