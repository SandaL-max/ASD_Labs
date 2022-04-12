using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08;

public class SinglyLinkedList<T> where T : struct,
      IComparable,
      IComparable<T>,
      IConvertible,
      IEquatable<T>,
      IFormattable
{
    private Node<T>? First;  // ссылка на первый элемент списка
    private Node<T>? Last;   // ссылка на последний элемент списка
    public int Size;        // размер списка
    public void Add(T value)
    {
        Node<T> node = new Node<T>(value);
        if (Last == null) { First = node; Last = node; } // первый
        else { Last.Next = node; Last = node; }  // остальные
        Size++;
    }
    public T Delete(uint position)
    {
        Node<T>? Temp = First;
        if (position == 0 & Size == 1)  // удаление единственного
        {                               // элемента
            First = null;
            Last = null;
            Size--;
            return Temp!.Value;
        }
        if (position == 0 & Size > 1)  // удаление первого элемента
        {
            First = First!.Next;
            Temp!.Next = null;
            Size--;
            return Temp.Value;
        }
        if (position < Size & Size > 0)
        {
            for (int i = 0; i < position - 1; i++)
            {
                Temp = Temp!.Next;
            }
            Node<T>? DelNode = Temp!.Next;
            Temp.Next = DelNode!.Next;
            DelNode.Next = null;
            if (position == Size - 1)
            {
                Last = Temp;
            }
            Size--;
            return DelNode.Value;
        }
        else
        {
            throw new System.IndexOutOfRangeException($"Index {position} is outside the bounds array");
        }
    }
    public T this[uint position]
    {
        get
        {
            if (position < Size)
            {
                Node<T>? Temp = First;
                for (int i = 0; i < position; ++i)
                {
                    Temp = Temp!.Next;
                }
                return Temp!.Value;
            }
            else
            {
                throw new System.IndexOutOfRangeException($"Index {position} is outside the bounds array");
            }
        }
    }
    public void PrintNodes()
    {
        Node<T>? Temp = First;
        Console.Write("Список: ");
        while (Temp != null)
        {
            Console.Write(" " + Temp.Value);
            Temp = Temp.Next;
        }
        Console.WriteLine();
    }
    //Первое задание про выборку
    public T?[] SampleMaxValues(int K)
    {
        T?[] Result = new T?[K];
        if (K >= Math.Log2(this.Size))
        {
            var SortedList = MergeSort(this);
            var CurrentElement = SortedList.First;
            for (int i = 0; i < SortedList.Size - K; i++)
            {
                CurrentElement = CurrentElement!.Next;
            }
            for (int i = 0; i < K; i++)
            {
                Result[i] = CurrentElement!.Value;
                CurrentElement = CurrentElement.Next;
            }
        }
        else
        {
            var Indexes = new HashSet<int>();
            while (Indexes.Count < K)
            {
                T? Max = null;
                var CurrentElement = this.First;
                int MaxInd = 0;
                for (int i = 0; i < this.Size; i++)
                {
                    if ((Max == null || CurrentElement!.Value.CompareTo(Max) > 0) && !Indexes.Contains(i))
                    {
                        Max = CurrentElement!.Value;
                        MaxInd = i;
                    }
                    CurrentElement = CurrentElement!.Next;
                }
                Indexes.Add(MaxInd);
                Result[Indexes.Count - 1] = Max;
            }
        }
        return Result;
    }
    //Третье задание про быструю сортировку
    public static SinglyLinkedList<T> QSort(SinglyLinkedList<T> Arr)
    {
        if (Arr.Size <= 1) return Arr;
        else
        {
            var middle = ((dynamic)Arr.First!.Value + (dynamic)Arr.Last!.Value) / 2;
            var Left = new SinglyLinkedList<T>();
            var Right = new SinglyLinkedList<T>();
            var CurrentElement = Arr.First;
            for (int i = 0; i < Arr.Size; i++)
            {
                if (CurrentElement!.Value.CompareTo(middle) > 0)
                {
                    Left.Add(CurrentElement.Value);
                }
                else
                {
                    Right.Add(CurrentElement.Value);
                }
                CurrentElement = CurrentElement.Next;
            }
            Left = QSort(Left);
            Right = QSort(Right);
            var Result = Merge(Left, Right);
            return Result;
        }
    }
    //Четвертое задание про сортировку слиянием
    private static SinglyLinkedList<T> Merge(SinglyLinkedList<T> Left, SinglyLinkedList<T> Right)
    {
        var Result = new SinglyLinkedList<T>();
        int i = 0, j = 0;
        var CurrLeft = Left.First;
        var CurrRight = Right.First;
        while (Left.Size > i & Right.Size > j)
        {
            if (CurrLeft!.Value.CompareTo(CurrRight!.Value) < 0)
            {
                Result.Add(CurrLeft.Value);
                CurrLeft = CurrLeft.Next;
                i++;
            }
            else
            {
                Result.Add(CurrRight.Value);
                CurrRight = CurrRight.Next;
                j++;
            }
        }
        while (Left.Size > i)
        {
            Result.Add(CurrLeft!.Value);
            CurrLeft = CurrLeft.Next;
            i++;
        }
        while (Right.Size > j)
        {
            Result.Add(CurrRight!.Value);
            CurrRight = CurrRight.Next;
            j++;
        }
        return Result;
    }

    public static SinglyLinkedList<T> MergeSort(SinglyLinkedList<T> Arr)
    {
        if (Arr.Size <= 1) return Arr;
        else
        {
            int middle = Arr.Size / 2;
            var Left = new SinglyLinkedList<T>();
            var Right = new SinglyLinkedList<T>();
            var CurrentElement = Arr.First;
            for (int i = 0; i < middle; i++)
            {
                Left.Add(CurrentElement!.Value);
                CurrentElement = CurrentElement.Next;
            }
            for (int i = middle; i < Arr.Size; i++)
            {
                Right.Add(CurrentElement!.Value);
                CurrentElement = CurrentElement.Next;
            }
            Left = MergeSort(Left);
            Right = MergeSort(Right);
            var Result = Merge(Left, Right);
            return Result;
        }
    }
}
