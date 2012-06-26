using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;
using Nancy;
using Nancy.Hosting.Wcf;

namespace WcfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "http://localhost:1234/";
            if (args.Length != 0)
                uri = args[0];

            var stop = new ManualResetEvent(false);
            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("^C");
                stop.Set();
            };

            var host = new WebServiceHost(new NancyWcfGenericService(), new Uri(uri));
            host.AddServiceEndpoint(typeof(NancyWcfGenericService), new WebHttpBinding(), "");
            host.Open();
            Console.WriteLine("Nancy WCF Host listening on {0}", uri);
            Console.WriteLine("Press Ctrl+C to quit.");

            stop.WaitOne();

            host.Close();
        }
    }

    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = _ => "Hello World!";
            Get["/nancy"] = _ => "Hello Nancy!";
        }
    }
}
