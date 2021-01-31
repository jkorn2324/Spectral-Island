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

    public BoxCollider2D Collider;

    private void Start()
    {
        GameState = FindObjectOfType<GlobalGameStateManager>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingDirection = Direction.DOWN;
        canMove = true;
        Collider = GetComponent<BoxCollider2D>();

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
        // todo: set animator int for up/down/side direction
    }

    private void CheckInput()
    {
        horizontalInputDirection = Input.GetAxisRaw("Horizontal");
        verticalInputDirection = Input.GetAxisRaw("Vertical");

        // when moving diagonally, default to left/right facing
        facingDirection = verticalInputDirection > 0 ? Direction.UP : Direction.DOWN;
        facingDirection = horizontalInputDirection > 0 ? Direction.RIGHT : Direction.LEFT;
        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("pressing interact");
            // todo: check overlap with interactable object and switch on object type (or call object.Interact(player))
            Vector2 direction = facingDirection == Direction.LEFT ? new Vector2(-1f, 0f) : facingDirection == Direction.RIGHT ? new Vector2(1f, 0f) : facingDirection == Direction.UP ? new Vector2(0f, 1f) : new Vector2(0f, -1f);
            float distance = facingDirection == Direction.LEFT || facingDirection == Direction.RIGHT ? Collider.size.x / 2 + 0.01f : Collider.size.y / 2 + 0.01f;
            Vector2 start = new Vector2(transform.position.x, transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(start, direction, distance, Interactable);
            Debug.Log($"START: {start}");
            Debug.Log($"DIR: {direction}");
            Debug.Log(transform.position);
            Debug.DrawRay(this.transform.position, new Vector3(direction.x, direction.y, -1000f));
            if (hit)
            {
                Debug.Log($"Attempting to interact with: {hit.collider.gameObject.name}");
                hit.collider.gameObject.GetComponent<InteractableObject>()?.InteractIfPossible();
            }
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
