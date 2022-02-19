using System;
using System.Threading.Tasks;

namespace EliteAPI.VoiceAttack.Proxy.Commands
{
    public class VoiceAttackCommands
    {
        private readonly dynamic _proxy;

        internal VoiceAttackCommands(dynamic proxy, IServiceProvider services = null)
        {
            _proxy = proxy;
        }

        /// <summary>
        /// The total amount of commands executed in this session
        /// </summary>
        public int TotalExecuted => _proxy.Command.ExecutionCount();

        /// <summary>
        /// The last executed command
        /// </summary>
        public string LastExecuted => _proxy.Command.LastSpoken();

        /// <summary>
        /// The previous executed command
        /// </summary>
        public string PreviousExecuted => _proxy.Command.PreviousSpoken();

        /// <summary>
        /// Enables or disables a command for this session
        /// </summary>
        /// <param name="name">The name of the command</param>
        /// <param name="isEnabled">Whether the command should be enabled or disabled</param>
        public Task SetEnabledForThisSession(string name, bool isEnabled)
        {
            _proxy.Command.SetSessionEnabled(name, isEnabled);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Enables or disables a command for this session
        /// </summary>
        /// <param name="identifier">The identifier of the command</param>
        /// <param name="isEnabled">Whether the command should be enabled or disabled</param>
        public Task SetEnabledForThisSession(Guid identifier, bool isEnabled)
        {
            _proxy.Command.SetSessionEnabled(identifier, isEnabled);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Enables or disables a category for this session
        /// </summary>
        /// <param name="name">The name of the category</param>
        /// <param name="isEnabled">Whether the category should be enabled or disabled</param>
        public Task SetEnabledCategoryForThisSession(string name, bool isEnabled)
        {
            _proxy.Command.SetSessionEnabledByCategory(name, isEnabled);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Checks a command on whether it is temporarily enabled or disabled
        /// </summary>
        /// <param name="name">The name of the command</param>
        public Task<bool> GetEnabledForThisSession(string name)
        {
            return Task.FromResult(_proxy.Command.GetSessionEnabled(name));
        }

        /// <summary>
        /// Checks a command on whether it is temporarily enabled or disabled
        /// </summary>
        /// <param name="identifier">The identifier of the command</param>
        public Task<bool> GetEnabledForThisSession(Guid identifier)
        {
            return Task.FromResult(_proxy.Command.GetSessionEnabled(identifier));
        }

        /// <summary>
        /// Checks a category on whether it is temporarily enabled or disabled
        /// </summary>
        /// <param name="name">The name of the category</param>
        public Task<bool> GetEnabledCategoryForThisSession(string name)
        {
            return Task.FromResult(_proxy.Command.GetSessionEnabledByCategory(name));
        }

        /// <summary>
        /// Invoke a voice command
        /// </summary>
        /// <param name="commandName">The name of the command</param>
        /// <param name="runSync">Whether to wait until the command has fully executed, before continuing</param>
        /// <param name="runAsSubCommand">Whether to run this command as a sub-command</param>
        /// <returns></returns>
        public Task Invoke(string commandName, bool runSync = false, bool runAsSubCommand = false)
        {
            _proxy.Command.Execute(commandName, runSync, runAsSubCommand);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Invoke a voice command
        /// </summary>
        /// <param name="identifier">The identifier of the command</param>
        /// <param name="runSync">Whether to wait until the command has fully executed, before continuing</param>
        /// <param name="runAsSubCommand">Whether to run this command as a sub-command</param>
        public Task Invoke(Guid identifier, bool runSync = false, bool runAsSubCommand = false)
        {
            _proxy.Command.Execute(identifier, runSync, runAsSubCommand);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Check whether a command exists in the profile
        /// </summary>
        /// <param name="commandName">The name of the command</param>
        public Task<bool> Exists(string commandName)
        {
            return Task.FromResult(_proxy.Command.Exists(commandName));
        }

        /// <summary>
        /// Check whether a command exists in the profile
        /// </summary>
        /// <param name="identifier">The identifier of the command</param>
        public Task<bool> Exists(Guid identifier)
        {
            return Task.FromResult(_proxy.Command.Exists(identifier));
        }

        /// <summary>
        /// Check whether a command is executing
        /// </summary>
        /// <param name="commandName">The name of the command</param>
        public Task<bool> IsRunning(string commandName)
        {
            return Task.FromResult(_proxy.Command.Active(commandName));
        }

        /// <summary>
        /// Check whether a command is executing
        /// </summary>
        /// <param name="identifier">The identifier of the command</param>
        public Task<bool> IsRunning(Guid identifier)
        {
            return Task.FromResult(_proxy.Command.Active(identifier));
        }

        /// <summary>
        /// Whether a category exists in the profile
        /// </summary>
        /// <param name="name">The name of the category</param>
        public Task<bool> CategoryExists(string name)
        {
            return Task.FromResult(_proxy.Command.CategoryExists(name));
        }
    }

    public enum CommandSource
    {
        Spoken, 
        Keyboard, 
        Joystick, 
        Mouse, 
        Profile,
        External,
        Unrecognized, 
        ProfileUnloadChange, 
        ProfileUnloadClose,
        DictationRecognized, 
        Plugin, 
        Other
    }
}
