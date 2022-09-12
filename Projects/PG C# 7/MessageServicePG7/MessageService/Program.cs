using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MessageService
{
    /// <summary>
    /// Основной класс для запуска.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Основной метод Main для работы с программой.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Создать хоста.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
