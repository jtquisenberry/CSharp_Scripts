using System;
using System.Text.RegularExpressions;
					
public class Program
{
	public static void Main()
	{
		string a = "xxxx";
		Console.WriteLine(a.GetType().BaseType);
		string c = a;
		
		Console.WriteLine("test1");
		var eq = object.ReferenceEquals(a, c);
		Console.WriteLine(eq);
		
		
		EditString( a,  c);
		Console.WriteLine(a);
		
		Console.WriteLine("test2");
		eq = object.ReferenceEquals(a, c);
		Console.WriteLine(eq);
		
		
		Cow cow = new Cow();
		Cow cow2 = cow;
		Console.WriteLine("cow.legs {0}", cow.legs);
		EditClass(cow);
		Console.WriteLine("cow.legs {0}", cow.legs);
		Console.WriteLine("cow2.legs {0}", cow2.legs);
		
		var eq2 = object.ReferenceEquals(cow, cow2);
		Console.WriteLine("Are cow and cow2 equal", eq2);
	}
	
	public static void EditString(string a, string c)
	{
		
		a = "bbbbb";
		Console.WriteLine("strings");
		var eq = object.ReferenceEquals(a, c);
		Console.WriteLine(eq);
	}
	
	public static void EditClass(Cow cow)
	{
		cow.legs = 6;
	}
}

public class Cow
{
	public int legs = 4;
}

Program.Main();