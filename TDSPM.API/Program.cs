
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TDSPM.API.Application.UseCases;
using TDSPM.API.Domain.Entity;
using TDSPM.API.Infrastructure.Context;
using TDSPM.API.Infrastructure.Persistence.Repositories;

namespace TDSPM.API
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
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration["Swagger:Title"],
                    Description = "API DA AULA DE .NET",
                    Contact = new OpenApiContact
                    {
                        Email = "profthiago.vicco@fiap.com.br",
                        Name = "Thiago Keller"
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";  //2TDSPM.API.xml
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); /*C:/dev/2tdspm/2TDSPM.API.xml*/

                //incluir os comentarios no SWAGGER
                swagger.IncludeXmlComments(xmlPath);
            });


            builder.Services.AddDbContext<CarContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleCar"));
            });

            builder.Services.AddScoped<IRepository<Car>, Repository<Car>>(); 
            builder.Services.AddScoped<IRepository<Brand>, Repository<Brand>>();


            builder.Services.AddScoped<CarUserCase>();

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
