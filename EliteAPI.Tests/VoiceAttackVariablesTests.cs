using EliteVA.Variables;
using FluentAssertions;

namespace EliteAPI.Tests;

public class VoiceAttackVariablesTests
{
    public sealed class StubProxy
    {
        public void SetInt(string name, int? value) { }
        public void SetSmallInt(string name, short? value) { }
        public void SetText(string name, string? value) { }
        public void SetDecimal(string name, decimal? value) { }
        public void SetBoolean(string name, bool? value) { }
        public void SetDate(string name, DateTime? value) { }

        public int? GetInt(string name) => null;
        public short? GetSmallInt(string name) => null;
        public string? GetText(string name) => null;
        public decimal? GetDecimal(string name) => null;
        public bool? GetBoolean(string name) => null;
        public DateTime? GetDate(string name) => null;
    }

    [Fact]
    public async Task Set_FromMultipleThreads_DoesNotThrow()
    {
        var variables = new VoiceAttackVariables(new StubProxy());

        const int threadCount = 4;
        const int iterationsPerThread = 2_500;

        var ready = new CountdownEvent(threadCount);
        using var start = new ManualResetEventSlim(false);
        var exceptions = new System.Collections.Concurrent.ConcurrentQueue<Exception>();

        var tasks = new Task[threadCount];
        for (var t = 0; t < threadCount; t++)
        {
            var threadId = t;
            tasks[t] = Task.Run(() =>
            {
                ready.Signal();
                start.Wait();

                for (var j = 0; j < iterationsPerThread; j++)
                {
                    try
                    {
                        variables.Set($"EliteAPI.Repro.{threadId}.{j}", j.ToString(), TypeCode.Int32);
                    }
                    catch (Exception ex)
                    {
                        exceptions.Enqueue(ex);
                    }
                }
            });
        }

        ready.Wait();
        start.Set();
        await Task.WhenAll(tasks);

        exceptions.Should().BeEmpty(
            $"concurrent Set calls must be thread-safe (saw {exceptions.Count} of {threadCount * iterationsPerThread} iterations throw)");
    }
}
