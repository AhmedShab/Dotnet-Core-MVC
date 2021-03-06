﻿using DotnetSimpleMVC.Models;
using DotnetSimpleMVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace DotnetSimpleMVC
{
	public class Startup
	{
		private IHostingEnvironment _env;
		private IConfigurationRoot _config;

		public Startup(IHostingEnvironment env)
		{
			_env = env;

			var builder = new ConfigurationBuilder()
				.SetBasePath(_env.ContentRootPath)
				.AddJsonFile("config.json")
				.AddEnvironmentVariables();

			_config = builder.Build();
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			if (_env.IsDevelopment())
			{
				services.AddScoped<IMailService, DebugMailService>();
			}

			services.AddMvc();
			services.AddDbContext<WorldContext>();
			services.AddSingleton(_config);
			services.AddTransient<WorldContentSeedData>();
			services.AddScoped<IWorldRepository, WorldRepository>();
			services.AddLogging();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, WorldContentSeedData seeder)
		{
			loggerFactory.AddConsole();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				loggerFactory.AddDebug(LogLevel.Information);
			}

			loggerFactory.AddDebug(LogLevel.Error);

			app.UseStaticFiles();

			app.UseMvc(config =>
			{
				config.MapRoute(
					name: "Default",
					template: "{controller}/{action}/{id?}",
					defaults: new { Controller = "App", action = "Index" }
					);
			});

			seeder.EnsureSeedData().Wait();
		}
	}
}
