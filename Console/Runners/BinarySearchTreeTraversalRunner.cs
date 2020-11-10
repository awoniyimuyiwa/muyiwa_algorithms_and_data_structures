using AlgorithmsAndDataStructures.DataStructures;
using System;
using System.CommandLine;

namespace Console.Runners
{
    class BinarySearchTreeTraversalRunner
    {
        public static void Run(string[] items, IConsole console)
        {
            var binarySearchTree = new BinarySearchTree<string>();

            foreach (string item in items)
            {
                binarySearchTree.Insert(item);
            }

            var nodeDataProcessor = new CustomNodeDataProcessor<string>(console);

            console.Out.Write($"{Environment.NewLine}In-order traversal: ");
            binarySearchTree.InOrderTraverse(nodeDataProcessor);

            console.Out.Write($"{Environment.NewLine}Pre-order traversal: ");
            binarySearchTree.PreOrderTraverse(nodeDataProcessor);

            console.Out.Write($"{Environment.NewLine}Post-order traversal: ");
            binarySearchTree.PostOrderTraverse(nodeDataProcessor);
        }
    }

    /// <summary>
    /// Outputs node data using an IConsole
    /// </summary>
    class CustomNodeDataProcessor<T> : INodeDataProcessor<T>
    {
        readonly IConsole Console;
        public CustomNodeDataProcessor(IConsole console)
        {
            Console = console;
        }

        public void Process(T data)
        {
            Console.Out.Write($"{data} ");
        }
    }
}
