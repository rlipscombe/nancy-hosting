using System;
using System.Threading;
using Nancy.Hosting.Self;

namespace SelfHost
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Note: The URI must *exactly* match the one specified in the URL ACL.
            // This leads to a problem when you use +, because the Uri constructor doesn't like it.
            var uri = "http://localhost:1234/";
            if (args.Length != 0)
                uri = args[0];

            var stop = new ManualResetEvent(false);
            Console.CancelKeyPress += (sender, e) =>
                {
                    Console.WriteLine("^C");
                    stop.Set();
                };

            var host = new NancyHost(new Uri(uri));
            host.Start();

            Console.WriteLine("Nancy Self Host listening on {0}", uri);
            Console.WriteLine("Press Ctrl+C to quit.");

            stop.WaitOne();

            host.Stop();
        }
    }
}
