List<int> numbers = new List<int>() {1,2,3,4,5,6,7,8,9,10};

var selectedNumbers = numbers.Skip(2).Take(8).ToList();
Console.WriteLine(ToStringElements(selectedNumbers));

selectedNumbers = numbers.Skip(2).Take(8).Select(x => x+100).ToList();
Console.WriteLine(ToStringElements(selectedNumbers));

selectedNumbers = numbers.Skip(2).Take(8).Select(x => x+100).Where(x => x % 2 == 0).OrderBy(x => x).Reverse().ToList();
Console.WriteLine(ToStringElements(selectedNumbers));

selectedNumbers.Sort((x,y) => x.CompareTo(y));
Console.WriteLine(ToStringElements(selectedNumbers));

Console.WriteLine(numbers.Min());

// Equivalent of map function in Python, use Select().
string s = "hello";
char[] s_characters = s.ToCharArray();
List<string> s_strings = s_characters.Select(x => x.ToString()).ToList();
Console.WriteLine(ToStringElements(s_strings));







public string ToStringElements(List<int> list)
{
    string written = "";

    foreach(var item in list)
    {
        written += item.ToString() + ",";
    }
    
    return written.Substring(0,written.Length - 1);
}

public string ToStringElements(List<string> list)
{
    string written = "";

    foreach(var item in list)
    {
        written += item + ",";
    }
    
    return written.Substring(0,written.Length - 1);
}