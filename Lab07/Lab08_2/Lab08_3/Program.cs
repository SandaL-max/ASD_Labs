using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab08_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();

            Console.WriteLine(AreRight(s) ? "Yes" : "No");
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
                }
            }
            return stack.Count == 0;
        }
    }
}