using EmployeeRecords.Database.Data;
using EmployeeRecords.Repositories.AllRepositories;
using EmployeeRecords.Repositories.Contracts.AllContracts;
using EmployeeRecords.Services.AllServices;
using EmployeeRecords.Services.Contracts.AllContracts;
using Microsoft.EntityFrameworkCore;

namespace _09_EmployeeRecordsManagementCopyTwoProj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationConnectionString")));
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IUnitRepository, UnitRepository>();
            builder.Services.AddScoped<IUnitManager, UnitManager>();

            var app = builder.Build();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
