using System;
using Autofac;
using MartenBackend.Domain;
using MartenBackend.Bootstrapping;

namespace MartenBackend.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = Bootstrap.GetContainerForConsoleApp();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.RunAsync().Wait();
            }
            Console.Read();
        }
    }
}
