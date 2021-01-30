using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct PlayerInteractData
{
    [SerializeField, Range(0.0f, 10f)]
    public float interactHitboxOffset;
    [SerializeField]
    public float interactHitboxWidth;
    [SerializeField]
    public float interactHitboxHeight;
}


/// <summary>
/// Handles player interaction.
/// </summary>
public class PlayerInteractController
{
    private PlayerController _parent;
    private PlayerInteractData _interactData;

    private Vector2 Position
        => this._parent.transform.position;

    private bool HasInteractButtonDown
        => Input.GetButtonDown("Interact");

    public PlayerInteractController(PlayerController parent, PlayerInteractData interactData)
    {
        this._parent = parent;
        this._interactData = interactData;
    }

    /// <summary>
    /// Updates the interact controller.
    /// </summary>
    public void Update()
    {
        Rect rect = this.GenerateHitboxRect();
        Debug.DrawLine(this.Position, rect.position);
        if (!this.HasInteractButtonDown)
        {
            return;
        }

        InteractableObject interactableObject =
            InteractableObjectSet.GetClosestObjectTo(rect.position);
        if (interactableObject == null)
        {
            return;
        }
           
        // Calls to interact with the object.
        if (interactableObject.IsOverlappingWith(rect))
        {
            interactableObject.OnInteract(this._parent);
        }
    }

    /// <summary>
    /// Generates the hitbox rectangle for the player.
    /// </summary>
    /// <returns>The hitbox rectangle.</returns>
    private Rect GenerateHitboxRect()
    {
        Rect rect = new Rect();
        // Sets the x & y positions based on the hitbox offset.
        rect.x = this.Position.x;
        rect.y = this.Position.y;
        switch (this._parent.CurrentDirection)
        {
            case PlayerController.Direction.DOWN:
                rect.y -= this._interactData.interactHitboxOffset;
                break;
            case PlayerController.Direction.LEFT:
                rect.x -= this._interactData.interactHitboxOffset;
                break;
            case PlayerController.Direction.UP:
                rect.y += this._interactData.interactHitboxOffset;
                break;
            case PlayerController.Direction.RIGHT:
                rect.x += this._interactData.interactHitboxOffset;
                break;
        }
        rect.width = this._interactData.interactHitboxWidth;
        rect.height = this._interactData.interactHitboxHeight;
        return rect;
    }
}
