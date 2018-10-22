public class Program
{
    public static void Main(string[] args)
    {
        int intInvoiceType = 0;
        IInvoice objInvoice;
        Console.WriteLine("Enter Invoice Type");
        intInvoiceType = Convert.ToInt32(Console.ReadLine());
        objInvoice = clsFactoryInvoice.getInvoice(intInvoiceType);
        objInvoice.print();
        Console.ReadLine();
    }
}
public static class clsFactoryInvoice
{
    static public IInvoice getInvoice(int intInvoiceType)
    {
        IInvoice objinv;
        if(intInvoiceType == 1)
        {   objinv = new clsInvoiceWithHeader(); }
        else if (intInvoiceType == 2)
        {   objinv = new clsInvoiceWithOutHeaders(); }
        else
        {   return null; }
        return objinv;
    }
}
public class clsInvoiceWithHeader : IInvoice
{
    public void print()
    {  Console.WriteLine("With Headers");  }
}
public class clsInvoiceWithOutHeaders : IInvoice
{
    public void print ()
    {  Console.WriteLine("WITHOUT Headers"); }
}
public interface IInvoice
{
    void print();
}

Program.Main(null);
