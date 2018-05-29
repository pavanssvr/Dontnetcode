using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisplayProducts.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Autofac;


namespace DisplayProducts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<DataAccessLayer>(); //REgistering DataAccess class in the Dependency Injection feature
            services.AddMvc();
            /*
            var builder = new ContainerBuilder();
            builder.RegisterType<DataAccessLayer>().As<IDataAccessLayer>();
            var container = builder.Build();

            container.Resolve<IDataAccessLayer>();
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
