using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum direction
    {
        LEFT = 0,
        RIGHT = 1,
        UP = 2,
        DOWN = 3
    }
    private Rigidbody2D rb;
    private Animator anim;

    private float horizontalInputDirection;
    private float verticalInputDirection;
    private bool canMove;
    private direction facingDirection;

    [SerializeField]
    private float movementSpeed;
    public LayerMask Collidable;
    public LayerMask Interactable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingDirection = direction.DOWN;
        canMove = true;
    }

    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
    }

    void FixedUpdate()
    {
        ApplyMovement();
        ApplyExternalInfluences();
    }

    private void ApplyExternalInfluences()
    {
        // todo: check for external influences on the player
    }

    private void CheckMovementDirection()
    {
        // todo: set sprite based on facing direction
    }

    private void UpdateAnimations()
    {
        //anim.SetBool("isWalking", isWalking);
        // todo: set animator int for facing direction
    }

    private void CheckInput()
    {
        horizontalInputDirection = Input.GetAxisRaw("Horizontal");
        verticalInputDirection = Input.GetAxisRaw("Vertical");

        // when moving diagonally, default to up/down facing
        facingDirection = horizontalInputDirection > 0 ? direction.RIGHT : direction.LEFT;
        facingDirection = verticalInputDirection > 0 ? direction.UP : direction.DOWN;
        if (Input.GetButtonDown("Interact"))
        {
            // todo: check overlap with interactable object and switch on object type (or call object.Interact(player))
        }
    }

    private void ApplyMovement()
    {
        if (!canMove)
        {
            return;
        }
        else
        {
            Vector2 movement = new Vector2(horizontalInputDirection, verticalInputDirection);
            movement = movement.normalized * movementSpeed;
            rb.velocity = movement;
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y);
        }
    }

    private void Flip()
    {
        // helper function to flip sprite left/right
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnDrawGizmos()
    {
    }
}
