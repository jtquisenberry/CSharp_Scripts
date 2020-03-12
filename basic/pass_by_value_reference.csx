
Console.WriteLine();
Console.WriteLine("Immutable, Value Type `int`");
int i = 9999;
Console.WriteLine("Type:            {0}", i.GetType().Name);
Console.WriteLine("Base Type:       {0}", i.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", i.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", i);
public void UpdateInt(int i)
{
    i += 1;
    Console.WriteLine("Inside Function: {0}", i);
    /*
    unsafe {
        IntPtr x = (IntPtr)(&i);
        Console.WriteLine("Inside function, Pointer is {0}", x);
        }
    */
    
    return;
}

UpdateInt(i);
Console.WriteLine("After Function:  {0}", i);
Console.WriteLine();

///////////////////////////////////////////////////////////////////////

Console.WriteLine("Immutable, Value Type `int` with `ref` Keyword");
int j = 9999;
Console.WriteLine("Type:            {0}", j.GetType().Name);
Console.WriteLine("Base Type:       {0}", j.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", j.GetType().IsValueType);
Console.WriteLine("Original Value   {0}", j);
public void UpdateInt2(ref int j)
{
    j += 1;
    Console.WriteLine("Inside Function {0}", j);
    return;
}

UpdateInt2(ref j);
Console.WriteLine("After Function: {0}", j);
Console.WriteLine();

//////////////////////////////////////////////////////////////

Console.WriteLine("Immutable, Value Type `int` with `out` Keyword");
int k = 9999;
Console.WriteLine("Type:            {0}", k.GetType().Name);
Console.WriteLine("Base Type:       {0}", k.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", k.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", k);
public void UpdateInt3(out int k)
{
    // When using keyword `out`, initialization must occur within
    // the function.
    k = 0;
    k += 1;
    Console.WriteLine("Inside Function: {0}", k);
    return;
}

UpdateInt3(out k);
Console.WriteLine("After Function:  {0}", k);
Console.WriteLine();


//////////////////////////////////////////////////////////////


Console.WriteLine("Immutable, Value Type `int` Boxed in Object");
Object m = 9999;
Console.WriteLine("Type:            {0}", m.GetType().Name);
Console.WriteLine("Base Type:       {0}", m.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", m.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", m);
public void UpdateInt4(Object m)
{
    m = (Object)((int)m + 1);
    Console.WriteLine("Inside Function: {0}", m);
    return;
}

UpdateInt4(m);
Console.WriteLine("After Function:  {0}", m);
Console.WriteLine();


//////////////////////////////////////////////////////////////

Console.WriteLine("Immutable, Reference Type `string`");
string s = "abcdef";
Console.WriteLine("Type:            {0}", s.GetType().Name);
Console.WriteLine("Base Type:       {0}", s.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", s.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", s);
public void UpdateString(string s)
{
    s += "1";
    Console.WriteLine("Inside Function: {0}", s);
    return;
}

UpdateString(s);
Console.WriteLine("After Function:  {0}", s);
Console.WriteLine();


/////////////////////////////////////////////////////////////////////////////////////

Console.WriteLine("Immutable, Reference Type `string`, ref Keyword");
s = "abcdef";
Console.WriteLine("Type:            {0}", s.GetType().Name);
Console.WriteLine("Base Type:       {0}", s.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", s.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", s);
public void UpdateString2(ref string s)
{
    s += "1";
    Console.WriteLine("Inside Function: {0}", s);
    return;
}

UpdateString2(ref s);
Console.WriteLine("After Function:  {0}", s);
Console.WriteLine();


/////////////////////////////////////////////////////////////////////////////////////

Console.WriteLine("Immutable, Reference Type `string`, out Keyword");
s = "abcdef";
Console.WriteLine("Type:            {0}", s.GetType().Name);
Console.WriteLine("Base Type:       {0}", s.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", s.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", s);
public void UpdateString3(out string s)
{
    // Using `out` keyword, initialization must occur in the function.
    s = "";
    s += "1";
    Console.WriteLine("Inside Function: {0}", s);
    return;
}

UpdateString3(out s);
Console.WriteLine("After Function:  {0}", s);
Console.WriteLine();


/////////////////////////////////////////////////////////////////////////////////////

Console.WriteLine("Mutable, Reference Type `List<int>`");
List<int> integers = new List<int>();
Console.WriteLine("Type:            {0}", integers.GetType().Name);
Console.WriteLine("Base Type:       {0}", integers.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", integers.GetType().IsValueType);
integers.Add(9999);

public void UpdateList(List<int> list)
{

    integers[0] += 1;
    Console.WriteLine("Inside Function: {0}", integers.Last());
    return; 
}

UpdateList(integers);
Console.WriteLine("After Function:  {0}", integers.Last());
Console.WriteLine();

/////////////////////////////////////////////////////////


public struct MyStruct
{
    public int p;
}

MyStruct my_struct;
my_struct.p = 9999;
Console.WriteLine("Immutable, Value Type `struct`");
Console.WriteLine("Type:            {0}", my_struct.GetType().Name);
Console.WriteLine("Base Type:       {0}", my_struct.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", my_struct.GetType().IsValueType);
Console.WriteLine("Original Value   {0}", my_struct.p);

public void UpdateStruct(MyStruct my_struct)
{
    my_struct.p += 1;
    Console.WriteLine("Inside Function: {0}", my_struct.p);
    return;
}

UpdateStruct(my_struct);
Console.WriteLine("After Function:  {0}", my_struct.p);
Console.WriteLine();


//////////////////////////////////////////////////////


public class MyClass
{
    public int p;
}

MyClass my_class = new MyClass();
my_class.p = 9999;
Console.WriteLine("Mutable, Object Type `MyClass`");
Console.WriteLine("Type:            {0}", my_class.GetType().Name);
Console.WriteLine("Base Type:       {0}", my_class.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", my_class.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", my_class.p);

public void UpdateObject(MyClass my_class)
{
    my_class.p += 1;
    Console.WriteLine("Inside Function: {0}", my_class.p);
    return;
}

UpdateObject(my_class);
Console.WriteLine("After Function:  {0}", my_class.p);
Console.WriteLine();

///////////////////////////////

int q = 9999;
Console.WriteLine("Global Object `int`");
Console.WriteLine("Type:            {0}", q.GetType().Name);
Console.WriteLine("Base Type:       {0}", q.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", q.GetType().IsValueType);
Console.WriteLine("Original Value:  {0}", q);

public void UpdateGlobal()
{
    q += 1;
    Console.WriteLine("Inside Function: {0}", q);
    return;
}

UpdateGlobal();
Console.WriteLine("After Function:  {0}", q);
Console.WriteLine();

////////////////////////////////////////////////

Console.WriteLine("Test Reference Equals with `ref` Keyword");
Console.WriteLine("Value Types Never Have Equal References.");
int a = 9999;
Console.WriteLine("Type:            {0}", a.GetType().Name);
Console.WriteLine("Base Type:       {0}", a.GetType().BaseType.Name);
Console.WriteLine("Is Value Type:   {0}", a.GetType().IsValueType);
Console.WriteLine("Original Value   {0}", a);
public void CompareReference(ref int b)
{
    Console.WriteLine("ReferenceEquals: {0}", Object.ReferenceEquals(a, b));
    Console.WriteLine("Inside Function: {0}", b);
    int c = 1;
    var d = c;
    Console.WriteLine("ReferenceEquals: {0}", Object.ReferenceEquals(c, d));
    return;
}

CompareReference(ref a);
//Console.WriteLine("After Function: {0}", b);
Console.WriteLine();