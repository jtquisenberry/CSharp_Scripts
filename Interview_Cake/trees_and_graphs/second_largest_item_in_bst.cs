using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/second-largest-item-in-bst?section=trees-graphs&course=fc1


namespace second_largest_item_in_bst
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

        public static int FindSecondLargest(BinaryTreeNode rootNode)
        {
            // Find the second largest item in the binary search tree
            
            if ((rootNode == null) || (rootNode.Right == null && rootNode.Left == null))
            {
                throw new ArgumentException("Two nodes are required");
            }
            
            var current = rootNode;
            
            while (current != null)
            {
                if (current.Left != null && current.Right == null)
                {
                    return FindLargest(current.Left);
                }
                
                if (current.Right != null && current.Right.Left == null && current.Right.Right == null)
                {
                    return current.Value;
                }
                
                current = current.Right;
            }
            
            return 0;
            
        }
        
        public static int FindLargest(BinaryTreeNode rootNode)
        {
            
            var current = rootNode;
            
            while (current.Right != null)
            {
                current = current.Right;
            }
            
            return current.Value;
            
        }


















        // Tests

        [Fact]
        public void FindSecondLargestTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70);
            b.InsertLeft(60);
            b.InsertRight(80);
            var actual = FindSecondLargest(root);
            var expected = 70;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LargestHasLeftChildTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            root.InsertRight(70).InsertLeft(60);
            var actual = FindSecondLargest(root);
            var expected = 60;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LargestHasLeftSubtreeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            var b = root.InsertRight(70).InsertLeft(60);
            b.InsertLeft(55).InsertRight(58);
            b.InsertRight(65);
            var actual = FindSecondLargest(root);
            var expected = 65;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SecondLargestIsRootNodeTest()
        {
            var root = new BinaryTreeNode(50);
            var a = root.InsertLeft(30);
            a.InsertLeft(10);
            a.InsertRight(40);
            root.InsertRight(70);
            var actual = FindSecondLargest(root);
            var expected = 50;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DescendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertLeft(40).InsertLeft(30).InsertLeft(20);
            var actual = FindSecondLargest(root);
            var expected = 40;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AscendingLinkedListTest()
        {
            var root = new BinaryTreeNode(50);
            root.InsertRight(60).InsertRight(70).InsertRight(80);
            var actual = FindSecondLargest(root);
            var expected = 70;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ExceptionWithTreeThatHasOneNodeTest()
        {
            var root = new BinaryTreeNode(50);
            Assert.Throws<ArgumentException>(() => FindSecondLargest(root));
        }

        [Fact]
        public void ExceptionWithEmptyTreeTest()
        {
            Assert.Throws<ArgumentException>(() => FindSecondLargest(null));
        }

    }
}