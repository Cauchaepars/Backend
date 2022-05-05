using ITRR.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System.IO;

namespace Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			//запуск пиложения
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args)
		{

			var config = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json")
			   .Build();

			return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseUrls($"http://0.0.0.0:{config.GetValue<int>("Port")}");
				webBuilder.UseStartup<Startup>();
				webBuilder.UseKestrel();
			})
			.ConfigureLogging(logging =>
			{
				logging.AddConsole();
			})
			.UseNLog();

		}

	}
}
