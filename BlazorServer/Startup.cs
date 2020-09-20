using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorServer.Data;

namespace BlazorServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            /* ConfigureServices method(), Mengonfigurasi aplikasi DI (Dependenct Injection) yaitu layanan injeksi ketergantungan. 
             * Misalnya metode AddServerSideBlazor () menambahkan layanan sisi server Blazor. 
             * 
             * Pada antarmuka IServiceCollection ada beberapa metode yang dimulai dengan kata Tambah
             * Metode ini menambahkan layanan yang berbeda untuk aplikasi Blazor.
             * Kami bahkan dapat menambahkan layanan kami sendiri ke kontainer DI (Dependenct Injection).
             */
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /* Configure method(), Mengonfigurasi pipeline pemrosesan permintaan aplikasi.
             * Bergantung pada apa yang kita ingin aplikasi Blazor lakukan, kita menambah atau menghapus komponen middleware masing-masing dari pipa pemrosesan permintaan
             * Misalnya, metode UseStaticFiles () menambahkan komponen middleware yang dapat menyimpan file statis seperti gambar, css, dll.
             */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // MapBlazorHub(), mengatur titik akhir untuk koneksi SignalR dengan browser klien.
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
