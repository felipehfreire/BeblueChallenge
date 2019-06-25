using Beblue.CrossCutting.IOC;
using Beblue.WebApi.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Beblue.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.RegisterServices();
            RegisterServices(services);
            services.AddMediatR(typeof(Startup));
            // Configurações do Swagger
            services.AddSwaggerConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();


            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Web APi - Beblue Challenge");
            });
            #endregion

            #region CORS - Cross origin Request
            app.UseCors(c =>
            {
                c.AllowAnyHeader();//any header
                c.AllowAnyMethod();//any method
                c.AllowAnyOrigin();//
                //c.WithOrigins("www.meudominio.com, www.site.com")
                //c.WithMethods("GET, POST, DELETE, PUT")
            });
            #endregion
        }
        /// <summary>
        /// Register dependency injections in a respective IOC layer (DI Abstraction)
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterServices(IServiceCollection services)
        {
            BeblueIOC.RegisterServices(services);
        }
    }
}
