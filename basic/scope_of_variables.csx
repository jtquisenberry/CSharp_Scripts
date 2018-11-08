/************/
// Immutable Integer
/************/

int i = 9999;
Console.WriteLine("Integer is an object: {0}", i is object);
public void UpdateInt(int i)
{
    i += 1;
    Console.WriteLine("inside immutable int: {0}", i);
    return;
}

UpdateInt(i);
Console.WriteLine("outside immutable int: {0}", i);
Console.WriteLine();


List<int> integers = new List<int>();
Console.WriteLine("List is an object {0}", i is object);
integers.Add(1);

public void UpdateList(List<int> list)
{
    integers.Add(2);
    Console.WriteLine("inside mutable List: {0}", integers.Last());
    return;
}

UpdateList(integers);
Console.WriteLine("outside mutable List: {0}", integers.Last());