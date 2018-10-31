using System;
using Xunit;

// https://www.interviewcake.com/question/csharp/delete-node?section=linked-lists&course=fc1

public class delete_node
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
    public static void DeleteNode(LinkedListNode nodeToDelete)
    {
        // Delete the input node from the linked list
        
        LinkedListNode nextNode = nodeToDelete.Next;
        
        if (nextNode == null)
        {
            //nodeToDelete = null;
            throw new InvalidOperationException("Cannot delete the last node");
        }
        else
        {
            nodeToDelete.Value = nextNode.Value;
            nodeToDelete.Next = nextNode.Next;
        }
    }
    // Tests
    [Fact]
    public void NodeAtBeginningTest()
    {
        var head = new LinkedListNode(1); 
        AppendToList(head, 2);
        AppendToList(head, 3);
        AppendToList(head, 4);
        DeleteNode(head);
        var node = head;
        Assert.Equal(2, node.Value);
        node = node.Next;
        Assert.Equal(3, node.Value);
        node = node.Next;
        Assert.Equal(4, node.Value);
        Assert.Null(node.Next);
    }
    [Fact]
    public void NodeInTheMiddleTest()
    {
        var head = new LinkedListNode(1);
        var nodeToDelete = AppendToList(head, 2);
        AppendToList(head, 3);
        AppendToList(head, 4);
        DeleteNode(nodeToDelete);
        var node = head;
        Assert.Equal(1, node.Value);
        node = node.Next;
        Assert.Equal(3, node.Value);
        node = node.Next;
        Assert.Equal(4, node.Value);
        Assert.Null(node.Next);
    }
    [Fact]
    public void NodeAtTheEndTest()
    {
        var head = new LinkedListNode(1);
        AppendToList(head, 2);
        AppendToList(head, 3);
        var nodeToDelete = AppendToList(head, 4);
        Assert.Throws<InvalidOperationException>(() => DeleteNode(nodeToDelete));
    }
    [Fact]
    public void OneNodeListTest()
    {
        var head = new LinkedListNode(1);
        Assert.Throws<InvalidOperationException>(() => DeleteNode(head));
    }
    private static LinkedListNode AppendToList(LinkedListNode head, int value)
    {
        var current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new LinkedListNode(value);
        return current.Next;
    }
}