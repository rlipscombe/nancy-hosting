using Nancy;

namespace WebApplication
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get["/"] = _ => "Hello World!";
            Get["/nancy"] = _ => "Hello Nancy!";
        }
    }
}