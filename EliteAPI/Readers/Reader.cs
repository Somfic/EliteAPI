using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EliteAPI.Abstractions.Readers;
using EliteAPI.Abstractions.Readers.Selectors;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Readers;

public class Reader : IReader
{
    private readonly ILogger<Reader>? _log;

    private readonly IList<IFileSelector> _files = new List<IFileSelector>();
    private readonly Dictionary<string, string[]> _lastValues = new();

    public Reader(ILogger<Reader> log)
    {
        _log = log;
    }

    /// <inheritdoc />
    public void Register(IFileSelector selector)
    {
        _files.Add(selector);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<Line> FindNew()
    {
        foreach (var fileSelector in _files)
        {
            FileInfo file;
            
            try
            {
                file = fileSelector.GetFile();
              
            } catch (FileNotFoundException ex)
            {
                _log?.LogWarning(ex.Message);
                _files.Remove(fileSelector);
                yield break;
            }
            catch (Exception ex)
            {
                _log?.LogWarning(ex, "Could not query the necessary files for {FileType}", fileSelector.Category.ToString().ToLower());
                _files.Remove(fileSelector);
                yield break;
            }
            
            if(!_lastValues.ContainsKey(file.FullName))
                _lastValues.Add(file.FullName, Array.Empty<string>());

            StreamReader? stream;

            try
            {
                stream = new StreamReader(file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            }
            catch (Exception ex)
            {
                _log?.LogWarning(ex, "Could not open file {File}", file.FullName);
                continue;
            }
            
            if (fileSelector.IsMultiLine)
            {
                var newValues = new List<string>();

                stream.BaseStream.Position = 0;
                while (!stream.EndOfStream)
                {
                    newValues.Add(await stream.ReadLineAsync());
                }
                
                // Yield all new values
                foreach (var value in newValues.Except(_lastValues[file.FullName]))
                {
                    _log?.LogTrace("{File}: {Json}", file.Name, value);
                    yield return new Line(file, fileSelector, value);
                }
                
                // Update last values
                _lastValues[file.FullName] = newValues.ToArray();
            } 
            else
            {
                stream.BaseStream.Position = 0;
                var newValue = await stream.ReadToEndAsync() ?? string.Empty;
                var lastValue = string.Join(Environment.NewLine, _lastValues[file.FullName]!);

                if (newValue != lastValue)
                {
                    _log?.LogTrace("{File}: {Json}", file.Name, newValue);
                    
                    // Yield the new value
                    yield return new Line(file, fileSelector, newValue);
                    
                    // Update last value
                    _lastValues[file.FullName] = newValue.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                }
            }
        }
    }
}