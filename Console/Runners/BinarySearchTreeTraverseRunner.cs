using AlgorithmsAndDataStructures.DataStructures;
using System;
using System.CommandLine;
using System.CommandLine.IO;

namespace Console.Runners
{
    class BinarySearchTreeTraverseRunner
    {
        public static int Run(string[] items, IConsole console)
        {
            if (items == null)
            {
                console.Out.WriteLine($"Error: { nameof(items) } must be specified");
                return 1;
            }

            var binarySearchTree = new BinarySearchTree<string>();

            foreach (string item in items)
            {
                binarySearchTree.Insert(item);
            }

            var nodeDataProcessor = new CustomNodeDataProcessor<string>(console);

            console.Out.Write($"In-order traverse: ");
            binarySearchTree.InOrderTraverse(nodeDataProcessor);

            console.Out.Write($"{ Environment.NewLine }Pre-order traverse: ");
            binarySearchTree.PreOrderTraverse(nodeDataProcessor);

            console.Out.Write($"{ Environment.NewLine }Post-order traverse: ");
            binarySearchTree.PostOrderTraverse(nodeDataProcessor);
            console.Out.WriteLine();

            return 0;
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
