﻿using Microsoft.Extensions.DependencyInjection;

namespace EliteAPI.Web;

public abstract class WebApi
{
    internal readonly IServiceProvider Services;
    private readonly IDictionary<string, string> _secrets = new Dictionary<string, string>();

    protected WebApi(IServiceProvider services)
    {
        Services = services;
    }

    public abstract string BaseUrl { get; }

    protected T AddCategory<T>() where T : WebApiCategory
    {
        return ActivatorUtilities.CreateInstance<T>(Services, this);
    }

    public void SetSecret(string key, string value)
    {
        _secrets[key] = value;
    }

    internal string GetSecret(string key)
    {
        if (!_secrets.ContainsKey(key)) throw new Exception($"Secret {key} not found");

        return _secrets[key];
    }

    internal bool HasSecret(string key)
    {
        return _secrets.ContainsKey(key);
    }
}