int i = 9999;
//Console.WriteLine(i.GetType().Attributes);

Type t = i.GetType();
Console.WriteLine(t.Name);

Type p = t;

while ((p = p.BaseType) != null)
{
    Console.WriteLine(p.Name);
}




