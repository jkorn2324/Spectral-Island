using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The interactable object monobehaviour.
/// </summary>
public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private float interactableWidth;
    [SerializeField]
    private float interactableHeight;

    private Rect _interactedHitbox;

    private void Start()
    {
        Vector3 position = this.transform.position;
        
        this._interactedHitbox = new Rect();
        this._interactedHitbox.x = position.x;
        this._interactedHitbox.y = position.y;
        this._interactedHitbox.width = interactableWidth;
        this._interactedHitbox.height = interactableHeight;
    }

    /// <summary>
    /// Called when the object is enabled.
    /// </summary>
    private void OnEnable()
    {
        InteractableObjectSet.AddInteractableObject(this);
    }

    /// <summary>
    /// Called when the object is disabled.
    /// </summary>
    private void OnDisable()
    {
        InteractableObjectSet.RemoveInteractableObject(this);
    }

    /// <summary>
    /// Determines whether the interactable object's interaction hitbox
    /// overlaps with the input rectangle.
    /// </summary>
    /// <param name="controller">The input rectangle..</param>
    /// <returns>A boolean that returns true if they overlap.</returns>
    public bool IsOverlappingWith(Rect rect)
    {
        return rect.Overlaps(this._interactedHitbox);
    }

    /// <summary>
    /// Called when the object interacts with the player.
    /// </summary>
    /// <param name="controller">The player controller.</param>
    public void OnInteract(PlayerController controller)
    {
        // TODO: Implementation.
        Debug.Log(this.name + " is being interactedddddddddddd");
    }
}
