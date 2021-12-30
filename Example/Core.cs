using EliteAPI.Abstractions;
using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Example;

public class Core
{
    private readonly IEliteDangerousApi _api;
    private readonly IEventUtilities _eventUtilities;
    private readonly ILogger<Core> _log;

    public Core(ILogger<Core> log, IEliteDangerousApi api, IEventUtilities eventUtilities)
    {
        _log = log;
        _api = api;
        _eventUtilities = eventUtilities;
    }

    public async Task Run()
    {
        _api.Events.Register<TestEvent>();
        _api.Events.RegisterConverter<LocalisedConverter>();

        var e = new TestEvent {Message = new Localised("Hello", "World")};

        _api.Events.OnAny(x => { _log.LogInformation("Any!"); });
        _api.Events.On<TestEvent>(OnFriendsEvent);

        _api.Events.Invoke(e);
    }

    private void OnFriendsEvent(TestEvent e)
    {
        _log.LogInformation(_eventUtilities.ToJson(e));
    }
}

internal readonly struct TestEvent : IEvent
{
    [JsonProperty("timestamp")]
    public DateTime Timestamp { get; init; }

    [JsonProperty("event")]
    public string Event { get; init; }

    [JsonProperty("message")]
    public Localised Message { get; init; }
}