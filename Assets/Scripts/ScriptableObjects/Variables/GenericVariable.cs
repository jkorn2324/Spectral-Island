using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Generic variable abstract class.
/// </summary>
/// <typeparam name="T">The type of variable.</typeparam>
public abstract class GenericVariable<T> : ScriptableObject
{
    [SerializeField]
    private T originalValue;
    [SerializeField]
    private T value;

    public event System.Action<T> ChangedValueEvent
        = delegate { };

    public T Value
    {
        get => this.value;
        set
        {
            if(!this.value.Equals(value))
            {
                this.ChangedValueEvent(value);
            }
            this.value = value;
        }
    }


    /// <summary>
    /// Resets the variable.
    /// </summary>
    public void Reset()
    {
        this.value = this.originalValue;
    }
}

/// <summary>
/// The Generic reference abstract class.
/// </summary>
/// <typeparam name="T">The type of variable.</typeparam>
public abstract class GenericReference<T>
{
    [SerializeField]
    private bool isConstant = true;
    [SerializeField]
    private T constantValue;

    protected abstract T ReferenceValue
    {
        get;
        set;
    }

    public T Value
    {
        get => (this.isConstant ? this.constantValue : this.ReferenceValue);
        set
        {
            if(!this.isConstant)
            {
                this.ReferenceValue = value;
            }
        }
    }

    /// <summary>
    /// Resets the value.
    /// </summary>
    abstract public void Reset();
}