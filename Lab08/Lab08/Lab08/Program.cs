using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab08;

class Program
{
    static void Main()
    {
        for (int i = 1; i <= 10; i++)
        {
            int N = 1000000 * i;
            var list = new LinkedList<int>();
            var singlyLinkedList = new SinglyLinkedList<int>();
            int[] arr = new int[N];
            for (int j = 0; j < N; j++)
            {
                list.AddLast(j);
                singlyLinkedList.Add(j);
                arr[j] = j;
            }
            Stopwatch sw = Stopwatch.StartNew();
            Array.Sort(arr);
            sw.Stop();
            Console.Write(sw.Elapsed.TotalMilliseconds + " ");
            sw = Stopwatch.StartNew();
            QSort(list.First, list.Last, 0, list.Count - 1);
            sw.Stop();
            Console.Write(sw.Elapsed.TotalMilliseconds + " ");
            sw = Stopwatch.StartNew();
            singlyLinkedList = SinglyLinkedList<int>.QSort(singlyLinkedList);
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }
    }    
    public static void QSort(LinkedListNode<int>? Start, LinkedListNode<int>? End, int low, int high)
    {
        if (Start == null || End == null || Start == End || low == high)
            return;
        int i = low;
        int j = high;
        var CurrStart = Start;
        var CurrEnd = End;
        int x = (Start.Value + End.Value) >> 1;
        do
        {
            while (CurrStart!.Value < x) 
            {
                CurrStart = CurrStart.Next;
                i++;
            }
            while (CurrEnd!.Value > x) 
            {
                CurrEnd = CurrEnd.Previous;
                j--;
            }
            if (i <= j)
            {
                (CurrStart!.Value, CurrEnd!.Value) = (CurrEnd!.Value, CurrStart!.Value);
                CurrStart = CurrStart.Next;
                CurrEnd = CurrEnd.Previous;
                i++; j--;
            }
        } while (i < j);
        if (low < j) QSort(Start, CurrEnd, low, j);
        if (i < high) QSort(CurrStart, End, i, high);
    }
    private static LinkedList<int> Merge(LinkedList<int> Left, LinkedList<int> Right)
    {
        var Result = new LinkedList<int>();
        int i = 0, j = 0;
        var CurrStart = Left.First;
        var CurrEnd = Right.First;
        while (Left.Count > i & Right.Count > j)
        {
            if (CurrStart!.Value.CompareTo(CurrEnd!.Value) < 0)
            {
                Result.AddLast(CurrStart!.Value);
                CurrStart = CurrStart.Next;
                i++;
            }
            else
            {
                Result.AddLast(CurrEnd!.Value);
                CurrEnd = CurrEnd.Next;
                j++;
            }
        }
        while (Left.Count > i)
        {
            Result.AddLast(CurrStart!.Value);
            CurrStart = CurrStart.Next;
            i++;
        }
        while (Right.Count > j)
        {
            Result.AddLast(CurrEnd!.Value);
            CurrEnd = CurrEnd.Next;
            j++;
        }
        return Result;
    }

    public static LinkedList<int> MergeSort(LinkedList<int> Arr)
    {
        if (Arr.Count <= 1) return Arr;
        else
        {
            int middle = Arr.Count / 2;
            var Left = new LinkedList<int>();
            var Right = new LinkedList<int>();
            var CurrentElement = Arr.First;
            for (int i = 0; i < middle; i++)
            {
                Left.AddLast(CurrentElement!.Value);
                CurrentElement = CurrentElement.Next;
            }
            for (int i = middle; i < Arr.Count; i++)
            {
                Right.AddLast(CurrentElement!.Value);
                CurrentElement = CurrentElement.Next;
            }
            Left = MergeSort(Left);
            Right = MergeSort(Right);
            var Result = Merge(Left, Right);
            return Result;
        }
    }
}