// scriptcs .\strings.csx

// Substring
Console.WriteLine("");
Console.WriteLine("Substring");
string word = "hello";
int start = 0;
int length = 3;
string h = word.Substring(start, length);
Console.WriteLine(h);

// IndexOf
Console.WriteLine("");
Console.WriteLine("IndexOf");
Console.WriteLine(word.IndexOf("ell"));

// Write Variables
Console.WriteLine("");
Console.WriteLine("Write Variables");
Console.WriteLine("Test {0} here {1}", "99", 88);

// String.Join
Console.WriteLine("");
Console.WriteLine("String.Join");
string joinedString = String.Join(",", new int[]{1,2,3,4});
Console.WriteLine(joinedString);

// String.Split
Console.WriteLine("");
Console.WriteLine("String.Split");
string[] separators = {"ll"};
string splitWord = ToStringElements(word.Split(separators,StringSplitOptions.RemoveEmptyEntries).ToList());
Console.WriteLine(splitWord);

public string ToStringElements(List<string> list)
{
    string written = "";

    foreach(var item in list)
    {
        written += item + ",";
    }
    
    return written.Substring(0,written.Length - 1);
}
