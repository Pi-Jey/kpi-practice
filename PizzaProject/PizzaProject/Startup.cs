using PizzaProject.Dao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaProject.Model.Cafe;
using PizzaProject.Orchestrators.Cafe;
using Microsoft.EntityFrameworkCore;
using PizzaProject.Cafe.Contract;
using PizzaProject.Dao.Cafe;

namespace PizzaProject
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
            services.AddAutoMapper(typeof(CafeProfile));
            services.AddControllers();
            services.AddDbContext<CafeDbContext>(o => o.UseSqlServer($@"Data Source=WIN-S5EIK5H8PME\SQLEXPRESS;Initial Catalog=PizzaProject;Integrated Security=True"));
            services.AddScoped<ICafeService, CafeService>();
            services.AddScoped<ICafeRepository, CafeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
