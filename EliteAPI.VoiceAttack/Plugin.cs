using System;
using System.IO;
using System.Reflection;
using EliteAPI.VoiceAttack.Proxy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EliteAPI.VoiceAttack
{
    public static class Plugin
    {
        private static Core? _core;
        private static IHost? _host;

        public static Guid VA_Id() => new Guid("189a4e44-caf1-459b-b62e-fabc60a12986");
        
        public static string VA_DisplayName() => "EliteAPI";
        
        public static string VA_DisplayInfo() => "EliteAPI by Somfic";
        
        public static void VA_Init1(dynamic vaProxy)
        {
            try
            {
                if (_core == null)
                    CreateCore(vaProxy);

                _host!.Services.GetRequiredService<VoiceAttackProxy>().SetProxy(vaProxy);
                _core!.OnInitialise();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", $"{DateTime.Now} - Could not initialise - {ex}\n");
            }
        }

        public static void VA_Exit1(dynamic vaProxy)
        {
            try
            {
                if (_core == null)
                    CreateCore(vaProxy);

                _host!.Services.GetRequiredService<VoiceAttackProxy>().SetProxy(vaProxy);
                _core!.OnExit();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", $"{DateTime.Now} - Could not exit - {ex}\n");
            }
         
        }

        public static void VA_StopCommand()
        {
            _core?.OnStopCommand();
        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            try
            {
                if (_core == null)
                    CreateCore(vaProxy);

                _host!.Services.GetRequiredService<VoiceAttackProxy>().SetProxy(vaProxy);
                _core!.OnInvoke();
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", $"{DateTime.Now} - Could not invoke - {ex}\n");
            }
        }

        private static void CreateCore(dynamic proxy)
        {
            try
            {
                var pluginPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                File.WriteAllText("HELLO.txt", "HELLO");
                
                _host = Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddEliteApi();
                        services.AddSingleton<VoiceAttackProxy>();
                    })
                    .ConfigureLogging(log =>
                    {
                        log.ClearProviders();
                        VoiceAttackLoggerBuilderExtensions.AddVoiceAttack(log, proxy);
                        log.SetMinimumLevel(LogLevel.Debug);
                    })
                    .ConfigureAppConfiguration(config => { config.AddIniFile(pluginPath + "/EliteAPI.ini"); })
                    .Build();

                _core = ActivatorUtilities.CreateInstance<Core>(_host.Services);
            }
            catch (Exception ex)
            {
                File.AppendAllText("error.log", $"{DateTime.Now} - Could not create host - {ex}\n");
            }
        }
    }
}