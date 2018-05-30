using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using ScaffoldCore.Composition;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ScaffoldCore.Service.Filters;
using ScaffoldCore.Service.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace ScaffoldCore.Service
{
	public class Startup
	{
		public IContainer ApplicationContainer { get; private set; }

		public IConfigurationRoot Configuration { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		/// <param name="env">The env.</param>
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Path.Combine(env.ContentRootPath, @"Configuration"))
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddJsonFile($"containerOptions.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"containerOptions.{env.EnvironmentName}.json", optional: true);

			builder.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns></returns>
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();
			services.Configure<ContainerOptions>(Configuration);
			var settings = Configuration.Get<ContainerOptions>();

			services
				.AddMvc(mvcOptions =>
				{
					mvcOptions.Filters.Add(new ModelstateValidationFilter());
					mvcOptions.Filters.Add(new HandledResultFilter());
				})
				.AddJsonOptions(jsonOptions =>
				{
					jsonOptions.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
				});

			var corsBuilder = new CorsPolicyBuilder();
			//corsBuilder.AllowAnyHeader();
			//corsBuilder.AllowAnyMethod();
			//corsBuilder.AllowAnyOrigin();
			//corsBuilder.AllowCredentials();
			corsBuilder.WithOrigins(settings.CORS.Origins);
			services.AddCors(opts => { opts.AddPolicy(settings.CORS.PolicyName, corsBuilder.Build()); });

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "ScaffoldCore", Version = "v1" });
			});

			var installer = new ContainerInstaller(settings);
			var builder = installer.Install();

			builder.Populate(services);
			ApplicationContainer = builder.Build();

			return new AutofacServiceProvider(ApplicationContainer);
		}

		/// <summary>
		/// Configures the specified application.
		/// </summary>
		/// <param name="app">The application.</param>
		/// <param name="env">The env.</param>
		/// <param name="loggerFactory">The logger factory.</param>
		/// <param name="appLifeTime">The application life time.</param>
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifeTime)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScaffoldCore");
				c.InjectStylesheet("/swagger-ui/theme.css");
				c.DocExpansion(DocExpansion.None);
			});

			app.UseMiddleware<SampleMiddleware>();
			app.UseMvc();
			app.UseStaticFiles();

			appLifeTime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
		}
	}
}
