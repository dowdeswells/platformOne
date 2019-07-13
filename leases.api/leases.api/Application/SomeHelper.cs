using System;

namespace leases.api.Application
{
    public class SomeHelper : ISomeHelper
    {
        public void DoSomething()
        {
            Console.Out.WriteLine("This is the helper");
        }
    }
}