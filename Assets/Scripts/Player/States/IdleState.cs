using UnityEngine;

public class IdleState: PlayerState
{
    public override string Name => nameof(IdleState);
    public override void EnterState(PlayerController playerController)
    {
        playerController.spineAnimationState.SetAnimation(0, playerController.idleAnimationName, true);
    }
    public override void UpdateState(PlayerController playerController)
    {
        if (playerController.horizontalMovement !=0)
        {
            playerController.SwitchState(playerController.walkingState);
        }

        if (Input.GetButtonDown("Jump") && playerController.IsGrounded())
        {
            playerController.SwitchState(playerController.jumpState);
        }

        if (Input.GetKeyDown(playerController.attackKey))
        {
            playerController.SwitchState(playerController.attackState);
        }
    }
}
