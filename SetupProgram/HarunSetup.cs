using HarunProjectAPI.DBContext;
using Microsoft.EntityFrameworkCore;

namespace HarunProjectAPI.SetupProgram
{
    public static class HarunSetup
    {

        public static void BuildApp(MyConfiguration configuration)
        {
            var builder = WebApplication.CreateBuilder(configuration.Arguments);

            // Add services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString(configuration.ConnectionString);  


            builder.Services.AddDbContext<DBContext.DBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(configuration.CorsPolicy, policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            SetupPipeline(app, configuration.CorsPolicy);
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
