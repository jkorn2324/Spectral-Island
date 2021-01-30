using UnityEngine;

[CreateAssetMenu(fileName = "Integer Variable", menuName = "Variables/Integer Variable")]
public class IntegerVariable : GenericVariable<int> { }


/// <summary>
/// The integer reference.
/// </summary>
[System.Serializable]
public class IntegerReference : GenericReference<int>
{
    [SerializeField]
    private IntegerVariable variable;

    protected override int ReferenceValue
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