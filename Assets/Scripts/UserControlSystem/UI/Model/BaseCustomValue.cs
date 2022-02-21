using System;
using UnityEngine;

public abstract class BaseCustomValue<T> : ScriptableObject
{
    public T CurrentValue { get; protected set; }

    public Action<T> OnNewValue;

    public virtual void SetValue(T value) 
    {
        CurrentValue = value;
        OnNewValue?.Invoke(value);
    }
}

