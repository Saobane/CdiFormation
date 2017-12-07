using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(CallBackWcfService.Service1)))
            {
                host.Open();
                Console.WriteLine("Service started @ "+DateTime.Now);
                Console.ReadLine();
            }
        }
    }
}
