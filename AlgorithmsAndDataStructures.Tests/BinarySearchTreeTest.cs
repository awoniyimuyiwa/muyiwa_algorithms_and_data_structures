using AlgorithmsAndDataStructures.DataStructures;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests
{
    public class BinarySearchTreeTest
    {
        [Theory]
        [MemberData(nameof(GetDataForTestingContainsOnIntegers))]
        public void Contains_WhenItemsAreIntegers_ExecutesCorrectly(int[] items, int item, bool expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);

            var actual = binarySearchTree.Contains(item);
           
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingContainsOnStrings))]
        public void Contains_WhenItemsAreStrings_ExecutesCorrectly(string[] items, string item, bool expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);

            var actual = binarySearchTree.Contains(item);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingDeleteOnIntegers))]
        public void Delete_WhenItemsAreIntegers_ExecutesCorrectly(int[] items, int item, int[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<int>();

            binarySearchTree.Delete(item);

            binarySearchTree.InOrderTraverse(visitor);
            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<int> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingDeleteOnStrings))]
        public void Delete_WhenItemsAreStrings_ExecutesCorrectly(string[] items, string item, string[] expected)
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
        [MemberData(nameof(GetDataForTestingInOrderTraverseOnIntegers))]
        public void InOrderTraverse_WhenItemsAreIntegers_ExecutesCorrectly(int[] items, int[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<int>();

            binarySearchTree.InOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<int> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingInOrderTraverseOnStrings))]
        public void InOrderTraverse_WhenItemsAreStrings_ExecutesCorrectly(string[] items, string[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<string>();
 
            binarySearchTree.InOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<string> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingPreOrderTraverseOnIntegers))]
        public void PreOrderTraverse_WhenItemsAreIntegers_ExecutesCorrectly(int[] items, int[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<int>();

            binarySearchTree.PreOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<int> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingPreOrderTraverseOnStrings))]
        public void PreOrderTraverse_WhenItemsAreStrings_ExecutesCorrectly(string[] items, string[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<string>();
 
            binarySearchTree.PreOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<string> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingPostOrderTraverseOnIntegers))]
        public void PostOrderTraverse_WhenItemsAreIntegers_ExecutesCorrectly(int[] items, int[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<int>();

            binarySearchTree.PostOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<int> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        [Theory]
        [MemberData(nameof(GetDataForTestingPostOrderTraverseOnStrings))]
        public void PostOrderTraverse_WhenItemsAreStrings_ExecutesCorrectly(string[] items, string[] expected)
        {
            var binarySearchTree = GetBinarySearchTree(items);
            var visitor = new CustomNodeDataProcessor<string>();
 
            binarySearchTree.PostOrderTraverse(visitor);

            var actual = visitor.ReadOnlyItems;
            IReadOnlyCollection<string> expectedAsReadOnly = Array.AsReadOnly(expected);
            Assert.Equal(expectedAsReadOnly, actual);
        }

        public static TheoryData<int[], int, bool> GetDataForTestingContainsOnIntegers()
        {
            return new TheoryData<int[], int, bool>()
            {
                {
                    new int[] { 6, 4, 2, 7 },
                    4,
                    true
                },

                {
                    new int[] { 6, 4, 2, 7 },
                    0,
                    false
                }
            };
        }

        public static TheoryData<string[], string, bool> GetDataForTestingContainsOnStrings()
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

        public static TheoryData<int[], int, int[]> GetDataForTestingDeleteOnIntegers()
        {
            return new TheoryData<int[], int, int[]>()
            {                
                {
                    new int[] { 6, 4, 2, 9, 7, 12, 15 },
                    7,
                    new int[] { 2, 4, 6, 9, 12, 15 }
                },

                {
                    new int[] { 6, 4, 2, 9, 7, 12, 15 },
                    2,
                    new int[] { 4, 6, 7, 9, 12, 15 }
                },

                {
                    new int[] { 6, 4, 2, 9, 7, 12, 15 },
                    0,
                    new int[] { 2, 4, 6, 7, 9, 12, 15 }
                }
            };
        }

        public static TheoryData<string[], string, string[]> GetDataForTestingDeleteOnStrings()
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

        public static TheoryData<int[], int[]> GetDataForTestingInOrderTraverseOnIntegers()
        {
            return new TheoryData<int[], int[]>()
            {
                // In-order traverse on a binary search tree can be used to sort data stored in the tree in ascending order
                {
                    new int[] { 6, 4, 2, 9, 7, 12, 15 },
                    new int[] { 2, 4, 6, 7, 9, 12, 15 }
                },

                {
                    new int[] { 2, 4, 6, 7, 9, 12, 15 },
                    new int[] { 2, 4, 6, 7, 9, 12, 15 }
                },

                {
                    new int[] { 15, 12, 9, 7, 6, 4, 2 },
                    new int[] { 2, 4, 6, 7, 9, 12, 15 }
                }
            };
        }

        public static TheoryData<string[], string[]> GetDataForTestingInOrderTraverseOnStrings()
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

        public static TheoryData<int[], int[]> GetDataForTestingPreOrderTraverseOnIntegers()
        {
            return new TheoryData<int[], int[]>()
            {
                // Pre-order traverse on a binary search tree can be used to get data stored in the tree in the same order they were stored
                {
                    new int[] { 6, 4, 2, 9, 7, 12, 15 },
                    new int[] { 6, 4, 2, 9, 7, 12, 15 }
                },

                {
                    new int[] { 2, 4, 6, 7, 9, 12, 15 },
                    new int[] { 2, 4, 6, 7, 9, 12, 15 }
                },

                {
                    new int[] { 15, 12, 9, 7, 6, 4, 2 },
                    new int[] { 15, 12, 9, 7, 6, 4, 2 }
                }
            };
        }

        public static TheoryData<string[], string[]> GetDataForTestingPreOrderTraverseOnStrings()
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

        public static TheoryData<int[], int[]> GetDataForTestingPostOrderTraverseOnIntegers()
        {
            return new TheoryData<int[], int[]>()
            {
                {
                    new int[] { 6, 4, 2, 9, 7, 12, 15 },
                    new int[] { 2, 4, 7, 15, 12, 9, 6 }
                },

                // Though sorted data should not be stored in a binary search tree, post-order traverse on a binary search tree can be used to reverse order of sorted data stored in the tree
                {
                    new int[] { 2, 4, 6, 7, 9, 12, 15 },
                    new int[] { 15, 12, 9, 7, 6, 4, 2 }
                },

                {
                    new int[] { 15, 12, 9, 7, 6, 4, 2 },
                    new int[] { 2, 4, 6, 7, 9, 12, 15 }
                }
            };
        }

        public static TheoryData<string[], string[]> GetDataForTestingPostOrderTraverseOnStrings()
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
