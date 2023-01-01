using System.Reflection;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
    }
}

public static class Helper
{
    public static string GetResource(string name)
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}