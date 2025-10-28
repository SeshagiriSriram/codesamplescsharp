
using Microsoft.EntityFrameworkCore;

namespace WebAPIProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add configuration for MySettings 
            
            builder.Services.Configure<MySettings>(builder.Configuration.GetSection("MySettings"));
            Console.WriteLine("Setting up DB Context");
            Console.WriteLine($"Connection String: {builder.Configuration.GetConnectionString("DefaultConnection")}");
            // Why do we need this line?    
            SQLServerContext.SetConfiguration(builder.Configuration);
            //builder.Services.AddDbContext<SQLServerContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  
            builder.Services.AddDbContext<SQLServerContext>(); // No options needed

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
