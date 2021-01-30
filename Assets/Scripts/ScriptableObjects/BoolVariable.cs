using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bool Variable", menuName = "Variables/Bool Variable")]
public class BoolVariable : GenericVariable<bool> { }


/// <summary>
/// The boolean reference.
/// </summary>
[System.Serializable]
public class BoolReference : GenericReference<bool>
{
    [SerializeField]
    private BoolVariable variable;

    protected override bool ReferenceValue 
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
