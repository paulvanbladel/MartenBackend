using System;
using Autofac;
using MartenBackend.Common.Contract;


namespace MartenBackend.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = ClientConsole.GetContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.RunAsync().Wait();
            }
            Console.Read();
        }
    }
}
