namespace HarunProjectAPI.SetupProgram
{
    public class MyConfiguration
    {
        public string[] Arguments { get; set; } = Array.Empty<string>();
        public string CorsPolicy { get; set; } = "DefaultCorsPolicy";
        public string ConnectionString { get; set; } = string.Empty;

    }
}
