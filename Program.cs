
using HarunProjectAPI.SetupProgram;

namespace HarunProjectAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            HarunSetup.BuildApp(new MyConfiguration
            {
                Arguments = args,
                CorsPolicy = "DefaultCorsPolicy",
                ConnectionString= "DefaultConnection"
            });
        }
    }
}
