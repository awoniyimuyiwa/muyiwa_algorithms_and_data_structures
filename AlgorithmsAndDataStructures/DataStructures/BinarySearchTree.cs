using System;

namespace AlgorithmsAndDataStructures.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable
    {
        Node<T> Root;

        public BinarySearchTree() 
        {
            Root = null;
        }

        public void Insert(T data)
        {
            if (Root == null) { Root = new Node<T>(data); }
            else { Insert(Root, data); }
        }

        public bool Search(T data)
        {
            if (Root == null) { return false; }
            else
            {
                return Search(data, Root);
            }
        }

        public void InOrderTraverse(IVisitor<T> visitor) => InOrderTraverse(Root, visitor);

        public void PreOrderTraverse(IVisitor<T> visitor) => PreOrderTraverse(Root, visitor);

        public void PostOrderTraverse(IVisitor<T> visitor) => PostOrderTraverse(Root, visitor);

        void Insert(Node<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left == null) { node.Left = new Node<T>(data); }
                else { Insert(node.Left, data); }
            }
            else
            {
                if (node.Right == null) { node.Right = new Node<T>(data); }
                else { Insert(node.Right, data); }
            }
        }

        bool Search(T data, Node<T> node)
        {
            if (node == null) { return false; }

            var comaparisonResult = data.CompareTo(node.Data);

            if (comaparisonResult == 0) { return true; }
            else if (comaparisonResult < 0)
            {
                return Search(data, node.Left);
            }
            else
            {
                return Search(data, node.Right);
            }
        }

        void InOrderTraverse(Node<T> node, IVisitor<T> visitor)
        {
            if (node == null) { return; }

            InOrderTraverse(node.Left, visitor);
            node.Accept(visitor);
            InOrderTraverse(node.Right, visitor);
        }

        void PreOrderTraverse(Node<T> node, IVisitor<T> visitor)
        {
            if (node == null) { return; }

            node.Accept(visitor);
            PreOrderTraverse(node.Left, visitor);
            PreOrderTraverse(node.Right, visitor);
        }

        void PostOrderTraverse(Node<T> node, IVisitor<T> visitor)
        {
            if (node == null) { return; }

            PostOrderTraverse(node.Left, visitor);
            PostOrderTraverse(node.Right, visitor);
            node.Accept(visitor);
        }
    }

    public class Node<T>
    {
        public T Data { get; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        public void Accept(IVisitor<T> visitor)
        {
            visitor.Visit(Data);
        }
    }

    public interface IVisitor<T>
    {
        void Visit(T t);
    }
}