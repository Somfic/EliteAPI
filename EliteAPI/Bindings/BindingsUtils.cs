using System;
using System.IO;

public class BindingsUtils
{
    public static DirectoryInfo GetBindingsDirectory()
    {
        return new DirectoryInfo(Path.Combine(GetOptionsDirectory().FullName, "Bindings"));
    }

    private static DirectoryInfo GetOptionsDirectory()
    {
        var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return new DirectoryInfo(Path.Combine(localAppData, "Frontier Developments", "Elite Dangerous", "Options"));
    }
}
