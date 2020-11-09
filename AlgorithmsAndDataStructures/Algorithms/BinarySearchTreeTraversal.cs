using AlgorithmsAndDataStructures.DataStructures;
using System;

namespace AlgorithmsAndDataStructures.Algorithms
{
    class BinarySearchTreeTraversal
    {
        public static void Run(string[] args)
        {
            var defaultForegroundColor = Console.ForegroundColor;

            Console.WriteLine("*******BINARY SEARCH TREE TRAVERSAL*******");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Environment.NewLine}Given a list of numbers, stores them in a binary search tree and prints out the result of traversing the tree using different tree traversal algorithms");

            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}Enter list of numbers. Separate numbers by a space e.g 1 20 3:");

            // Validate input
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: List of integers must be provided");
                Console.ForegroundColor = defaultForegroundColor;
                return;
            }

            var stringArray = input.Split(" ");
            var binarySearchTree = new BinarySearchTree<int>();
            foreach (string s in stringArray)
            {
                if (int.TryParse(s, out int sAsInt))
                {
                    binarySearchTree.Insert(sAsInt);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: {s} is not a valid integer");
                    Console.ForegroundColor = defaultForegroundColor;
                    return;
                }
            }

            // Execute and display result
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Environment.NewLine}Executing...");
            Console.ForegroundColor = ConsoleColor.Green;

            var nodeDataProcessor = new ConsoleNodeDataProcessor<int>();

            Console.Write($"{Environment.NewLine}In-order traversal result: ");
            binarySearchTree.InOrderTraverse(nodeDataProcessor);
            
            Console.Write($"{Environment.NewLine}Pre-order traversal result: ");
            binarySearchTree.PreOrderTraverse(nodeDataProcessor);
           
            Console.Write($"{Environment.NewLine}Post-order traversal result: ");
            binarySearchTree.PostOrderTraverse(nodeDataProcessor);
           
            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}*******END OF BINARY SEARCH TREE TRAVERSAL*******{Environment.NewLine}");
        }

        /// <summary>
        /// Writes data to standard output
        /// </summary>
        class ConsoleNodeDataProcessor<T> : INodeDataProcessor<T>
        {
            public void Process(T data)
            {
                Console.Write($"{data} ");
            }
        }
    }
}
