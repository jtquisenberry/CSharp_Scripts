using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
	{

		/* Arrays */
		int[] array = new int[]{0, 1, 2, 6};
		Console.WriteLine(array[3]);

		//Initialize array to zeros
		int[] array2 = new int[4];
		
		
		// Fails
		//var a = [0,1,2];
		//var a2 = {0,1,2}
		
		
		/* Dictionary */
		Dictionary<int, string> dict = new Dictionary<int, string>{{3, "cows"}};
		Console.WriteLine(dict[3]);
		// Fails
		//var d = {{3,"cows"}};
		
		dict[4] = "chickens";
		Console.WriteLine(dict[4]);
		dict.Add(5,"fish");
		Console.WriteLine(dict[5]);
		
		
		
		
		
		
		/* List */
		List<int> list = new List<int>{0, 2, 4, 5};
		Console.WriteLine(list[3]);
		
		
		/* ArrayList */
		ArrayList al = new ArrayList{0, 2, 4, "dogs"};
		Console.WriteLine(al[3]);
		
		
		/* Stack */
		Stack stack = new Stack();
		stack.Push("chickens");
		stack.Push(4);
		stack.Push("fish");
		Console.WriteLine(stack.Pop());
		
		
		/* Queue  */
		Queue queue = new Queue();
		queue.Enqueue("chickens");
		queue.Enqueue(4);
		queue.Enqueue("fish");
		Console.WriteLine(queue.Dequeue());
	}
}

Program.Main();