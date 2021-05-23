using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaProject.Onion.CafeContract;
using PizzaProject.Onion.PizzaContract;
using PizzaProject.Data;
using PizzaProject.Core.Cafe;
using PizzaProject.Orchestrators.Cafe;
using PizzaProject.Data.Cafe;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Core.Pizza;
using PizzaProject.Data.Pizza;
using PizzaProject.Orchestrators.Pizza;

namespace PizzaProject.Onion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CafeProfile));
            services.AddAutoMapper(typeof(PizzaProfile));
            services.AddControllers();
            services.AddDbContext<PizzaProjectContext>(o => o.UseSqlServer($@"Data Source=WIN-S5EIK5H8PME\SQLEXPRESS;Initial Catalog=PizzaProject;Integrated Security=True"));
            services.AddScoped<ICafeService, CafeService>();
            services.AddScoped<ICafeRepository, CafeRepository>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bank.Onion v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
