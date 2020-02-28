using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using shop.Web.Data;
using shop.Web.Data.Entities;
using shop.Web.Helpers;

namespace shop.Web
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
        {// aqui le estoy diciendo que voy a utilizar mi clase user.. y tambien la clas de .net core
            // le vamos a decir como queremos nuestra contraseña
            // las restricciones que le vamos a dar a nuestra contraseña
            services.AddIdentity<User, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                cfg.Password.RequireDigit = false;
                cfg.Password.RequiredUniqueChars = 0;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequiredLength = 6;
            })

           .AddEntityFrameworkStores<DataContext>();


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // aqui estoy haciendo la conexion a mi base de datos que tengo por defecto
            // el string de conexion es default conexion.. asi es como se llama en el JSON
            services.AddDbContext<DataContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //aqui le estoy inyectando datos a la base de datos si no tengo ningun registro
            services.AddTransient<SeedDb>();

            // Addscoped se usa y se mantiene la inyeccion de los datos
            services.AddScoped<IRepository, Repository>();

            //cada que instancie la clase tiene que inyectar.. y con que implementacion tiene que inyectarle
            services.AddScoped<IUserHelper, UserHelper>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // cuando yo corra mi projecto.. el seeder me crea ese usuario  y ese userAutenthication 
            //me permite utilizar User
            app.UseAuthentication();

            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
