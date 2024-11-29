
using Core;
using Data;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using WebDiningRoom.ServiceExtensions;

namespace WebDiningRoom
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DiningRoomSomeeDb") ?? throw new InvalidOperationException("Connection string 'DiningRoomDbContextConnection' not found.");

            builder.Services.AddDbContext<DiningRoomDbContext>(options => options.UseSqlServer(connectionString));



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddRepository();


            builder.Services.AddCustomServices();
            builder.Services.AddAutoMapper();
            builder.Services.AddFluentValidators();


            builder.Services.AddCorsPolicies();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("front-end-cors-policy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
