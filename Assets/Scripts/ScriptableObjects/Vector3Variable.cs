using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Vector3 Variable", menuName = "Variables/Vector3 Variable")]
public class Vector3Variable : GenericVariable<Vector3> { }


/// <summary>
/// The integer reference.
/// </summary>
[System.Serializable]
public class Vector3Reference : GenericReference<Vector3>
{
    [SerializeField]
    private Vector3Variable variable;

    protected override Vector3 ReferenceValue
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