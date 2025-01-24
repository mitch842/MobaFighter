using UnityEngine;

public class WalkingState: PlayerState
{
    public override string Name => nameof(WalkingState);
    public override void EnterState(PlayerController playerController)
    {
        playerController.spineAnimationState.SetAnimation(0, playerController.runAnimationName, true);
    }
    public override void UpdateState(PlayerController playerController)
    {
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
