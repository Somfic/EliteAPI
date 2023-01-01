namespace EliteAPI.Abstractions.Readers;

public class BindingsFileSelector : IFileSelector
{
    private readonly DirectoryInfo _directory;

    public BindingsFileSelector(DirectoryInfo directory)
    {
        _directory = directory;
    }
    
    public bool IsMultiLine => false;
    
    public FileCategory Category => FileCategory.Bindings;
    
    public FileInfo GetFile()
    {
        // Find the StartPreset file
        var startPresetFile =
            _directory.GetFiles("StartPreset*").OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
         
        if (startPresetFile == null)
            throw new FileNotFoundException($"The bindings StartPreset file could not found at '{_directory.FullName}'");

        var bindingFiles = File.ReadAllLines(startPresetFile.FullName);
         
        // Check that all are the same
        if (bindingFiles.Distinct().Count() != 1)
            throw new Exception("Mix of different keybindings presets detected. Please make sure you use the same keybindings preset for the different categories.");
         
        // Get the binding file
        var pattern = bindingFiles[0];
        
        if(pattern == "KeyboardMouseOnly")
            throw new Exception("Default keybindings are not supported. Please use a custom keybinding preset.");
         
        pattern += "*.binds";
        
        // Find the file
        var bindingFile = _directory.GetFiles(pattern).OrderByDescending(x => x.LastWriteTime).FirstOrDefault();

        if (bindingFile == null)
            throw new FileNotFoundException($"The bindings '{pattern}' file could not found at '{_directory.FullName}'");
            
        return bindingFile;
    }
}