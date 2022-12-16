using System;
using ImageGallery.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp.Web.Caching;
using SixLabors.ImageSharp.Web.DependencyInjection;

namespace ImageGallery
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => false;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMemoryCache();
            services.AddSession();
            services.AddImageSharp(
                //Este método configura o ImageSharp para ser implementado de acordo com os recursos necessários
                options =>
                {
                    options.BrowserMaxAge = TimeSpan.FromDays(1); //Configurando o tempo de armazenamento em cache pelo navegador
                    options.CacheMaxAge = TimeSpan.FromDays(365); //Configurando o tempo de armazenamento em cache pelo Servidor
                    options.CacheHashLength = 8; //Indica que a Hash do cache tera no máximo 8 bites
                }).Configure<PhysicalFileSystemCacheOptions>(options =>
                {
                    options.CacheFolder = "img/cache"; // Configura a pasta que armazenará as imagens em cache
                });
            services.AddSingleton<IFileProcessor, FileProcessorService>(); //Adicionando a interface que Implementamos para a manipulação das imgens de upload

        }


        // Use este método para configurar as requisições HTTP do Pipeline.

        //Crie um objeto de IWbHostEnviroment para realizar requisições arquivos e o adicione como paramêtro no metodo Configure(), crie também um ojeto de ILoggerFactory para utilizar a ferramenta de geração de logs e passe-o também como parâmetro ao metodo Configure();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logFac)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //Https
                app.UseHsts();
            }

            //Https

            //Implementando recursos do uso de sessão ao Pipeline da aplicação
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseSession();

            //dotnet dev-certs https --trust, instala um certificado HTTPS para localhost

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            //Aplicando o uso do Image Sharp ao Pipeline da aplicação
            app.UseImageSharp();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Aplicando sistema de geração de Logs através da ferramenta Serilog.Extensions.Logging.File
            logFac.AddFile("Logs/log-{Date}.txt", LogLevel.Error);
        }
    }
}