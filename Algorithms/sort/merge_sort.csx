using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// scriptcs .\merge_sort.csx
 
public class Program
{
    public static void Main(string[] args)
    {
        List<int> unsorted = new List<int>();
        List<int> sorted;
        Random random = new Random();
        Console.WriteLine("Original array elements:" );
        for(int i = 0; i< 10;i++){
            unsorted.Add(random.Next(0,100));
            Console.Write(unsorted[i]+" ");
        }
        Console.WriteLine();
        sorted = MergeSort(unsorted);
        Console.WriteLine("Sorted array elements: ");
        foreach (int x in sorted)
        {
            Console.Write(x+" ");
        }
		Console.Write("\n");
    }
	
    private static List<int> MergeSort(List<int> unsorted)
    {

        if (unsorted.Count <= 1)
        {
            return unsorted;
        }
        
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        // last index - first index / 2
        int middle = (unsorted.Count -1) / 2;
        for (int i = 0; i <= middle; i++)
        {
            // Add half of the list to the left list
            left.Add(unsorted[i]);
        }
        for (int i = middle+1; i < unsorted.Count; i++)
        {
            // Add half of the list to right list.
            right.Add(unsorted[i]);
        }

        // Recursive function.
        left = MergeSort(left);
        right = MergeSort(right);
        return Merge(left, right);


    }
    private static List<int> Merge(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();

        while(left.Count > 0 || right.Count > 0)
        {

            if (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            else if (left.Count > 0)
            {
                result.Add(left.First());
                left.Remove(left.First());
            }

            else if (right.Count > 0)
            {
                result.Add(right.First());
                right.Remove(right.First());
            }



        }

        return result;
    }
}

Program.Main(null);