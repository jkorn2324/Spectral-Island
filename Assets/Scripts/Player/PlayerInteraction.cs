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
        if (!this.HasInteractButtonDown)
        {
            return;
        }

        Rect rect = this.GenerateHitboxRect();
        // TODO: Get set of interactable objects.
    }

    private Rect GenerateHitboxRect()
    {
        Rect rect = new Rect();
        
        // Sets the x & y positions based on the hitbox offset.
        float x = this.Position.x;
        float y = this.Position.y;
        switch (this._parent.CurrentDirection)
        {
            case PlayerController.Direction.DOWN:
                y -= this._interactData.interactHitboxOffset;
                break;
            case PlayerController.Direction.LEFT:
                x -= this._interactData.interactHitboxOffset;
                break;
            case PlayerController.Direction.UP:
                y += this._interactData.interactHitboxOffset;
                break;
            case PlayerController.Direction.RIGHT:
                x += this._interactData.interactHitboxOffset;
                break;
        }

        rect.width = this._interactData.interactHitboxWidth;
        rect.height = this._interactData.interactHitboxHeight;
        return rect;
    }
}
