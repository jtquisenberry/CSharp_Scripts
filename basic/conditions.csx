
List<int> depths = new List<int>() {2,4};


Console.WriteLine(depths[0]);
Console.WriteLine(depths[1]);
Console.WriteLine(depths.Count);



bool z = ((depths.Count > 2) || ((depths.Count == 2) && ((Math.Abs(depths[0] - depths[1])) > 1)));
Console.WriteLine(z);

Console.WriteLine((Math.Abs(depths[0]) - Math.Abs(depths[1])));





Console.WriteLine(((depths.Count > 2) || ((depths.Count == 2) && 
            (Math.Abs(depths[0]) - Math.Abs(depths[1])) > 1)));