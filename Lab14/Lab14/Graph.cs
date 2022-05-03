namespace Lab14;
// Орграф
class Graph<T>
{
    public LinkedList<Node<T>> LLN;
    public Graph() { LLN = new LinkedList<Node<T>>(); }

    public void AddNode(T name)
    {
        foreach (Node<T> n in LLN) if (n.name.Equals(name)) return;
        var node = new Node<T>(name);
        LLN.AddLast(node);
    }

    public void AddEdge(T FromName, T ToName, int weight)
    {
        foreach (Node<T> a in LLN)
        {
            if (a.name.Equals(FromName))
            {
                foreach (Node<T> b in LLN)
                {
                    if (b.name.Equals(ToName))
                    {
                        a.routes.AddLast(new Route<T>(b, weight));
                        //b.routes.AddLast(new Route<T>(a, weight));
                        break;
                    }
                }
                return;
            }
        }
    }

    public Node<T> FindNode(T name)
    {
        foreach (var node in LLN) // поиск стартовой вершины
            if (node.name.Equals(name))
                return node;
        throw new ArgumentException($"Нет узла с именем '{name}'");
    }

    public void FindPaths(T startNodeName)
    {
        var frontier = new SortedSet<Node<T>>(new NodeComparer<T>());
        var came_from = new HashSet<Node<T>>();
        var first = FindNode(startNodeName);
        first.distance = 0;
        first.path.Add(first.name);
        frontier.Add(first);

        while (frontier.Count > 0)
        {
            var node = frontier.First();
            frontier.Remove(node);
            came_from.Add(node);
            foreach (var route in node.routes)
            {
                if (came_from.Contains(route.node))
                    continue;

                if (route.node.distance > (node.distance + route.weight))
                {
                    route.node.distance = node.distance + route.weight;
                    route.node.path.Clear();
                    route.node.path.AddRange(node.path);
                    route.node.path.Add(route.node.name);
                }
                frontier.Add(route.node);
            }
            came_from.Add(node);
        }
    }
}