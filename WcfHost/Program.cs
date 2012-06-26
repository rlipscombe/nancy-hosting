using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;
using Nancy.Hosting.Wcf;

namespace WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var stop = new ManualResetEvent(false);
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("^C");
                stop.Set();
            };

            var host = new WebServiceHost(new NancyWcfGenericService(), new Uri("http://localhost:1234/base/"));
            host.AddServiceEndpoint(typeof(NancyWcfGenericService), new WebHttpBinding(), "");
            host.Open();

            stop.WaitOne();

            host.Close();
        }
    }
}
