
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Data.DataSeeding;
using Persistance.Repositories;
using Services;
using Services_Abstraction;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args) 
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssembleyReference).Assembly);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUniteOfWork , UniteOfWork>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddAutoMapper(typeof (Services.AssembleyReference).Assembly);
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings"));
            });
            builder.Services.AddScoped<IDbIntializer, DbIntializer>();
            //resolve for some dependcies => create scope  
            var app = builder.Build();
            await IntializerDbAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            async Task IntializerDbAsync(WebApplication app)
            {
                using var scope = app.Services.CreateScope();
                var dbintializer = scope.ServiceProvider.GetRequiredService<IDbIntializer>();
                await dbintializer.IntializeAsync();
            }

        }
    }
}
