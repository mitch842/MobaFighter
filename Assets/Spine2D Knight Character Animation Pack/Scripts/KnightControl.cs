using UnityEngine;
using System.Collections;
using Spine;
using Spine.Unity;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class KnightControl : MonoBehaviour
{
    #region Inspector
    // [SpineAnimation] attribute allows an Inspector dropdown of Spine animation names coming form SkeletonAnimation.
    [SpineAnimation]
    public string runAnimationName;

    [SpineAnimation]
    public string idleAnimationName;

    [SpineAnimation]

    public string walkAnimationName;

    [SpineAnimation]
    public string atkAnimationName_1;

    [SpineAnimation]
    public string atkAnimationName_2;

    [SpineAnimation]
    public string jumpAnimationName;

    [SpineAnimation]
    public string hitAnimationName;

    [SpineAnimation]
    public string deathAnimationName;

    [SpineAnimation]
    public string stunAnimationName;

    [SpineAnimation]
    public string skillAnimationName_1;
    [SpineAnimation]
    public string skillAnimationName_2;
    [SpineAnimation]
    public string skillAnimationName_3;
    #endregion

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode attackKey;
    public float movementSpeed;

    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private SkeletonAnimation skeletonAnimation;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Spine.AnimationState and Spine.Skeleton are not Unity-serialized objects. You will not see them as fields in the inspector.
    public Spine.AnimationState spineAnimationState;
    public Spine.Skeleton skeleton;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        spineAnimationState = skeletonAnimation.AnimationState;
        skeleton = skeletonAnimation.Skeleton;
    }

    public void running()
    {
        spineAnimationState.SetAnimation(0, runAnimationName, true);
    }
    public void walking()
    {
        spineAnimationState.SetAnimation(0, walkAnimationName, true);
    }
    public void idle()
    {
        spineAnimationState.SetAnimation(0, idleAnimationName, true);
    }
    public void jump()
    {
        spineAnimationState.SetAnimation(0, jumpAnimationName, true);
    }
    public void getHit()
    {
        spineAnimationState.SetAnimation(0, hitAnimationName, true);
    }
    public void death()
    {
        spineAnimationState.SetAnimation(0, deathAnimationName, true);
    }
    public void stun()
    {
        spineAnimationState.SetAnimation(0, stunAnimationName, true);
    }
    public void attack_1()
    {
        spineAnimationState.SetAnimation(0, atkAnimationName_1, true);
    }
    public void attack_2()
    {
        spineAnimationState.SetAnimation(0, atkAnimationName_2, true);
    }
    public void skill_1()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_1, true);
    }
    public void skill_2()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_2, true);
    }
    public void skill_3()
    {
        spineAnimationState.SetAnimation(0, skillAnimationName_3, true);
    }

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(leftKey))
        {
            walking();
        }
        if (Input.GetKeyDown(rightKey))
        {
        }
        if (Input.GetKeyDown(upKey))
        {
            jump();
        }
        if (Input.GetKeyDown(downKey))
        {
            idle();
        }
        if (Input.GetKeyDown(attackKey))
        {
            attack_2();
        }


        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
