
using Auto.Driving.Car.Api.Interface;
using Auto.Driving.Car.Infrastructure;
using Auto.Driving.Car.Services;
using Microsoft.EntityFrameworkCore;

namespace Auto.Driving.Car
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
            builder.Services.AddSingleton<ICarService, CarService>();
            builder.Services.AddDbContext<ApplicationDbContext>((ServiceProvider, options) =>
            {
                options.UseSqlServer(builder.Configuration["Database:ConnectionStrings:ApplicationContext"],
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.CommandTimeout(builder.Configuration.GetValue("Database:CommandTimeout", 30));
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: int.Parse(builder.Configuration["Database:MaxRetryCount"]!)
                        , maxRetryDelay: TimeSpan.FromSeconds(int.Parse(builder.Configuration["Database:MaxRetryDelaySeconds"]!))
                        , errorNumbersToAdd: null);
                });
            });

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
