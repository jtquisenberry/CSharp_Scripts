using System;
using System.Collections.Generic;
using Xunit;

namespace superbalanced_recursive
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
            

            List<int> depths = new List<int>();
            bool output =  IsBalancedUtil(treeRoot, 0, depths);
            return output;
        }



        public static bool IsBalancedUtil(BinaryTreeNode treeRoot, int depth, List<int> depths)
        {
            
            int current_depth = depth + 1;
            
            if (treeRoot.Left == null && treeRoot.Right == null)
            {
                
                if (!depths.Contains(current_depth))
                {
                    depths.Add(current_depth);
                }
            }
            
            else
            {
                if (treeRoot.Left != null)
                {
                    IsBalancedUtil(treeRoot.Left, current_depth, depths);
                }
                
                if (treeRoot.Right != null)
                {
                    IsBalancedUtil(treeRoot.Right, current_depth, depths);
                }
            }


            if ((depths.Count > 2) || ((depths.Count == 2) && ((Math.Abs(depths[0] - depths[1])) > 1)))
            {
                return false;
            }
            
            return true;

            
            
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