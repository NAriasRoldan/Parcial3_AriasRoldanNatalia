using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Parcial3_AriasRoldanNatalia.DAL;
using Parcial3_AriasRoldanNatalia.DAL.Entities;
using Parcial3_AriasRoldanNatalia.Helpers;
using Parcial3_AriasRoldanNatalia.Servicies;


namespace Parcial3_AriasRoldanNatalia
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DataBaseContext>(
            o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );
            builder.Services.AddTransient<SeederDb>();
            builder.Services.AddScoped<IDropDownListHelper, DropDownListHelper>();
            builder.Services.AddScoped<IUserHelper, UserHelper>();


            builder.Services.AddIdentity<User, IdentityRole>(io =>
            {
                io.User.RequireUniqueEmail = true;
                io.Password.RequireDigit = false;
                io.Password.RequiredUniqueChars = 0;
                io.Password.RequireLowercase = false;
                io.Password.RequireNonAlphanumeric = false;
                io.Password.RequireUppercase = false;
                io.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<DataBaseContext>();


            var app = builder.Build();

            SeederData();
            void SeederData()
            {
                IServiceScopeFactory? scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (IServiceScope? scope = scopedFactory.CreateScope())
                {
                    SeederDb? service = scope.ServiceProvider.GetService<SeederDb>();
                    service.SeedAsync().Wait();
                }
            }


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}