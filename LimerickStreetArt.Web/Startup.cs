using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimerickStreetArt.Web.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LimerickStreetArt.Repository;
using LimerickStreetArt.MySQL;

namespace LimerickStreetArt.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			var databaseClass = new DatabaseClass
			{
				ConnectionString = Configuration.GetConnectionString("LocalDatabase"),
			};
			var streetArtRepository = new StreetArtRepositoryClass(databaseClass);
			var userAccountRepository = new UserAccountRepositoryClass(databaseClass);

			services.AddSingleton<StreetArtRepository>(streetArtRepository);
			services.AddSingleton<UserAccountRepository>(userAccountRepository);

			//services.AddAutoMapper(typeof(Startup));

			// Auto Mapper Configurations

			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AutoMapping());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app
				//.UseDefaultFiles()
				.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=" + nameof(Login) + "}/{action=" + nameof(Login.Index) + "}/{id?}");
			});
		}
	}
}
