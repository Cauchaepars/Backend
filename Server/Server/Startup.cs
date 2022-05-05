using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ITRR.Database;
using Microsoft.EntityFrameworkCore;
using ITRR.Database.Repositories.ComputerInfoRepository;
using ITRR.Database.Repositories.CPURepository;
using ITRR.Database.Repositories.GPURepository;
using ITRR.Database.Repositories.HDDRepository;
using ITRR.Database.Repositories.MotherBoardRepository;
using ITRR.Database.Repositories.ProgrammsRepository;
using ITRR.Database.Repositories.RAMRepository;
using ITRR.Database.Repositories.SSDRepository;
using ITRR.Database.Repositories.USBDevicesRepository;
using ITRR.Database.Repositories.AgentRepository;
using ITRR.Database.Repositories.NetworkCardRepository;
using System;

namespace Server
{
	public class Startup
	{
		private readonly string _corsPolicy = "AskBmstuFm";
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			//Кофигурация
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEntityFrameworkNpgsql().AddDbContext<ITRRDbContext>(options =>
				options.UseNpgsql(Configuration.GetConnectionString("ITRR"))
			);

			services.AddTransient<IAgentRepository, AgentRepository>();
			services.AddTransient<INetworkCardRepository, NetworkCardRepository>();
			services.AddTransient<IComputerInfoRepository, ComputerInfoRepository>();
			services.AddTransient<ICPURepository, CPURepository>();
			services.AddTransient<IGPURepository, GPURepository>();
			services.AddTransient<IHDDRepository, HDDRepository>();
			services.AddTransient<IMotherBoardRepository, MotherBoardRepository>();
			services.AddTransient<IProgrammsRepository, ProgrammsRepository>();
			services.AddTransient<IRAMRepository, RAMRepository>();
			services.AddTransient<ISSDRepository, SSDRepository>();
			services.AddTransient<IUSBDevicesRepository, USBDevicesRepository>();

			services.AddControllers();
			services.AddHealthChecks();
			services.AddCors(o => o.AddPolicy(_corsPolicy, builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			}));


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			UpdateDatabase(app);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseCors(_corsPolicy);
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		private void UpdateDatabase(IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
			using var context = serviceScope.ServiceProvider.GetService<ITRRDbContext>();
			context.Database.Migrate();
			context.Database.EnsureCreated();
		}
	}
}
