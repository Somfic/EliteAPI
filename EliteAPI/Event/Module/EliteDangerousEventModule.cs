using EliteAPI.Abstractions;

namespace EliteAPI.Event.Module
{
    public abstract class EliteDangerousEventModule
    {
        protected readonly IEliteDangerousAPI EliteAPI;

        protected EliteDangerousEventModule(IServiceProvider services)
        {
            EliteAPI = services.GetRequiredService<IEliteDangerousAPI>();
        }
    }
}