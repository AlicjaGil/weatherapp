namespace WeatherApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            
            var port = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5000";

            app.Logger.LogInformation("=== START APLIKACJI ===");
            app.Logger.LogInformation("Data uruchomienia: {time}", DateTime.Now);
            app.Logger.LogInformation("Autor: Alicja Gil");
            app.Logger.LogInformation("Port: {port}", port);
            app.Logger.LogInformation("=======================");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Weather}/{action=Index}/{id?}");
            });

            app.MapGet("/health", () => "OK");

            app.Run();
        }
    }
}