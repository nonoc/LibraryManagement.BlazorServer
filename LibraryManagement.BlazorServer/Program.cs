using LibraryManagement.BlazorServer.Data;
using LibraryManagement.BlazorServer.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Specify the type argument explicitly to resolve CS0411  
            builder.Services.AddDbContext<AppDbContext>(options => 
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));            

            builder.Services.AddScoped<IBookService, BookService>();

            builder.Services.AddControllers();

            // --- Swagger setup ---
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.  
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.  
                app.UseHsts();              
            }
            else
            {
                app.UseDeveloperExceptionPage();
                // Enable Swagger in dev
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API v1");
                    c.RoutePrefix = "swagger"; // Serve at /swagger
                });
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}
