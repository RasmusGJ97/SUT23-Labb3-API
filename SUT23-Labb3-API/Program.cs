
using Microsoft.EntityFrameworkCore;
using SUT23_Labb3_API.Data;
using SUT23_Labb3_API.Models;
using SUT23_Labb3_API.Services;

namespace SUT23_Labb3_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddScoped<ILabb3<InterestPersonLink>, IPLRepository>();
            builder.Services.AddScoped<ILabb3<Person>, PersonRepository>();
            builder.Services.AddScoped<ILabb3<Interest>, InterestRepository>();
            builder.Services.AddScoped<ILabb3<Link>, LinkRepository>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
