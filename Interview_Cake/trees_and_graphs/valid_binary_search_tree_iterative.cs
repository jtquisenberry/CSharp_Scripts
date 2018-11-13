using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/bst-checker?course=fc1&section=trees-graphs


namespace valid_binary_search_tree_iterative
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
            
            
            // Depth first in case short-circuiting is possible.
            // Depth first accomplished with stack.
            Stack<NodeAndBounds> node_and_bounds_stack = new Stack<NodeAndBounds>();
            NodeAndBounds node_and_bounds = new NodeAndBounds(root,Int32.MinValue, Int32.MaxValue);
            node_and_bounds_stack.Push(node_and_bounds);
            
            while (node_and_bounds_stack.Count > 0)
            {
                NodeAndBounds current_node_and_bounds = node_and_bounds_stack.Pop();
                var node = current_node_and_bounds.node;
                var lower_bound = current_node_and_bounds.lower_bound;
                var upper_bound = current_node_and_bounds.upper_bound;
                
                if (node.Value >= upper_bound || node.Value <= lower_bound)
                {
                    return false;
                }
                else
                {
                    if (node.Left != null)
                    {
                        var left_node = new NodeAndBounds(node.Left, lower_bound, node.Value);
                        node_and_bounds_stack.Push(left_node);
                    }
                    if (node.Right != null)
                    {
                        var right_node = new NodeAndBounds(node.Right, node.Value, upper_bound);
                        node_and_bounds_stack.Push(right_node);
                    }
                }
                
            }
            
            return true;
            
            
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