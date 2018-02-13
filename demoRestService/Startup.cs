using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using datalib;
using AutoMapper;
using demoRestService.Mapping;

namespace demoRestService
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
            services.AddCors();
            services.AddMvc();
            services.AddLogging();
            services.AddOptions();

            //var connection = @"Data Source=DESKTOP-4TKAUJ1\SQLEXPRESS;Initial Catalog=testdb;Integrated Security=True";
            //services.AddDbContext<DemoContext>(options => options.UseSqlServer(connection));
            
            services.AddDbContext<DemoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestDatabase")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors(bulder => bulder.AllowAnyOrigin());
        }
    }
}
