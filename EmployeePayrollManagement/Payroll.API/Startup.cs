using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Payroll.API.ExceptionHandling;
using Payroll.API.Misc;
using Payroll.BL.Repositories;
using Payroll.DAL;
using Payroll.DAL.Repositories.CommandRepositories;
using Payroll.DAL.Repositories.QueryRepositories;
using Payroll.Services.ConcreteServices;
using Payroll.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll.API
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
            services.AddControllers();
            services.AddDbContext<PayrollDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("Default"),x=>x.MigrationsAssembly("Payroll.DAL")));
            //Injection
            services.AddTransient<IClientRetrieveRepository, ClientQueryRepository>();
            services.AddTransient<IClientSaveRepository, ClientCommandRepository>();

            services.AddTransient<IDepartmentRetriveRepository, DepartmentQueryRepository>();
            services.AddTransient<IDepartmentSaveRepository, DepartmentCommandRepository>();

            services.AddTransient<IEmployeeCommandRepository, EmployeeCommandRepository>();
            services.AddTransient<IEmployeeQueryRepository, EmployeeQueryRepository>();
            services.AddTransient<IRequestAuditCommandRepository, RequestAuditCommandRepository>();
            services.AddTransient<IDepartmentService, DepartmentServices>();
            services.AddTransient<IClientServices, ClientServices>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            //Swagger Code
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Payroll", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestAudit();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c=>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payroll V1");
            });

        }
    }
}
