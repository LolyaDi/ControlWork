using BuisnessSystem.Services.Abstract;

namespace BuisnessSystem.Services
{
    public class ConsoleReporter : IReporter
    {
        public void SendReport(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}
