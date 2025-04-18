using OneC;

namespace OneConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var erp = new OneClient("Srvr=;Ref=;Usr=;Pwd=;");
            var staff = erp.GetStaff().ToList();
            foreach (var item in staff)
            {
                Console.WriteLine("{0}/{1}: {2}", item.Id, item.Code, item.Name);
            }
            Console.Beep();
            Console.WriteLine("the end!");
            Console.ReadLine();
        }
    }
}
