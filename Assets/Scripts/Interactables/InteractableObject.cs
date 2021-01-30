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
    /// Updates the object.
    /// </summary>
    private void Update()
    {

    }

    /// <summary>
    /// Determines whether the player can be interacted.
    /// </summary>
    /// <param name="controller">The player controller.</param>
    /// <returns>A boolean.</returns>
    public bool CanInteract(PlayerController controller)
    {
        return false;
    }

    /// <summary>
    /// Called when the object interacts with the player.
    /// </summary>
    /// <param name="controller">The player controller.</param>
    public void OnInteract(PlayerController controller)
    {
        // TODO: Implementation.
    }
}
