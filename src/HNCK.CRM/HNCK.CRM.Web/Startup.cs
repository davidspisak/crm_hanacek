using HNCK.CRM.Common;
using HNCK.CRM.InfrastructureServices.Logging.DBLogger;
using HNCK.CRM.InfrastructureServices.Logging.FileLogger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HNCK.CRM.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			var appSettings = new ConfigurationBuilder()
				.SetBasePath(System.IO.Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
			AppSettings.Instance = appSettings.GetSection("App").Get<AppSettings>();
			AppSettings.Instance.ApplicationVersion = typeof(Startup).Assembly.GetName().Version.ToString();

			Directory.CreateDirectory(AppSettings.Instance.LogPath);
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.AddHttpContextAccessor();
			services.AddControllersWithViews()
				.AddViewLocalization()
				.AddDataAnnotationsLocalization();
			services.AddMvc(setupAction => {
				setupAction.EnableEndpointRouting = false;
			}).AddJsonOptions(jsonOptions =>
			{
				jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
			})
			.SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
			services.AddKendo();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
		{
			var configuration = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();


			loggerFactory.AddProvider(new FileLoggerProvider(
				new FileLoggerConfig()
				{
					Configuration = configuration,
					EnableLogToFile = AppSettings.Instance.AppLogger.EnableLogToFile	
				}, httpContextAccessor));

			loggerFactory.AddProvider(new DbLoggerProvider(
				new DbLoggerConfig()
				{
					ConnectionString = AppSettings.Instance.DbOptions.ConnectionString,
					EnableLogToDb = AppSettings.Instance.AppLogger.EnableLogToDb,
					PostgreSqlProvider = AppSettings.Instance.AppLogger.PostgreSqlProvider
				}, httpContextAccessor));

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			var supportedCultures = new[] { "en-US" };
			var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
				.AddSupportedCultures(supportedCultures)
				.AddSupportedUICultures(supportedCultures);
			app.UseRequestLocalization(localizationOptions);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Subject}/{action=Index}/{id?}");
			});
		}
	}
}
