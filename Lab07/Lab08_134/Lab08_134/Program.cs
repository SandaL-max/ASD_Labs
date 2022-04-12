using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Lab08_134.Models;

namespace Lab08_134;
class Program
{
    static void Main(string[] args)
    {
        SinglyLinkedList<int> list = new SinglyLinkedList<int>();
        int Length = 10000;
        for (int i = Length; i > 0; i--)
        {
            list.Add(i);
        }
        //1
        //Console.WriteLine(String.Join(", ", list.SampleMaxValues(5)));
        //3
        list = SinglyLinkedList<int>.QSort(list);
        //list.PrintNodes();
        //4
        //list = SinglyLinkedList<int>.MergeSort(list);
        //list.PrintNodes();
    }
    static bool AreRight(in string s)
    {
        Stack<char> stack = new Stack<char>();
        int Len = s.Length;

        for (int i = 0; i < Len; i++)
        {
            char c = s[i];
            switch (c)
            {
                case ('('):
                    stack.Push(')');
                    break;
                case ('['):
                    stack.Push(']');
                    break;
                case ('{'):
                    stack.Push('}');
                    break;
                case ('<'):
                    stack.Push('>');
                    break;
                case (')'):
                case (']'):
                case ('}'):
                case ('>'):
                    if (stack.Count == 0)
                        return false;
                    char t = stack.Pop();
                    if (t != c)
                    {
                        return false;
                    }
                    break;
                default:
                    break;
            }
        }
        return stack.Count == 0;
    }
}