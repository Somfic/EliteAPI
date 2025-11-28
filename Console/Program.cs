using EliteAPI;

var api = new EliteDangerousApi();

api.Start();

api.OnAll(e =>
{
    Console.WriteLine($"Event: {e.Event}");
});

api.OnJournalChanged(e =>
{
    Console.WriteLine($"New journal file being watched: {e.FullName}");
});

// api.OnAllJson(e =>
// {
//     Console.WriteLine($"JSON Event: {e.eventName}");
// });

await Task.Delay(-1);
