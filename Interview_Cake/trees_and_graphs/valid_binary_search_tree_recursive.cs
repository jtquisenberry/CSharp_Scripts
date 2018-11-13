using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/bst-checker?course=fc1&section=trees-graphs


namespace valid_binary_search_tree_recursive
{

    public class Solution
    {
        public class BinaryTreeNode
        {
            public int Value { get; }
            public BinaryTreeNode Left { get; private set; }
            public BinaryTreeNode Right { get; private set; }

            public BinaryTreeNode(int value)
            {
                Value = value;
            }

            public BinaryTreeNode InsertLeft(int leftValue)
            {
                Left = new BinaryTreeNode(leftValue);
                return Left;
            }

            public BinaryTreeNode InsertRight(int rightValue)
            {
                Right = new BinaryTreeNode(rightValue);
                return Right;
            }
        }
        
        public class NodeAndBounds
        {
            
            public BinaryTreeNode node;
            public int upper_bound;
            public int lower_bound;
            
            
            public NodeAndBounds(BinaryTreeNode node, int lower_bound, int upper_bound)
            {
                this.node = node;
                this.upper_bound = upper_bound;
                this.lower_bound = lower_bound;
            }
        }

        public static bool IsBinarySearchTree(BinaryTreeNode root)
        {
            // Determine if the tree is a valid binary search tree
            return IsBinarySearchTree(root, Int32.MinValue, Int32.MaxValue);
        }
        
        public static bool IsBinarySearchTree(BinaryTreeNode root, int lowerBound, int upperBound)
        {
            
            if (root == null)
            {
                return true;
            }
            
            if (root.Value <= lowerBound || root.Value >= upperBound)
            {
                return false;
            }
            
            return IsBinarySearchTree(root.Left, lowerBound, root.Value)
            && IsBinarySearchTree(root.Right, root.Value, upperBound);
            
        }


















        // Tests

        [Fact]
        public void ValidFullTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70);
            b.InsertLeft(60);
            b.InsertRight(80);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

        [Fact]
        public void BothSubtreesValidTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(20);
            a.InsertRight(60);
            var b = root.InsertRight(80);
            b.InsertLeft(70);
            b.InsertRight(90);
            var result = IsBinarySearchTree(root);
            Assert.False(result);
        }

        [Fact]
        public void DescendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertLeft(40).InsertLeft(30).InsertLeft(20).InsertLeft(10);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

        [Fact]
        public void OutOfOrderLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertRight(70).InsertRight(60).InsertRight(80);
            var result = IsBinarySearchTree(root);
            Assert.False(result);
        }

        [Fact]
        public void OneNodeTreeTest()
        {
            var root = new BinaryTreeNode(50);
            var result = IsBinarySearchTree(root);
            Assert.True(result);
        }

    }

}