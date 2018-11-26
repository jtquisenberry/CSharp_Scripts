using System;
using System.Linq;
using System.Collections.Generic;

//using System.Math;
					
public class Program
{
	public static void Main()
	{
		
		/* Max example 1 */
		int[] array2 = new int[] {2,-4,6,-8};
		var max = array2.Max((a) => Math.Pow(a,2));
		Console.WriteLine("max 1 {0}", max);
		// 64 - not the object, but the result of manipulating the object
		
		
		/* Max example 2 */
		List<MyNumber> numbers = new List<MyNumber>();
		MyNumber number = new MyNumber(2);
		numbers.Add(number);
		number = new MyNumber(-4);
		numbers.Add(number);
		number = new MyNumber(6);
		numbers.Add(number);
		number = new MyNumber(-8);
		numbers.Add(number);
		var max2 = numbers.Max(a => a.absolute_value);
		Console.WriteLine("max 2 {0}", max2);
		// 8 - not the object, but the result of manipulating the object
		

		/* Max example with query syntax */		
		List<MyNumber> result = 
			(from number2 in numbers
			 where number2.face_value > -9999
			 orderby number2.absolute_value descending,
			     number2.absolute_value
			 select number2).ToList();
		Console.WriteLine("max 3 - query syntax: {0}", result[0]);
		// -8:8 - The object, which was ordered on the basis of a field.
		
		
		/* OrderBy 1 */
		var results2 = numbers.OrderBy(a => a.absolute_value);
		foreach (var n in results2)
		{
			Console.WriteLine(n.ToString());
		}
		
		
		/* OrderBy 2 - Two sort criteria */
				
		Console.WriteLine("Two Order By Clauses");
		number = new MyNumber(8);
		numbers.Add(number);
		var results3 = numbers.Where(a => Math.Pow(a.face_value,2) == 64)
			.OrderByDescending(a => a.face_value)
            .ThenByDescending(a => a.absolute_value); // Could add more ThenBy calls
			
		
		foreach(var _ in results3)
		{
			Console.WriteLine(_);
		}
	
	}
}


public class MyNumber
{
	public int face_value;
	public int absolute_value;
	
	
	public MyNumber(int a)
	{
		face_value = a;
		absolute_value = Math.Abs(a);
	}
	
	public override string ToString()
	{
		return face_value.ToString() + ":" + absolute_value.ToString();	
	}
}

Program.Main();