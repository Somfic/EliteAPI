using EliteAPI.Abstractions.Bindings.Models;

namespace EliteAPI.Abstractions.Bindings;

public interface IBindings
{
    IReadOnlyCollection<Binding> Active { get; }
    
    Binding? this[string binding] { get; } 
    
    Binding this[KeyBinding binding] { get; } 
    
    void OnBindings(BindingsDelegate handler);

    void OnBindings(AsyncBindingsDelegate handler);

    void OnBindings(BindingsContextDelegate handler);
    
    void OnBindings(AsyncBindingsContextDelegate handler);
    
    void Invoke(string xml, BindingsContext context);
}