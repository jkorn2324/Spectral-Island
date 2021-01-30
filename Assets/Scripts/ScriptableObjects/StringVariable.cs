using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "String Variable", menuName = "Variables/String Variable")]
public class StringVariable : GenericVariable<string> {}


/// <summary>
/// The string reference.
/// </summary>
[System.Serializable]
public class StringReference : GenericReference<string>
{
    [SerializeField]
    private StringVariable variable;

    protected override string ReferenceValue
    {
        get => this.variable.Value;
        set => this.variable.Value = value;
    }

    /// <summary>
    /// Resets the boolean value.
    /// </summary>
    public override void Reset()
    {
        this.variable?.Reset();
    }
}
