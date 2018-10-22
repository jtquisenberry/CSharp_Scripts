

public string ReverseString(string s)
{
    int startIndex = 0;
    int endIndex = s.Length -1;
    StringBuilder sb = new StringBuilder(s);
    while (startIndex < endIndex)
    {
        char temp = ' ';
        temp = s[startIndex];
        sb[startIndex] = sb[endIndex];
        sb[endIndex] = temp;
        startIndex ++;
        endIndex --;
    }

    return sb.ToString();
}


string s = "abcde";

string reversed = ReverseString(s);
Console.WriteLine(reversed);
