using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Float Variable", menuName = "Variables/Float Variable")]
public class FloatVariable : GenericVariable<float> { }


/// <summary>
/// The float reference.
/// </summary>
[System.Serializable]
public class FloatReference : GenericReference<float>
{
    [SerializeField]
    private FloatVariable variable;

    protected override float ReferenceValue
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