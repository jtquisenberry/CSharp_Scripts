using System;
using System.Collections.Generic;
using System.Linq;

// Floor Division
var a = (int)Math.Floor(7.2/3.0);
Console.WriteLine(a);
Console.WriteLine(a.GetType());
Console.WriteLine(2.3);
Console.WriteLine("abc {0} {0} {1}",(int)2.3, 99);

// Math.Max
Console.WriteLine(Math.Max(2,3));

// Enumerable.Max
// Requires Linq
var l = new List<int>() { 1, 3, 2, 5};
var m = Enumerable.Max(l);
Console.WriteLine(m);
m = l.Max();
Console.WriteLine(m);






