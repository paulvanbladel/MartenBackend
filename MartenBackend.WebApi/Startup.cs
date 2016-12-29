using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Marten;
using MartenBackend.Common;
using MartenBackend.Domain;
using MartenBackend.Repository.DI;

namespace MartenBackend.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            this.ApplicationContainer = GetContainer(services);

            var serviceProvider = new AutofacServiceProvider(this.ApplicationContainer);
            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //disponse container resources
            appLifetime.ApplicationStopped.Register(() => this.ApplicationContainer.Dispose());

        }
        public static IContainer GetContainer(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            string connectionString = @"host=localhost;database=postgres;password=.;username=postgres";

            var Store = DocumentStore.For(configure =>
            {
                configure.Connection(connectionString);
                configure.Schema.For<Customer>().UseOptimisticConcurrency(true).SoftDeleted();
                //using pre-supplied logger
                //configure.Logger(new ConsoleMartenLogger());
                configure.Logger(new CustomMartenLogger());
                //TODO integrate with serilog

            });


            // for web api we use InstancePerRequest
            builder.Register(r => Store).As<IDocumentStore>().InstancePerRequest();

            builder.RegisterModule(new RepositoryModule());


            var container = builder.Build();
            return container;
        }
    }
}


