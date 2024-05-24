using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PruebaBaguerMD.Data;
using PruebaBaguerMD.Models;
using PruebaBaguerMD.Models.Interfaces;
using PruebaBaguerMD.Services;

namespace PruebaBaguerMD
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
            services.AddScoped<IGeneric<Usuario>, GenericService<Usuario>>(); 
            
            // Agregar DbContext
            services.AddDbContext<AppDBContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("ConexMysql");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            // Configuración de CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5502") // Origen permitido
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // Configuración de Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowSpecificOrigin");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
