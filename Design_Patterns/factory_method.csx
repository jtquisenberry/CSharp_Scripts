

class Program
{
    public static void Main(string[] args)
    {
        var memberManager = new MemberManagerForTest();
        memberManager.DoSomeWork();
        Console.ReadLine();
    }
}
abstract class EmailServiceBase
{
    public abstract void SendEmails();
}
class EmailService : EmailServiceBase
{
    public override void SendEmails()
    {
        Console.WriteLine("Emails have been sent");
    }
}
class EmailServiceStub : EmailServiceBase
{
    public override void SendEmails()
    {
        Console.WriteLine("No Emails were sent");
    }
}

abstract class MemberManagerBase
{
    private EmailServiceBase emailService;
    protected EmailServiceBase EmailService 
        { get { return emailService ?? (emailService = MakeEmailService()); } }

    protected abstract EmailServiceBase MakeEmailService();
    public MemberManagerBase()
    {
    }
    public void DoSomeWork()
    {
        Console.WriteLine("Validations are done");
        EmailService.SendEmails();
        Console.WriteLine("Data has been saved");
        Console.WriteLine("Work Completed");
    }
}
class MemberManager : MemberManagerBase
{
    public MemberManager()
    {        }
    
    protected override EmailServiceBase MakeEmailService()
    {
        return new EmailService();
    }
}
class MemberManagerForTest : MemberManagerBase
{
    public MemberManagerForTest()
    {        }
    
    protected override EmailServiceBase MakeEmailService()
    {
        return new EmailServiceStub();
    }
}

Program.Main(null);
