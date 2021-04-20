using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Diagnostics;
using dotnet5api.Repositories;
using Microsoft.EntityFrameworkCore;
using dotnet5api.Data;

namespace dotnet5api
{
  public class Startup
  {
    private readonly IWebHostEnvironment env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Configuration = configuration;
      this.env = env;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      // services.AddEntityFramework();
      services.AddDbContext<HyperdriveDbContext>(opts =>
      {
        // Console.WriteLine(env.ContentRootPath);
        opts.UseSqlite($"Data Source={env.ContentRootPath}/Hyperdrive.db;", dbOpts => { });
      });

      // DbInitializer.Initialize(new HyperdriveDbContext());
      // services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
      services.AddScoped<ICarRepository, CarRepository>();
      services.AddScoped<ICarAttributesRepository, CarAttributesRepository>();
      // services.AddSingleton<IManufacturerRepository, InMemoryManufacturerRepository>();
      // services.AddSingleton<ICarRepository, InMemoryCarRepository>();

      services.AddCors(opts => { });
      services.AddResponseCaching(opts =>
      {
        opts.SizeLimit = 4096;
      });
      services.AddResponseCompression(opts => { });

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnet5api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnet5api v1"));

        app.Use(next => async (context) =>
        {
          Stopwatch s = new();
          s.Start();
          context.Response.OnStarting((state) =>
               {
                 s.Stop();
                 context.Response.Headers.Add("Server-Timing", $"processingTime;dur={s.ElapsedMilliseconds}");
                 //  context.Response.Headers.Remove("Server");
                 return Task.FromResult(0);
               }, context);

          await next(context);

          Console.Write($"{context.Response.StatusCode} ");
          Console.Write($"{context.Request.Path.Value} ");
          Console.Write($"{s.ElapsedMilliseconds} ms");
          Console.WriteLine();
          s.Stop();
          // return Task.CompletedTask;
        });
      }

      // app.UseHttpsRedirection();

      app.UseCors(opts =>
      {
        opts.AllowAnyOrigin();
      });
      app.UseResponseCaching();
      app.UseResponseCompression();

      app.UseRouting();

      app.UseAuthorization();


      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
