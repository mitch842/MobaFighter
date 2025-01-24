using UnityEngine;
using Spine.Unity;

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;
    public JumpState jumpState = new JumpState();
    public IdleState idleState = new IdleState();
    public WalkingState walkingState = new WalkingState();
    public AttackState attackState = new AttackState();
    public FallState fallState = new FallState();

    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    private SkeletonAnimation skeletonAnimation;

    private bool isFacingRight = true;
    public float horizontalMovement;
    public float verticalMovement;

    [SpineAnimation]
    [SerializeField]
    public string runAnimationName;

    [SpineAnimation]
    [SerializeField]
    public string idleAnimationName;

    [SpineAnimation]
    [SerializeField]
    public string walkAnimationName;

    [SpineAnimation]
    [SerializeField]
    public string atkAnimationName_1;

    [SpineAnimation]
    [SerializeField]
    public string atkAnimationName_2;

    [SpineAnimation]
    [SerializeField]
    public string jumpAnimationName;

    [SpineAnimation]
    [SerializeField]
    public string hitAnimationName;

    [SpineAnimation]
    [SerializeField]
    public string deathAnimationName;

    [SpineAnimation]
    [SerializeField]
    public string stunAnimationName;

    [SpineAnimation]
    [SerializeField]
    public string skillAnimationName_1;

    [SpineAnimation]
    [SerializeField]
    public string skillAnimationName_2;

    [SpineAnimation]
    [SerializeField]
    public string skillAnimationName_3;

    [SerializeField] public KeyCode upKey;
    [SerializeField] public KeyCode downKey;
    [SerializeField] public KeyCode leftKey;
    [SerializeField] public KeyCode rightKey;
    [SerializeField] public KeyCode attackKey;
                     
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
                     
    [SerializeField] public float movementSpeed;
    [SerializeField] public float jumpingPower;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    public void Update()
    {
        currentState.UpdateState(this);

        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * movementSpeed, rb.linearVelocity.y);
        if (isFacingRight && horizontalMovement < 0f || !isFacingRight && horizontalMovement > 0f)
        {
            Flip();
        }
    }
    public void SwitchState(PlayerState playerState)
    {
        currentState = playerState;
        Debug.Log($"Switching to state: {playerState.Name}");
        currentState.EnterState(this);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
