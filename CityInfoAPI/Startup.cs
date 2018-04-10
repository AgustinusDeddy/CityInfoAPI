using CityInfoAPI.Core.Repository;
using CityInfoAPI.Entities;
using CityInfoAPI.Models;
using CityInfoAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CityInfoAPI
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
      services.AddMvc(setupAction =>
          {
            setupAction.ReturnHttpNotAcceptable = true;
            setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            setupAction.InputFormatters.Add(new XmlDataContractSerializerInputFormatter());
          })
          .AddJsonOptions(options =>
              {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
              }
          );

      var connectionString = Configuration["connectionStrings:cityInfoDBConnectionString"];
      services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));

      services.AddScoped<ICityInfoRepository, CityInfoRepository>();

      services.AddTransient<ICityInfoContextInitializer, CityInfoContextInitializer>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, CityInfoContext cityInfoContext)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler(appBuilder =>
        {
          appBuilder.Run(async context =>
                  {

              context.Response.StatusCode = 500;
              await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
            });
        });
      }

      AutoMapper.Mapper.Initialize(cfg =>
      {
        cfg.CreateMap<City, CityDto>();
      });

      //cityInfoContext.EnsureSeedDataForContext();

      app.UseMvc();
    }
  }
}
