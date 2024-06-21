using Cliente.ConsultaAPI.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace Cliente
{
    internal static class Program
    {
        public static IConfigurationRoot Configuration { get; private set; } = null!;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
            var services = host.Services;
            CultureInfo ci = new CultureInfo("es-ES");
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;

            var mainForm = services.GetRequiredService<FrmConsumo>();

            System.Windows.Forms.Application.Run(mainForm);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, configuration) =>
        {
            configuration.Sources.Clear();
            configuration
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) ;

            IConfigurationRoot configurationRoot = configuration.Build();

            Configuration = configurationRoot;

        })
       .ConfigureServices((services) =>
       {
           
           services.AddApiClient(options =>
           {
               options.AuthToken = "";
               options.BaseUrl = Configuration.GetValue<string>("ApiAlgoritmo");
           });
           

           services.AddSingleton<IFormFactory, FormFactory>();


           var forms = typeof(Program).Assembly
           .GetTypes()
           .Where(t => t.BaseType == typeof(Form))
           .ToList();

           forms.ForEach(form =>
           {
               services.AddTransient(form);
           });

       });
    }
}