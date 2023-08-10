namespace EliteAPI.Web.Models;

public readonly struct WebApiResponse<TValue>
{
    private readonly TValue? _value;
    private readonly Exception? _error;
    
    public static implicit operator WebApiResponse<TValue>(TValue value) => new(value);
    private WebApiResponse(TValue value)
    {
        _value = value;
        _error = default;
        IsOkay = true;
    }
    
    public static implicit operator WebApiResponse<TValue>(Exception error) => new(error);
    private WebApiResponse(Exception error)
    {
        _value = default;
        _error = error;
        IsOkay = false;
    }

    public bool IsOkay { get; }
    
    public bool IsError => !IsOkay;

    public WebApiResponse<TValue> On(Action<TValue> ok, Action<Exception> error)
    {
        if (IsOkay) 
            ok(_value!);
        else 
            error(_error!);
        return this;
    }
     
    
    public TResult Map<TResult>(Func<TValue, TResult> ok, Func<Exception, TResult> error) =>
        IsOkay ? ok(_value!) : error(_error!);
    
    public WebApiResponse<TResult> Map<TResult>(Func<TValue, TResult> ok) =>
        IsOkay ? ok(_value!) : _error!;

    public async Task<TResult> MapAsync<TResult>(Func<TValue, Task<TResult>> ok, Func<Exception, TResult> error)
    {
          return IsOkay ? await ok(_value!) : error(_error!);
    }
    
    public async Task<WebApiResponse<TResult>> MapAsync<TResult>(Func<TValue, Task<TResult>> ok)
    {
        return IsOkay ? await ok(_value!) : _error!;
    }

    public TValue Expect()
    {
          if (IsOkay) return _value!;
            throw _error!;
    }
}