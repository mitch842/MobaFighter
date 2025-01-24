using UnityEngine;

public class FallState: PlayerState
{
    public override string Name => nameof(FallState);
    public override void EnterState(PlayerController playerController)
    {
        playerController.spineAnimationState.SetAnimation(0, playerController.idleAnimationName, true);
    }
    public override void UpdateState(PlayerController playerController)
    {
        if (playerController.IsGrounded())
        {
            playerController.SwitchState(playerController.idleState);
        }
    }
}