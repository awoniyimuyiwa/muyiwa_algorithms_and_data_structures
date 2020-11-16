using System;

namespace AlgorithmsAndDataStructures.DataStructures
{
    /// <summary>
    /// A node-based data structure that stores data in nodes that also have a left and right node. 
    /// It is a variant of a binary tree data structure whose nodes also have reference to at most two other nodes. 
    /// While a binary tree data structure doesn't enforce an order in which data is stored in nodes,
    /// this data structure enforces that the value of data in the left node of a given node is less than the value of data in the node
    /// and the value of data in the right node of a given node is equal to or greater than the value of data in the node
    /// </summary>
    /// <typeparam name="T">Type of data stored in nodes of the tree</typeparam>
    public class BinarySearchTree<T> where T : IComparable
    {
        class Node
        {
            public T Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(T data)
            {
                Data = data;
            }

            public void ProcessData(INodeDataProcessor<T> processor)
            {
                processor.Process(Data);
            }
        }

        Node Root;

        public BinarySearchTree() 
        {
            Root = null;
        }

        /// <summary>
        /// Stores <paramref name="data"/> in a node of the tree
        /// </summary>
        /// <param name="data">Data to store</param>
        /// <remarks>
        /// Where n is the number of nodes in the tree
        /// BEST CASE- TIME: Ω(log(n)), MEMORY: Ω(n) when the original collection of data used for creating the tree is unsorted  
        /// AVERAGE CASE- TIME: Θ(log(n)), MEMORY: Θ(n) when the original collection of data used for creating the tree is unsorted
        /// WORST CASE- TIME: O(n), MEMORY: O(n) when the original collection of data used for creating the tree is sorted
        /// 
        /// The time complexity is log(n) base 2 in the best and average cases because the number of nodes to traverse to arrive at the node where data should be inserted gets split by half on each iteration.
        /// The time complexity is O(n) in the worst case because the maximum number of nodes to traverse is equal to the number of nodes in the tree.
        /// </remarks>
        public void Insert(T data)
        {
            if (Root == null) { Root = new Node(data); }
            else { Insert(Root, data); }
        }

        /// <summary>
        /// Checks if <paramref name="data"/> is stored in any of the nodes of the tree
        /// </summary>
        /// <param name="data">Data to search for</param>
        /// <returns>True if <paramref name="data"/> is stored in any of the nodes of the tree, false otherwise</returns>
        /// <remarks>
        /// Where n is the number of nodes in the tree.
        /// BEST CASE- TIME: Ω(log(n)), MEMORY: Ω(n) when the original collection of data used for creating the tree is unsorted  
        /// AVERAGE CASE- TIME: Θ(log(n)), MEMORY: Θ(n) when the original collection of data used for creating the tree is unsorted
        /// WORST CASE- TIME: O(n), MEMORY: O(n) when the original collection of data used for creating the tree is sorted       
        ///
        /// The time complexity is log(n) base 2 in the best and average cases because the number of nodes to traverse to arrive at the node that contains data gets split by half on each iteration
        /// The time complexity is O(n) in the worst case because the maximum number of nodes to traverse is equal to the number of nodes in the tree
        /// </remarks>
        public bool Contains(T data)
        {
            if (Root == null) { return false; }
            return Contains(data, Root);
        }

        /// <summary>
        /// Deletes a node that holds <paramref name="data"/> from the tree
        /// </summary>
        /// <param name="data">Data to delete</param>       
        /// <remarks>
        /// Where n is the number of nodes in the tree.
        /// BEST CASE- TIME: Ω(log(n)), MEMORY: Ω(n) when the original collection of data used for creating the tree is unsorted  
        /// AVERAGE CASE- TIME: Θ(log(n)), MEMORY: Θ(n) when the original collection of data used for creating the tree is unsorted
        /// WORST CASE- TIME: O(n), MEMORY: O(n) when the original collection of data used for creating the tree is sorted       
        ///
        /// The time complexity is log(n) base 2 in the best and average cases because the number of nodes to traverse to arrive at the node that contains data gets split by half on each iteration
        /// The time complexity is O(n) in the worst case because the maximum number of nodes to traverse is equal to the number of nodes in the tree
        /// </remarks>
        public void Delete(T data)
        {
            if (Root == null) { return; }
            Root = Delete(data, Root);
        }

