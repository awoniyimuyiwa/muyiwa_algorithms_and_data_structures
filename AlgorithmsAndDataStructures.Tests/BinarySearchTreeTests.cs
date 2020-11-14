using AlgorithmsAndDataStructures.DataStructures;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class BinarySearchTreeTests
    {
        [Theory]
        [MemberData(nameof(GetDataForTestingContains))]
        public void Contains_WhenCalled_ExecutesCorrectly(string[] items, string item, bool expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);

            var actual = binarySearchTree.Contains(item);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingDelete))]
        public void Delete_WhenCalled_ExecutesCorrectly(string[] items, string item, string[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<string>();

            binarySearchTree.Delete(item);

            binarySearchTree.InOrderTraverse(visitor);
            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<string> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingInOrderTraverse))]
        public void InOrderTraverse_WhenCalled_ExecutesCorrectly(string[] items, string[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<string>();
 
            binarySearchTree.InOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<string> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingPreOrderTraverse))]
        public void PreOrderTraverse_WhenCalled_ExecutesCorrectly(string[] items, string[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<string>();
 
            binarySearchTree.PreOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<string> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingPostOrderTraverse))]
        public void PostOrderTraverse_WhenCalled_ExecutesCorrectly(string[] items, string[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<string>();
 
            binarySearchTree.PostOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<string> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        public static TheoryData<string[], string, bool> GetDataForTestingContains()
        {
            return new TheoryData<string[], string, bool>()
            {
                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    "mango",
                    true
                },

                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    "non-existing",
                    false
                },
            };
        }
       
        public static TheoryData<string[], string, string[]> GetDataForTestingDelete()
        {
            return new TheoryData<string[], string, string[]>()
            {
                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    "mango",
                    new string[] { "orange", "pear", "pineapple" }
                },

                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    "pineapple",
                    new string[] { "mango", "orange", "pear" }
                },

                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    "non-existing",
                    new string[] { "mango", "orange", "pear", "pineapple" }
                },
            };
        }

        public static TheoryData<string[], string[]> GetDataForTestingInOrderTraverse()
        {
            return new TheoryData<string[], string[]>()
            {
                // In-order traverse on a binary search tree can be used to sort data stored in the tree in ascending order  
                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    new string[] { "mango", "orange", "pear", "pineapple" }
                },

                {
                   new string[] { "mango", "orange", "pear", "pineapple" },
                   new string[] { "mango", "orange", "pear", "pineapple" }
                },

                {
                   new string[] { "pineapple", "pear", "orange", "mango" },
                   new string[] { "mango", "orange", "pear", "pineapple" }
                },
            };
        }

        public static TheoryData<string[], string[]> GetDataForTestingPreOrderTraverse()
        {
            return new TheoryData<string[], string[]>()
            {
                // Pre-order traverse on a binary search tree can be used to get data stored in the tree in the same order they were stored                
                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    new string[] { "pineapple", "mango", "orange", "pear" }
                },

                {
                   new string[] { "mango", "orange", "pear", "pineapple" },
                   new string[] { "mango", "orange", "pear", "pineapple" }
                },

                {
                   new string[] { "pineapple", "pear", "orange", "mango" },
                   new string[] { "pineapple", "pear", "orange", "mango" }
                },
            };
        }

        public static TheoryData<string[], string[]> GetDataForTestingPostOrderTraverse()
        {
            return new TheoryData<string[], string[]>()
            {                
                {
                    new string[] { "pineapple", "mango", "orange", "pear" },
                    new string[] { "pear", "orange", "mango", "pineapple" }
                },

                // Though sorted data should not be stored in a binary search tree, post-order traverse on a binary search tree can be used to reverse the initial order of sorted data stored in the tree               
                {
                   new string[] { "mango", "orange", "pear", "pineapple" },
                   new string[] { "pineapple", "pear", "orange", "mango" }
                },

                {
                   new string[] { "pineapple", "pear", "orange", "mango" },
                   new string[] { "mango", "orange", "pear", "pineapple" }
                },
            };
        }

        private BinarySearchTree<T> GetBinarySearchTree<T>(T[] items) where T : IComparable 
        {
            var binarySearchTree = new BinarySearchTree<T>();
            foreach (var item in items)
            {
                binarySearchTree.Insert(item);
            }

            return binarySearchTree;
        }        
    }

    class CustomNodeDataProcessor<T> : INodeDataProcessor<T> 
    {
        readonly List<T> Items;
        public IReadOnlyCollection<T> ReadOnlyItems => Items;

        public CustomNodeDataProcessor() 
        {
            Items = new List<T>();
        }

        public void Process(T t)
        {
            Items.Add(t);
        }
    }
}
