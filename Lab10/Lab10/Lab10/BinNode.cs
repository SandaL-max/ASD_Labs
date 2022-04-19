using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class BinNode<T>
    {
        public BinNode<T>? LeftChild;
        public BinNode<T>? RightChild;
        public T Value;
        public BinNode(T value, BinNode<T>? leftChild = null, BinNode<T>? rightChild = null)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }
    }
}
