namespace Lab13;
class Graph<T>
{
    public LinkedList<Node<T>> LLN;
    public Graph() { LLN = new LinkedList<Node<T>>(); }

    public void AddNode(T name) // добавление уникальной вершины
    {
        foreach (Node<T> n in LLN) if (n.Name.Equals(name)) return;
        var node = new Node<T>(name);
        LLN.AddLast(node);
    }

    public void AddEdge(T FromName, T ToName)
    {
        foreach (Node<T> a in LLN)
        {
            if (a.Name.Equals(FromName))
            {
                foreach (Node<T> b in LLN)
                {
                    if (b.Name.Equals(ToName))
                    {
                        a.Neighbors.AddLast(b);
                        break;
                    }
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
                foreach (T ToName in ToNames)
                {
                    foreach (Node<T> b in LLN)
                    {
                        if (b.Name.Equals(ToName))
                        {
                            a.Neighbors.AddLast(b);
                            break;
                        }
                    }
                }
                return;
            }
        }
    }

    public void PrintNeighbors(T name)
    {
        foreach (Node<T> a in LLN)
        {
            if (a.Name.Equals(name))
            {
                foreach (Node<T> m in a.Neighbors)
                    Console.Write(m.Name + ", ");
                return;
            }
        }
    }

    public void DepthFirstTraversal(T name) // обход в глубину
    {
        var travers = new List<T> { name }; // список табу
        foreach (Node<T> node in LLN) // поиск стартовой вершины
        {
            if (node.Name.Equals(name))
            {
                DepthFirstTraversal(node, travers);
                break;
            }
        }
    }
    public void DepthFirstTraversal(Node<T> node, List<T> travers)
    {
        var isDeadlock = true;
        foreach (Node<T> Neighbor in node.Neighbors) // все соседи
        {
            if (!travers.Contains(Neighbor.Name)) // не табу
            {
                isDeadlock = false;
                travers.Add(Neighbor.Name);
                DepthFirstTraversal(Neighbor, travers);
                travers.Remove(Neighbor.Name);
            }
        }

        if(isDeadlock)
            Console.WriteLine("[" + string.Join(" -> ", travers) + "]");
    }

    public bool IsTree()
    {
        var travers = new List<T>() { LLN.First.Value.Name };
        return IsTree(LLN.First.Value, travers, null) && travers.Count == LLN.Count;
    }

    private bool IsTree(Node<T> node, List<T> travers, Node<T> parent)
    {
        var isTree = true;
        foreach (Node<T> neighbor in node.Neighbors)
        {
            if (travers.Contains(neighbor.Name))
                return false;
            else if (neighbor == parent)
                continue;
            travers.Add(neighbor.Name);
            isTree &= IsTree(neighbor, travers, node);
        }
        return isTree;
    }

    public void BreadthFirstTraversal(T name) // обход в ширину
    {
        var internals = new List<Node<T>>(); // список табу
        var externals = new List<Node<T>>(); // список фронта
        foreach (Node<T> node in LLN) // поиск стартовой вершины
        {
            if (node.Name.Equals(name))
            {
                Console.WriteLine(node.Name);
                externals.Add(node);
                BreadthFirstTraversal(internals, externals);
                break;
            }
        }
    }

    public void BreadthFirstTraversal(List<Node<T>> internals, List<Node<T>> externals)
    {
        if (externals.Count == 0) return;
        internals.AddRange(externals); // фронт в список табу
        var newexternals = new List<Node<T>>(); // новый фронт
        foreach (Node<T> node in externals)
        {
            foreach (Node<T> Neighbor in node.Neighbors)
            {
                if (!internals.Contains(Neighbor)) // не табу
                {
                    Console.Write(Neighbor.Name + " ");
                    newexternals.Add(Neighbor); // в список фронта
                }
            }
        }
        Console.WriteLine();
        BreadthFirstTraversal(internals, newexternals);
    }
}