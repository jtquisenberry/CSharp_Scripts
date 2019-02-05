using System;
using Xunit;

// Find the kth to last node in a singly-linked list.

// https://www.interviewcake.com/question/csharp/kth-to-last-node-in-singly-linked-list?course=fc1&section=linked-lists


public class kth_to_last_node
{
    public class LinkedListNode
    {
        public int Value { get; set; }

        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }



public static LinkedListNode KthToLastNode(int k, LinkedListNode head)
{
    if (k < 1)
    {
        throw new ArgumentException(nameof(k),
            $"Impossible to find less than first to last node: {k}");
    }

    var leftNode  = head;
    var rightNode = head;

    // Move rightNode to the kth node
    for (int i = 0; i < k - 1; i++)
    {
        // But along the way, if a rightNode doesn't have a next,
        // then k is greater than the length of the list and there
        // can't be a kth-to-last node! we'll raise an error
        if (rightNode.Next == null)
        {
            throw new ArgumentException(nameof(k),
                $"k is larger than the length of the linked list: {k}");
        }

        rightNode = rightNode.Next;
    }

    // Starting with leftNode on the head,
    // move leftNode and rightNode down the list,
    // maintaining a distance of k between them,
    // until rightNode hits the end of the list
    while (rightNode.Next != null)
    {
        leftNode  = leftNode.Next;
        rightNode = rightNode.Next;
    }

    // Since leftNode is k nodes behind rightNode,
    // leftNode is now the kth to last node!
    return leftNode;
}

















    // Tests

    [Fact]
    public void FirstToLastNodeTest()
    {
        var listNodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4 });
        var k = 1;
        var actual = KthToLastNode(k, listNodes[0]);
        var expected = listNodes[listNodes.Length - k];
        Assert.Same(expected, actual);
    }

    [Fact]
    public void SecondToLastNodeTest()
    {
        var listNodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4 });
        var k = 2;
        var actual = KthToLastNode(k, listNodes[0]);
        var expected = listNodes[listNodes.Length - k];
        Assert.Same(expected, actual);
    }

    [Fact]
    public void FirstNodeTest()
    {
        var listNodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4 });
        var k = 4;
        var actual = KthToLastNode(k, listNodes[0]);
        var expected = listNodes[listNodes.Length - k];
        Assert.Same(expected, actual);
    }

    [Fact]
    public void KIsGreaterThanLinkedListLengthTest()
    {
        var listNodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4 });
        var k = 5;
        Assert.Throws<ArgumentException>(() => KthToLastNode(k, listNodes[0]));
    }

    [Fact]
    public void KIsZeroTest()
    {
        var listNodes = ValuesToLinkedListNodes(new int[] { 1, 2, 3, 4 });
        var k = 0;
        Assert.Throws<ArgumentException>(() => KthToLastNode(k, listNodes[0]));
    }

    private static LinkedListNode[] ValuesToLinkedListNodes(int[] values)
    {
        var nodes = new LinkedListNode[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            nodes[i] = new LinkedListNode(values[i]);
            if (i > 0)
            {
                nodes [i - 1].Next = nodes[i];
            }
        }
        return nodes;
    }

}