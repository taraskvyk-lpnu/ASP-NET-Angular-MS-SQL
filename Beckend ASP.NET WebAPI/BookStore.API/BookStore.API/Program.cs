using BookStore.API.DataAccess;
using BookStore.API.Infrastructure;
using BookStore.API.Infrastructure.Mappers;
using BookStore.API.Models;
using BookStore.API.Repository;
using BookStore.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BookDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        // Add services to the container.

        builder.Services.AddScoped<ValidationFilter>();
        builder.Services.AddScoped<IRepository<Book>, Repository<Book>>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<BookService>();
        
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(typeof(BookProfile));
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
        
        
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
        app.MapControllers();
        
        app.UseRouting();
        app.UseCors("AllowAll");
        app.MapGet("/", () => Results.Redirect("api/Books"));
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
