using System.Linq;
using System.Collections.Generic;


public double GetMiddleOfArray(List<int> list)
{

    //var list = new List<int>() {1,2,3,4,5,6,7,8};
    var fast_index = 0;

    var status = true;
    while (status)
    {
        try
        {    
            
            fast_index += 1;
            int fast_value = list[fast_index];
            fast_index += 1;
            fast_value = list[fast_index];
        }
        catch(ArgumentOutOfRangeException e) // not IndexOutOfRangeException
        {
            status = false;
            fast_index--;
        }
    
        
    }

    Console.WriteLine("Fast Index {0}", fast_index);

    if (fast_index % 2 > 0)
    {
        // odd index, even length
        var average = (fast_index / 2 + fast_index / 2 + 1) / 2.0;
        Console.WriteLine("Even Length {0}", average);
        return average;
    }
    else
    {
        var average = (fast_index / 2);
        Console.WriteLine("Odd Length {0}", fast_index / 2);
        return average;
    }


}

// Even Length
var list = new List<int>() {1,2,3,4,5,6,7,8};
GetMiddleOfArray(list);

// Odd Length
list = new List<int>() {1,2,3,4,5,6,7,8,9};
GetMiddleOfArray(list);