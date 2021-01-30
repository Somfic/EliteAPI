using System.IO;
using System.Linq;
using System.Threading.Tasks;

using EliteAPI.Exceptions;
using EliteAPI.Options.Provider.Abstractions;
using EliteAPI.Services.FileReader.Abstractions;

namespace EliteAPI.Options.Provider
{
    /// <inheritdoc />
    public class OptionsProvider : IOptionsProvider
    {
        private readonly IFileReader _fileReader;

        public OptionsProvider(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        /// <inheritdoc />
        public Task<FileInfo> FindBindingsFile(DirectoryInfo optionsDirectory)
        {
            var bindingsDirectories = optionsDirectory.GetDirectories("Bindings");

            if (bindingsDirectories.Length == 0)
            {
                throw new BindingsDirectoryNotFoundException("The bindings directory could not be found");
            }

            var bindingsDirectory = bindingsDirectories.First();

            var startPresetFiles = bindingsDirectory.GetFiles("StartPreset.start");

            if (startPresetFiles.Length == 0)
            {
                throw new ActiveBindingsNotSetException("No selected bindings could be detected");
            }

            var startPresetFile = startPresetFiles.First();

            var activePresetName = _fileReader.ReadAllText(startPresetFile);

            var activePresetFiles = bindingsDirectory.GetFiles($"{activePresetName}*");

            if (activePresetFiles.Length == 0)
            {
                ActiveBindingsNotFoundException ex = new("The select bindings could not be found");
                ex.Data.Add("Active bindings", activePresetName);

                throw ex;
            }

            return Task.FromResult(activePresetFiles.First());
        }
    }
}
