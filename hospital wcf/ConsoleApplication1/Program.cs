using EmailService;
using System;
using System.ServiceModel;
namespace ConsoleEmailHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(EmailService.EmailService)))
            {
                Console.WriteLine("Host Started....");
                host.Open();
                Console.ReadLine();
            }
        }
    }
}