        /// <summary>
        /// Nodes are traversed in the order: Left, Node, Right (LNR)
        /// Can be used for sorting data stored in nodes in ascending order
        /// </summary>
        /// <param name="processor">For processing data stored in nodes encountered during traversal</param>
        /// <remarks>
        /// Where n is the number of nodes in the tree.
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)       
        /// </remarks>
        public void InOrderTraverse(INodeDataProcessor<T> processor) => InOrderTraverse(Root, processor);

        /// <summary>
        /// Nodes are traversed in the order: Node, Left, Right (NLR)
        /// Can be used to clone the tree or get data stored in nodes in the same order they were stored
        /// </summary>
        /// <param name="processor">For processing data stored in nodes encountered during traversal</param>
        /// <remarks>
        /// Where n is the number of nodes in the tree.
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)       
        /// </remarks>
        public void PreOrderTraverse(INodeDataProcessor<T> processor) => PreOrderTraverse(Root, processor);

        /// <summary>
        /// Nodes are traversed in the order: Left, Right, Node (LRN)
        /// </summary>
        /// <param name="processor">For processing data stored in nodes encountered during traversal</param>       
        /// <remarks>
        /// Where n is the number of nodes in the tree.
        /// BEST CASE- TIME: Ω(n), MEMORY: Ω(n)
        /// AVERAGE CASE- TIME: Θ(n), MEMORY: Θ(n)
        /// WORST CASE- TIME: O(n), MEMORY: O(n)       
        /// </remarks>
        public void PostOrderTraverse(INodeDataProcessor<T> processor) => PostOrderTraverse(Root, processor);

        void Insert(Node node, T data)
        {
            if (data.CompareTo(node.Data) < 0)
            {
                if (node.Left == null) { node.Left = new Node(data); }
                else { Insert(node.Left, data); }
            }
            else
            {
                if (node.Right == null) { node.Right = new Node(data); }
                else { Insert(node.Right, data); }
            }
        }

        bool Contains(T data, Node node)
        {
            if (node == null) { return false; }

            var comparisonResult = data.CompareTo(node.Data);

            if (comparisonResult == 0) { return true; }
            else if (comparisonResult < 0)
            {
                return Contains(data, node.Left);
            }
            else
            {
                return Contains(data, node.Right);
            }
        }

        Node Delete(T data, Node node)
        {
            if (node == null) { return null; }

            var comparisonResult = data.CompareTo(node.Data);

            if (comparisonResult < 0)
            {
                node.Left = Delete(data, node.Left);
            }
            else if (comparisonResult > 0)
            {
                node.Right = Delete(data, node.Right);
            }
            else
            {
                if (node.Left == null) { return node.Right; }
                if (node.Right == null) { return node.Left; }

                // Both left and right nodes of the node are not null, 
                // Get the in-order successor of the node. 
                // The in-order successor of a given node N is the node with the smallest data value in N's right subtree
                var inOrderSuccessor = node.Right;
                while (inOrderSuccessor.Left != null)
                {
                    inOrderSuccessor = inOrderSuccessor.Left;
                }

                // Copy data from in-order successor
                node.Data = inOrderSuccessor.Data;
                // Delete in-order successor recursively via node.Right
                node.Right = Delete(inOrderSuccessor.Data, node.Right);
            }

            return node;
        }

        void InOrderTraverse(Node node, INodeDataProcessor<T> processor)
        {
            if (node == null) { return; }

            InOrderTraverse(node.Left, processor);
            node.ProcessData(processor);
            InOrderTraverse(node.Right, processor);
        }

        void PreOrderTraverse(Node node, INodeDataProcessor<T> processor)
        {
            if (node == null) { return; }

            node.ProcessData(processor);
            PreOrderTraverse(node.Left, processor);
            PreOrderTraverse(node.Right, processor);
        }

        void PostOrderTraverse(Node node, INodeDataProcessor<T> processor)
        {
            if (node == null) { return; }

            PostOrderTraverse(node.Left, processor);
            PostOrderTraverse(node.Right, processor);
            node.ProcessData(processor);
        }
    }

    /// <summary>
    /// Encapsulates algorithm for processing data stored in nodes of <see cref="BinarySearchTree{T}"/> when traversing using any of its traversal methods
    /// </summary>
    /// <typeparam name="T">Type of data to process</typeparam>
    public interface INodeDataProcessor<T>
    {
        /// <summary>
        /// Processes data stored in a <see cref="BinarySearchTree{T}"/> node
        /// </summary>
        /// <param name="data">Data to process</param>
        void Process(T data);
    }
}