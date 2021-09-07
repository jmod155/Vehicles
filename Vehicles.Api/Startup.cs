using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Vehicles.Api.Data;
using Vehicles.Api.Data.Entities;
using Vehicles.Api.Helpers;

namespace Vehicles.Api
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
            services.AddControllersWithViews();

            //manejo de usuarios 
            services.AddIdentity<User, IdentityRole>(x =>
            {
                //x.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                //x.SignIn.RequireConfirmedEmail = true; 
                x.User.RequireUniqueEmail = true;//un solo email no se puede repetir
                x.Password.RequireDigit = false; //al menos un digito 
                x.Password.RequiredUniqueChars = 0; //requiere caracteres unicos
                x.Password.RequireLowercase = false;//requiere 
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<DataContext>();//nuestros passwoer se tienene en el datacontext
            //inyeccion de dependencias   de la base de datos
            services.AddDbContext<DataContext>(x =>
           {
               x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
           }
            );
            //inyeccion de la clase seedDB AddTransient = se usa una sola vez
            services.AddTransient<SeedDb>();
            //inyectamos el helper para el manejo de usuarios  AddScoped inyectar y el ciclo de vida es cuando se llame y lo destruye de una
            services.AddScoped<IUserHelper, UserHelper>();
            //services.AddSingleton el siclo de vida es todo el tiempo
            // services.AddSingleton
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //se agrega la autenticacion
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
