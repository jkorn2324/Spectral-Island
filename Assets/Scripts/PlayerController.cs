using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GlobalGameStateManager GameState;
    public enum Direction
    {
        LEFT = 0,
        RIGHT = 1,
        UP = 2,
        DOWN = 3
    }

    [SerializeField]
    private FloatReference yToZVariable;
    [SerializeField]
    private PlayerInteractData interactData;
    [SerializeField]
    private float movementSpeed;

    private PlayerInteractController _interactController;

    private Rigidbody2D rb;
    private Animator anim;

    private float horizontalInputDirection;
    private float verticalInputDirection;
    private bool canMove;
    private Direction facingDirection;

    public LayerMask Collidable;
    public LayerMask Interactable;

    public Direction CurrentDirection
        => this.facingDirection;

    public PlayerInteractController InteractController
        => this._interactController;

    private void Start()
    {
        GameState = FindObjectOfType<GlobalGameStateManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingDirection = Direction.DOWN;
        canMove = true;

        this._interactController = new PlayerInteractController(this, this.interactData);
    }

    private void Update()
    {
        if (GameState.GameMode == GlobalGameStateManager.gameMode.overworld)
        {
            CheckInput();
            CheckMovementDirection();
            UpdateAnimations();
            this._interactController?.Update();
        }
    }

    private void FixedUpdate()
    {
        if (GameState.GameMode == GlobalGameStateManager.gameMode.overworld)
        {
            ApplyMovement();
            ApplyExternalInfluences();
        }
    }

    private void OnGUI()
    {
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
        facingDirection = horizontalInputDirection > 0 ? Direction.RIGHT : Direction.LEFT;
        facingDirection = verticalInputDirection > 0 ? Direction.UP : Direction.DOWN;
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
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y * this.yToZVariable.Value);
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
