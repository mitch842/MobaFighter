using UnityEngine;

public class JumpState: PlayerState
{
    private float liftOffTimeOut;
    private const float LIFT_OFF_TIME = 0.5f;
    public override string Name => nameof(JumpState);
    public override void EnterState(PlayerController playerController)
    {
        liftOffTimeOut = LIFT_OFF_TIME;
        playerController.spineAnimationState.SetAnimation(0, playerController.jumpAnimationName, true);
        playerController.rb.linearVelocity = new Vector2(playerController.rb.linearVelocity.x, playerController.jumpingPower);
    }
    public override void UpdateState(PlayerController playerController)
    {
        liftOffTimeOut -= Time.deltaTime;
        Rigidbody2D rb = playerController.rb;
        //if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        //{
        //    rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        //}

        if (Input.GetKeyDown(playerController.attackKey))
        {
            playerController.SwitchState(playerController.attackState);
        }

        if (liftOffTimeOut<=0 && playerController.IsGrounded())
        {
            playerController.SwitchState(playerController.idleState);
        }
    }
}
