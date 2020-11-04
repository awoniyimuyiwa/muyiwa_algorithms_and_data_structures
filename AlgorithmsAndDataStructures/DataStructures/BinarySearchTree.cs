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

        void Insert(Node<T> node, T data)
        {
            if (data.CompareTo(node.Data) < 0) 
            {
                if (node.Left != null) { Insert(node.Left, data); }
                else
                {
                    node.Left = new Node<T>
                    {
                        Data = data,
                        Left = null,
                        Right = null
                    };
                }
            }
            else 
            {
                if (node.Right != null) { Insert(node.Right, data); }
                else
                {
                    node.Right = new Node<T>
                    {
                        Data = data,
                        Left = null,
                        Right = null
                    };
                }
            }
        }

        public void Insert(T data)
        {
            if (Root != null) { Insert(Root, data); }
            else
            {
                Root = new Node<T>
                {
                    Data = data,
                    Left = null,
                    Right = null
                };
            }
        }

        public bool Search(T data)
        {
            if (Root == null) { return false; }
            else
            {
                return Search(data, Root);
            }
        }

        public void InOrder()
        {
            InOrder(Root);
        }

        public void PreOrder()
        {
            PreOrder(Root);
        }

        public void PostOrder()
        {
            PostOrder(Root);
        }

        bool Search(T data, Node<T> node)
        {
            if (node == null) { return false; }
            if (data.CompareTo(node.Data) == 0) { return true; }

            if (data.CompareTo(node.Data) < 0)
            {
                return Search(data, node.Left);
            }
            else
            {
                return Search(data, node.Right);
            }
        }

        void InOrder(Node<T> node)
        {
            if (node == null) { return; }

            InOrder(node.Left);
            Console.WriteLine(node.Data.ToString());
            InOrder(node.Right);
        }

        void PreOrder(Node<T> node)
        {
            if (node == null) { return; }

            Console.WriteLine(node.Data.ToString());
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        void PostOrder(Node<T> node)
        {
            if (node == null) { return; }

            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.WriteLine(node.Data.ToString());
        }
    }

    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }
}