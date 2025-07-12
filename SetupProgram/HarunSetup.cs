using HarunProjectAPI.DBContext;
using HarunProjectAPI.Services.Default;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HarunProjectAPI.SetupProgram
{
    public static class HarunSetup
    {

        public static void BuildApp(MyConfiguration configuration)
        {
            var builder = WebApplication.CreateBuilder(configuration.Arguments);

            var connectionString = builder.Configuration.GetConnectionString(configuration.ConnectionString); 
            var services=builder.Services;

            //Add services to the DI container
            AddServices(services, connectionString, configuration.CorsPolicy);

            var app = builder.Build();

            SetupPipeline(app, configuration.CorsPolicy);
        }


        private static void AddServices(IServiceCollection services,string? connectionString,string corsPolicy)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<DBContext.DBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(corsPolicy, policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });
            services.AddScoped(typeof(IDefaultService<>), typeof(DefaultService<>));
        }   

        private static void SetupPipeline(WebApplication app,string corsPolicy)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseCors(corsPolicy);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
