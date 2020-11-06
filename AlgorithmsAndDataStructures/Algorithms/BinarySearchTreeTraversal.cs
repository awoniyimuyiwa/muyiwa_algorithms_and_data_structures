using AlgorithmsAndDataStructures.DataStructures;
using System;
using System.Collections.Generic;

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

            var intList = new List<int>();
            var stringArray = input.Split(" ");
            foreach (string s in stringArray)
            {
                if (int.TryParse(s, out int sAsInt))
                {
                    intList.Add(sAsInt);
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

            var binarySearchTree = new BinarySearchTree<int>();
            foreach (int item in intList)
            {
                binarySearchTree.Insert(item);
            }

            var visitor = new ConsoleWriter<int>();

            Console.Write($"{Environment.NewLine}In-order traversal result: ");
            binarySearchTree.InOrderTraverse(visitor);
            
            Console.Write($"{Environment.NewLine}Pre-order traversal result: ");
            binarySearchTree.PreOrderTraverse(visitor);
           
            Console.Write($"{Environment.NewLine}Post-order traversal result: ");
            binarySearchTree.PostOrderTraverse(visitor);
           
            // Terminate
            Console.ForegroundColor = defaultForegroundColor;
            Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}*******END OF BINARY SEARCH TREE TRAVERSAL*******{Environment.NewLine}");
        }

        /// <summary>
        /// Writes items it visits to the standard output stream
        /// </summary>
        class ConsoleWriter<T> : IVisitor<T>
        {
            public void Visit(T t)
            {
                Console.Write($"{t} ");
            }
        }
    }
}
