using System;
using System.Collections.Generic;
using Xunit;

// https://www.interviewcake.com/question/csharp/balanced-binary-tree?section=trees-graphs&course=fc1
// Determine whether a binary tree is "super-balanced" - 
// No two leaf nodes differ in depth by more than one.


namespace superbalanced_tree
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

        public static bool IsBalanced(BinaryTreeNode treeRoot)
        {
            // Determine if the tree is superbalanced
            
            if (treeRoot == null)
            {
                return true;
            }
            
            var depths = new List<int>();
            
            var nodes = new Stack<NodeDepthPair>();
            nodes.Push(new NodeDepthPair(treeRoot, 0));
            
            while (nodes.Count > 0)
            {
                var nodeDepthPair = nodes.Pop();
                var node = nodeDepthPair.Node;
                var depth = nodeDepthPair.Depth;
                
                
                if (node.Left == null && node.Right == null)
                {
                    //Found a leaf
                    if (!depths.Contains(depth))
                    {
                        depths.Add(depth);
                    }
                    
                    
                    if ((depths.Count > 2) || (depths.Count == 2 && Math.Abs(depths[0] - depths[1]) > 1))
                    {
                        return false;
                    }
                    
                }
                
                else
                {
                    if (node.Left != null)
                    {
                        nodes.Push(new NodeDepthPair(node.Left, depth + 1));
                    }
                    if (node.Right != null)
                    {
                        nodes.Push(new NodeDepthPair(node.Right, depth + 1));
                    }
                    
                }
            }
            
            return true;
        }
        
        public class NodeDepthPair
        {
            public BinaryTreeNode Node;
            public int Depth;
            
            public NodeDepthPair(BinaryTreeNode node, int depth)
            {
                Node = node;
                Depth = depth;
            }
        }



        // Tests

        [Fact]
        public void FullTreeTest()
        {
            var root = new BinaryTreeNode(5);
            var a = root.InsertLeft(8);
            var b = root.InsertRight(6);
            a.InsertLeft(1);
            a.InsertRight(2);
            b.InsertLeft(3);
            b.InsertRight(4);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void BothLeavesAtTheSameDepthTest()
        {
            var root = new BinaryTreeNode(3);
            root.InsertLeft(4).InsertLeft(1);
            root.InsertRight(2).InsertRight(9);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void LeafHeightsDifferByOneTest()
        {
            var root = new BinaryTreeNode(6);
            root.InsertLeft(1);
            root.InsertRight(0).InsertRight(7);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void LeafHeightsDifferByTwoTest()
        {
            var root = new BinaryTreeNode(6);
            root.InsertLeft(1);
            root.InsertRight(0).InsertRight(7).InsertRight(8);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Fact]
        public void BothSubTreesSuperbalancedTest()
        {
            var root = new BinaryTreeNode(1);
            root.InsertLeft(5);
            var b = root.InsertRight(9);
            b.InsertLeft(8).InsertLeft(7);
            b.InsertRight(5);
            var result = IsBalanced(root);
            Assert.False(result);
        }

        [Fact]
        public void OnlyOneNodeTest()
        {
            var root = new BinaryTreeNode(1);
            var result = IsBalanced(root);
            Assert.True(result);
        }

        [Fact]
        public void TreeIsLinkedListTest()
        {
            var root = new BinaryTreeNode(1);
            root.InsertRight(2).InsertRight(3).InsertRight(4);
            var result = IsBalanced(root);
            Assert.True(result);
        }

    }
}