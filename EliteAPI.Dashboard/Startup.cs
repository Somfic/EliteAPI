using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using EliteAPI;
using EliteAPI_app.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EliteAPI_app
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS
            services.AddCors();
            
            // Add EliteAPI
            services.AddEliteAPI();
            
            // Add frontend files
            services.AddSpaStaticFiles(spa =>
            {
                spa.RootPath = "frontend/dist";
            });
            
            // Add WebSocket handlers
            services.AddWebSocketHandshake();

            services.AddElectron();
            
            Task.Run(async () =>
            {
                // Electron.Tray.SetImage("https://github.com/EliteAPI/Icons/blob/main/logo.png?raw=true");
                // Electron.Tray.SetTitle("EliteAPI");
                // Electron.Tray.Show("https://github.com/EliteAPI/Icons/blob/main/logo.png?raw=true");
                // Electron.Tray.SetToolTip("EliteAPI");
                
                Electron.NativeTheme.SetThemeSource(ThemeSourceMode.Dark);
                // Electron.Menu.SetApplicationMenu(new List<MenuItem>().ToArray());
                await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
                {
                    MinHeight = 500,
                    MinWidth = 500,
                    Title = "EliteAPI",
                    TitleBarStyle = TitleBarStyle.hiddenInset,
                    DarkTheme = true,
                    BackgroundColor = "#000",
                    AutoHideMenuBar = true
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Show exceptions if we're developing
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            // Redirect to Https
            app.UseHttpsRedirection();
            
            // Allow for CORS   
            app.UseCors(builder => builder.WithOrigins($"http://localhost:{BridgeSettings.WebPort}"));

            // Allow and handle websockets
            app.UseWebSockets();
            app.UseWebSocketHandshake();

            // Setup the Api
            // app.UseRouting();
            // app.UseEndpoints(endpoints => endpoints.MapControllers());
            
            // Host the frontend
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                // Use localhost instead when developing
                if(env.IsDevelopment())
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
            });
        }
    }
}