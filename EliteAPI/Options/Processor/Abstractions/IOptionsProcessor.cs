using System;
using System.IO;
using System.Threading.Tasks;

namespace EliteAPI.Options.Processor.Abstractions
{
    public interface IOptionsProcessor
    {
        /// <summary>
        /// Triggered when the active bindings file is updated
        /// </summary>
        event EventHandler<string> BindingsUpdated;

        /// <summary>
        /// Hooks the specified options file to <see cref="BindingsUpdated" /> and invokes <see cref="BindingsUpdated" /> when
        /// needed
        /// </summary>
        Task ProcessBindingsFile(FileInfo bindingsFile);
    }
}