using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08;
public class Node<T> where T : struct,
      IComparable,
      IComparable<T>,
      IConvertible,
      IEquatable<T>,
      IFormattable
{
    public T Value;
    public Node<T>? Next;
    public Node(T value, Node<T>? next = null)
    {
        Value = value;
        Next = next;
    }
}
