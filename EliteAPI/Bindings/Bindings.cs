using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteAPI.Abstractions.Bindings;
using EliteAPI.Abstractions.Bindings.Models;
using EliteAPI.Abstractions.Events;
using EliteAPI.Events;
using Microsoft.Extensions.Logging;

namespace EliteAPI.Bindings;

public class Bindings : IBindings
{
    private readonly ILogger<Bindings>? _log;
    private readonly IBindingsParser _parser;
    private readonly IEvents _events;

    private readonly List<(Delegate d, bool hasContext)> _handlers = new();
    

    public Bindings(ILogger<Bindings>? log, IBindingsParser parser, IEvents events)
    {
        _log = log;
        _parser = parser;
        _events = events;
    }

    /// <inheritdoc />
    public IReadOnlyCollection<Binding> Active { get; private set; } = new List<Binding>();

    /// <inheritdoc />
    public Binding? this[string binding] => Active.FirstOrDefault(x => x.Name == binding);

    /// <inheritdoc />
    public Binding this[KeyBinding binding] => this[binding.ToString()].HasValue ? this[binding.ToString()]!.Value : throw new KeyNotFoundException("The keybinding was not found");

    /// <inheritdoc />
    public void OnBindings(BindingsDelegate handler) => _handlers.Add((handler, false));

    /// <inheritdoc />
    public void OnBindings(AsyncBindingsDelegate handler) => _handlers.Add((handler, false));

    /// <inheritdoc />
    public void OnBindings(BindingsContextDelegate handler) => _handlers.Add((handler, true));

    /// <inheritdoc />
    public void OnBindings(AsyncBindingsContextDelegate handler) => _handlers.Add((handler, true));

    /// <inheritdoc />
    public void Invoke(string xml, BindingsContext context)
    {
        Active = _parser.Parse(xml);
        
        foreach (var (d, hasContext) in _handlers)
        {
            Invoke(d, Active, hasContext, context);
        }
        
        _events.Invoke(new BindingsEvent(Active), new EventContext() { IsImplemented = true, IsRaisedDuringCatchup = context.IsRaisedDuringCatchup, SourceFile = context.SourceFile});
    }
    
    private void Invoke(Delegate d, object param, bool hasContext, BindingsContext context)
    {
        _log?.LogTrace("Invoking {Type}:{Handler} handler for bindings",
            d.Method.DeclaringType?.FullName,
            d.Method.Name);

        var isAsync = d.Method.ReturnType == typeof(Task);

        try
        {
            var result = hasContext ? d.DynamicInvoke(param, context) : d.DynamicInvoke(param);

            if (isAsync && result != null)
                (result as Task)!.GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            if (ex is TargetInvocationException && ex.InnerException != null)
                ex = ex.InnerException;

            _log?.LogWarning(ex,
                "Unhandled exception in handler {Type}:{Handler} for bindings",
                d.Method.DeclaringType?.FullName,
                d.Method.Name);
        }
    }
}