using System;

namespace AlgorithmsAndDataStructures.DataStructures
{
    public interface INodeData 
    {
        public bool IsLessThan(INodeData other);
        public bool IsEqual(INodeData other);
        public string Serialize();
    }

    public class Node<T> where T : INodeData
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; } 
        public Node<T> Right { get; set; }
    }

    public class BinarySearchTree<T> where T : INodeData
    {
        Node<T> Root;

        public BinarySearchTree() 
        {
            Root = null;
        }

        void Insert(Node<T> node, T data)
        {
            if (data.IsLessThan(node.Data)) 
            {
                if (node.Left != null) { Insert(node.Left, data); }
                else
                {
                    node.Left = new Node<T>();
                    node.Left.Data = data;
                    node.Left.Left = null;
                    node.Left.Right = null;
                }
            }
            else 
            {
                if (node.Right != null) { Insert(node.Right, data); }
                else
                {
                    node.Right = new Node<T>();
                    node.Right.Data = data;
                    node.Right.Left = null;
                    node.Right.Right = null;
                }
            }
        }

        public void Insert(T data)
        {
            if (Root != null) { Insert(Root, data); }
            else
            {
                Root = new Node<T>();
                Root.Data = data;
                Root.Left = null;
                Root.Right = null;
            }
        }

        bool Search(T data, Node<T> node)
        {
            if (node == null) { return false; }
            if (data.IsEqual(node.Data)) { return true; }
            
            if (data.IsLessThan(node.Data)) 
            {
                return Search(data, node.Left);
            } 
            else 
            {
                return Search(data, node.Right);
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

        void InOrder(Node<T> node)
        {
            if (node == null) { return; }

            InOrder(node.Left);
            Console.WriteLine(node.Data.Serialize());
            InOrder(node.Right);
        }

        public void InOrder()
        {
            InOrder(Root);
        }

        void PreOrder(Node<T> node)
        {
            if (node == null) { return; }

            Console.WriteLine(node.Data.Serialize());
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void PreOrder()
        {
            PreOrder(Root);
        }

        void PostOrder(Node<T> node)
        {
            if (node == null) { return; }

            PostOrder(node.Left);
            PostOrder(node.Right);
            Console.WriteLine(node.Data.Serialize());
        }

        public void PostOrder()
        {
            PostOrder(Root);
        }
    }
}