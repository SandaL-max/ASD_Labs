using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class BinTree<T> where T : IComparable<T>
    {
        private BinNode<T>? Root;
        public BinTree() { }
        public BinTree(T root) { Add(root); }
        public BinTree(T[] items) { foreach (T item in items) Add(item); }
        public void Add(T value) { Add(ref Root, value); }
        public void Add(ref BinNode<T>? node, T value)
        {
            if (node == null) node = new BinNode<T>(value);
            else
            {
                if (node.Value.CompareTo(value) > 0)
                    Add(ref node.LeftChild, value); // node.Value > value              
                else Add(ref node.RightChild, value); // node.Value <= value             
                                                      //if (node.Value.CompareTo(value) < 0) // уник. дерево             
                                                      //  Add(ref node.Right, value); // node.Value < value         
            }
        }
        public bool Contains(T value)
        {
            return Contains(ref Root, value);
        }
        private bool Contains(ref BinNode<T>? node, T value)
        {
            if (node == null) return false;
            if (node.Value.CompareTo(value) == 0) return true;
            if (node.Value.CompareTo(value) > 0) return Contains(ref node.LeftChild, value);
            else return Contains(ref node.RightChild, value);
        }
        public void Remove(T value)
        {
            if (Root is null) return;
            if (Root.Value.CompareTo(value) == 0)
            {
                if (Root.LeftChild is null && Root.RightChild is null)
                { Root = null; return; }
                if (Root.LeftChild is not null && Root.RightChild is null)
                { Root = Root.LeftChild; return; }
                if (Root.LeftChild is null && Root.RightChild is not null)
                { Root = Root.RightChild; return; }
                BinNode<T> item = CutMax(ref Root.LeftChild, ref Root);
                Root.Value = item.Value;
                return;
            }
            if (Root.Value.CompareTo(value) > 0)
                RemoveLeft(ref Root.LeftChild, value, ref Root);
            else RemoveRight(ref Root.RightChild, value, ref Root);
        }
        private BinNode<T> CutMax(ref BinNode<T> node,
ref BinNode<T> parent)  // ищем самую правую вершину     
        {
            BinNode<T> curParent = parent; BinNode<T> curNode = node; bool flag = true; while (curNode.RightChild != null) { curParent = curNode; curNode = curNode.RightChild; flag = false; }
            if (curNode.LeftChild == null) { if (flag) curParent.LeftChild = null; else curParent.RightChild = null; }  // вершина - лист        
            else { if (flag) curParent.LeftChild = curNode.LeftChild; else curParent.RightChild = curNode.LeftChild; }  // есть левое        
            return curNode;
        }
        private void RemoveLeft(ref BinNode<T> node, T value, ref BinNode<T> parent) // удаление значения в левой ветке     
        {
            if (node == null) return; if (node.Value.CompareTo(value) == 0) // узел для удаления         
            {
                if (node.LeftChild == null && node.RightChild == null) { parent.LeftChild = null; return; }  // вершина - лист             
                if (node.LeftChild != null && node.RightChild == null) { parent.LeftChild = node.LeftChild; return; }  // левое             
                if (node.LeftChild == null && node.RightChild != null) { parent.LeftChild = node.RightChild; return; }  // правое              
                BinNode<T> item = CutMax(ref node.LeftChild, ref node); node.Value = item.Value;  // замена только поля данных             
                                                                                             //item.Left = node.Left;  // замена вершины целиком            
                                                                                             //item.Right = node.Right;  // замена вершины целиком             
                                                                                             //parent.Left = item;  // замена вершины целиком            
                return;
            }
            if (node.Value.CompareTo(value) > 0) RemoveLeft(ref node.LeftChild, value, ref node);  // влево
            else RemoveRight(ref node.RightChild, value, ref node);
        }
        private void RemoveRight(ref BinNode<T> node, T value,
            ref BinNode<T> parent)  // Удаление значения в правой ветке
        {
            if (node == null) return;
            if (node.Value.CompareTo(value) == 0)  // узел для удаления
            {
                if (node.LeftChild == null && node.RightChild == null)
                { parent.RightChild = null; return; }  // вершина - лист
                if (node.LeftChild != null && node.RightChild == null)
                { parent.RightChild = node.LeftChild; return; }  // левое
                if (node.LeftChild == null && node.RightChild != null) { parent.RightChild = node.RightChild; return; }  // правое
                BinNode<T> item = CutMax(ref node.LeftChild, ref node); node.Value = item.Value;  // замена только поля данных             //item.Left = node.Left;  // замена вершины целиком             //item.Right = node.Right;  // замена вершины целиком             //parent.Right = item;  // замена вершины целиком
                return;
            }
            if (node.Value.CompareTo(value) > 0) RemoveLeft(ref node.LeftChild, value, ref node);  // влево
            else RemoveRight(ref node.RightChild, value, ref node);
        }
        public void TraversePreorder()  // Обход в прямом порядке
        { TraversePreorder(Root); }
        private void TraversePreorder(BinNode<T> node) { if (node != null) { Console.Write(node.Value + " "); TraversePreorder(node.LeftChild); TraversePreorder(node.RightChild); } }
        public void TraverseInorder()  // Симметричный обход
        { 
            TraverseInorder(Root); 
        }
        private void TraverseInorder(BinNode<T> node) 
        { 
            if (node != null)
            {
                TraverseInorder(node.LeftChild);
                Console.Write(node.Value + " ");
                TraverseInorder(node.RightChild);
            }
        }
        public bool IsMirrored()
        {
            bool isMirrored = true;
            IsMirrored(ref isMirrored, Root!.LeftChild!, Root!.RightChild!);
            return isMirrored;
        }
        private void IsMirrored(ref bool res, BinNode<T> Left, BinNode<T> Right)
        {
            if (Left is null && Right is null) { return; }
            else if(Left is not null && Right is not null)
            {
                res = Left.Value.Equals(Right.Value);
                IsMirrored(ref res, Left.LeftChild!, Right.RightChild!);
                IsMirrored(ref res, Left.RightChild!, Right.LeftChild!);
            }
            else res = false;
        }
        public int GetHeight()
        {
            return GetHeight(Root);
        }
        private int GetHeight(BinNode<T>? node)
        {
            if (node is null) return 0;
            return Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild)) + 1;
        }

        public bool FullTree()
        {
            bool fullTree = true;
            FullTree(Root, ref fullTree);
            return fullTree;
        }
        private void FullTree(BinNode<T>? node, ref bool Full)
        {
            if (node.LeftChild is not null && node.RightChild is not null)
            {
                FullTree(node.LeftChild, ref Full);
                FullTree(node.RightChild, ref Full);
                return;
            }
            else if (node.LeftChild is null && node.RightChild is null) return;
            else Full = false;
        }
        public bool IdealTree()
        {
            bool perfectTree = true;
            IdealTree(Root, ref perfectTree, 0, this.GetHeight());
            return true;
        }
        private void IdealTree(BinNode<T>? node, ref bool res, int count, int height)
        {
            count++;
            if (node.LeftChild is null && node.RightChild is null)
            {
                if (count != height)
                    res = false;
                return;
            }
            else if (node.LeftChild is not null && node.RightChild is not null)
            {
                IdealTree(node.LeftChild, ref res, count, height);
                IdealTree(node.RightChild, ref res, count, height);
                return;
            }
            else res = false;
        }
    }
}
