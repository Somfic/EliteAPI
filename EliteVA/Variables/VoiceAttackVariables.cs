using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EliteVA.Variables;

public class VoiceAttackVariables(dynamic vaProxy)
{
    public record Variable(string Name, dynamic Value, TypeCode Type);

    private readonly object _lock = new();
    private List<Variable> _setVariables = [];

    public IReadOnlyList<Variable> SetVariables
    {
        get
        {
            lock (_lock)
                return _setVariables.ToList();
        }
    }

    public event EventHandler? OnVariablesSet;

    public void ClearStartingWith(string name)
    {
        List<Variable> variablesToClear;
        lock (_lock)
        {
            variablesToClear = _setVariables.Where(x => x.Name.StartsWith(name)).ToList();
            _setVariables = _setVariables.Where(x => !x.Name.StartsWith(name)).ToList();
        }

        foreach (var variable in variablesToClear)
            Clear(variable.Name, variable.Type);
    }

    /// <summary>
    /// Set a variable
    /// </summary>
    /// <param name="name">The name of the variable</param>
    /// <param name="value">The value of the variable</param>
    /// <param name="code">The type of variable</param>
    public void Set(string name, string value, TypeCode code)
    {
        switch (code)
        {
            case TypeCode.Boolean:
                SetBoolean(name, bool.Parse(value));
                break;

            case TypeCode.DateTime:
                SetDate(name, DateTime.Parse(value.Trim('"'), CultureInfo.InvariantCulture));
                break;

            case TypeCode.Single:
            case TypeCode.Decimal:
            case TypeCode.Double:
                SetDecimal(name, decimal.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture));
                break;

            case TypeCode.Char:
            case TypeCode.String:
                SetText(name, value.Trim('"'));
                break;

            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.SByte:
                SetShort(name, short.Parse(value));
                break;

            case TypeCode.Int32:
            case TypeCode.UInt32:
            case TypeCode.Int64:
            case TypeCode.UInt64:
                try
                {
                    SetInt(name, int.Parse(value));
                }
                catch (OverflowException)
                {
                    SetDecimal(name, decimal.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture));
                }

                break;
        }
    }

    /// <summary>
    /// Get a variable
    /// </summary>
    /// <typeparam name="T">The type of variable</typeparam>
    /// <param name="name">The name of the variable</param>
    public T? Get<T>(string name, T? @default = default)
    {
        var code = Type.GetTypeCode(typeof(T));
        T? value = @default;
        switch (code)
        {
            case TypeCode.Boolean:
                value = GetBoolean(name).HasValue ? (T)Convert.ChangeType(GetBoolean(name), typeof(T)) : @default;
                break;
            case TypeCode.DateTime:
                value = GetDate(name).HasValue ? (T)Convert.ChangeType(GetDate(name), typeof(T)) : @default;
                break;
            case TypeCode.Single:
            case TypeCode.Decimal:
            case TypeCode.Double:
            case TypeCode.Int64:
            case TypeCode.UInt64:
                value = GetDecimal(name).HasValue ? (T)Convert.ChangeType(GetDecimal(name), typeof(T)) : @default;
                break;
            case TypeCode.Char:
            case TypeCode.String:
                value = string.IsNullOrWhiteSpace(GetText(name)) ? @default : (T)Convert.ChangeType(GetText(name), typeof(T));
                break;
            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.SByte:
                value = GetShort(name).HasValue ? (T)Convert.ChangeType(GetShort(name), typeof(T)) : @default;
                break;
            case TypeCode.Int32:
            case TypeCode.UInt32:
                value = GetInt(name).HasValue ? (T)Convert.ChangeType(GetInt(name), typeof(T)) : @default;
                break;
        }
        return value;
    }

    public void Clear(string name, TypeCode code)
    {
        switch (code)
        {
            case TypeCode.Boolean:
                ClearBoolean(name);
                break;

            case TypeCode.DateTime:
                ClearDate(name);
                break;

            case TypeCode.Single:
            case TypeCode.Decimal:
            case TypeCode.Double:
                ClearDecimal(name);
                break;

            case TypeCode.Char:
            case TypeCode.String:
                ClearText(name);
                break;

            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.SByte:
                ClearShort(name);
                break;

            case TypeCode.Int32:
            case TypeCode.UInt32:
            case TypeCode.Int64:
            case TypeCode.UInt64:
                ClearInt(name);
                break;
        }
    }

    private short? GetShort(string name)
    {
        return vaProxy.GetSmallInt(name);
    }

    private int? GetInt(string name)
    {
        return vaProxy.GetInt(name);
    }

    private string GetText(string name)
    {
        return vaProxy.GetText(name);
    }

    private decimal? GetDecimal(string name)
    {
        return vaProxy.GetDecimal(name);
    }

    private bool? GetBoolean(string name)
    {
        return vaProxy.GetBoolean(name);
    }

    private DateTime? GetDate(string name)
    {
        return vaProxy.GetDate(name);
    }

    private void SetShort(string name, short? value)
    {
        SetVariable(name, value, TypeCode.Int16);
        vaProxy.SetSmallInt(name, value);
    }

    private void ClearShort(string name)
    {
        ClearVariable(name);
        vaProxy.SetSmallInt(name, null);
    }

    private void SetInt(string name, int? value)
    {
        SetVariable(name, value, TypeCode.Int32);
        vaProxy.SetInt(name, value);
    }

    private void ClearInt(string name)
    {
        ClearVariable(name);
        vaProxy.SetInt(name, null);
    }

    private void SetText(string name, string value)
    {
        SetVariable(name, value, TypeCode.String);
        vaProxy.SetText(name, value);
    }

    private void ClearText(string name)
    {
        ClearVariable(name);
        vaProxy.SetText(name, null);
    }

    private void SetDecimal(string name, decimal? value)
    {
        SetVariable(name, value, TypeCode.Decimal);
        vaProxy.SetDecimal(name, value);
    }

    private void ClearDecimal(string name)
    {
        ClearVariable(name);
        vaProxy.SetDecimal(name, null);
    }

    private void SetBoolean(string name, bool? value)
    {
        SetVariable(name, value, TypeCode.Boolean);
        vaProxy.SetBoolean(name, value);
    }

    private void ClearBoolean(string name)
    {
        ClearVariable(name);
        vaProxy.SetBoolean(name, null);
    }

    private void SetDate(string name, DateTime? value)
    {
        SetVariable(name, value, TypeCode.DateTime);
        vaProxy.SetDate(name, value);
    }

    private void ClearDate(string name)
    {
        ClearVariable(name);
        vaProxy.SetDate(name, null);
    }

    private void SetVariable(string name, dynamic? value, TypeCode type)
    {
        lock (_lock)
        {
            var index = _setVariables.FindIndex(x => x.Name == name);

            if (index >= 0)
                _setVariables[index] = new(name, value, type);
            else
                _setVariables.Insert(0, new(name, value, type));
        }

        OnVariablesSet?.Invoke(this, EventArgs.Empty);
    }

    private void ClearVariable(string name)
    {
        lock (_lock)
            _setVariables.RemoveAll(x => x.Name == name);

        OnVariablesSet?.Invoke(this, EventArgs.Empty);
    }
}
