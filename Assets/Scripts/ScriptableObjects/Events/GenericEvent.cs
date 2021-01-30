using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Generic event abstract class.
/// </summary>
/// <typeparam name="T">The type of the parameter event.</typeparam>
public abstract class GenericEvent<T> : ScriptableObject
{
    protected event System.Action<T> _event
        = delegate { };

    public void Call(T param)
    {
        this._event(param);
    }
}
