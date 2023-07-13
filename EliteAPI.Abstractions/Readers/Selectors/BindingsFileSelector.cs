using System.Reflection;
using System.Runtime.CompilerServices;

namespace EliteAPI.Abstractions.Readers.Selectors;

public class BindingsFileSelector : IFileSelector
{
    private string _tempPath;
    
    private readonly DirectoryInfo _directory;
    private bool? _isOdyssey;
    private string[] _categories = { "General", "Ship", "SRV", "On foot" };

    public BindingsFileSelector(DirectoryInfo directory)
    {
        _directory = directory;
        _tempPath = Path.GetTempFileName();
    }

    public bool IsApplicable => _isOdyssey.HasValue;
    
    public bool IsMultiLine => false;
    
    public FileCategory Category => FileCategory.Bindings;
    
    public void SetIsOdyssey(bool isOdyssey)
    {
        _isOdyssey = isOdyssey;
    }
    
    public FileInfo GetFile()
    {
        // Find the StartPreset file
        var startPresetFile =
            _directory.GetFiles("StartPreset*").OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
         
        if (startPresetFile == null)
            throw new FileNotFoundException($"Selected keybindings could be be found. Make sure that you have a non-default keybindings preset selected in-game and that you have started the game at least once.");

        var presetCount = _isOdyssey!.Value ? 4 : 3;
        var bindingFiles = File.ReadAllLines(startPresetFile.FullName).Take(presetCount).ToArray();
         
        // Check that all are the same
        if (bindingFiles.Distinct().Count() != 1)
            throw new Exception($"A mix of different keybindings presets were detected ({string.Join(", ", bindingFiles.Distinct())}). Please make sure that the same keybindings preset is used for all {presetCount} keybindings categories ({string.Join(", ", _categories.Take(presetCount))}).");
         
        // Get the binding file
        var name = bindingFiles[0];
        
        var bindings = _directory.GetFiles($"*.binds");

        FileInfo? bindingsFile;
        if (bindings.Length != 0)
            bindingsFile = GenerateDefaultBindingsFile();
        else     
            bindingsFile = bindings.FirstOrDefault(x => File.ReadAllText(x.FullName).Contains($"PresetName=\"{name}\""));

        if (bindingsFile == null)
            throw new FileNotFoundException($"Could not find keybindings preset '{name}' in '{_directory.FullName}'. Make sure that you have a non-default keybindings preset selected in-game.");
            
        return bindingsFile;
    }

    private FileInfo? GenerateDefaultBindingsFile()
    {
        var assembly = GetType().Assembly;
        const string resourceName = "EliteAPI.Abstractions.Readers.Selectors.DefaultBindings.binds";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
            throw new Exception(
                $"Could not find the default bindings file '{resourceName}' in the assembly '{assembly.GetName().Name}' Resources: {string.Join(", ", assembly.GetManifestResourceNames())}");
        
        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();
     
        if (!File.Exists(_tempPath) || File.ReadAllText(_tempPath) != content)
            File.WriteAllText(_tempPath, content);
        
        return new FileInfo(_tempPath);
    }
}