using System;
namespace Lab14;
public class Node<T>
{
    public T name;
    public int distance = int.MaxValue;
    public List<T> path = new List<T>();
    public LinkedList<Route<T>> routes = new LinkedList<Route<T>>();
    public Node(T name) { this.name = name; }

    public override string ToString()
    {
        var result = string.Empty;
        result += name + " ";
        result += "[" + string.Join(" -> ", path) + "]" + " (";
        result += distance + ")";
        return result;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        var other = obj as Node<T>;
        if (other is null)
            return false;

        return other.name.Equals(name);
    }
}
public class NodeComparer<T> : IComparer<Node<T>>
{
    public int Compare(Node<T>? x, Node<T>? y)
    {
        return x.distance - y.distance;
    }
}
public class Route<T>
{
    public Route(Node<T> node, int weight)
    {
        this.node = node;
        this.weight = weight;
    }

    public Node<T> node;
    public int weight;
}