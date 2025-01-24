using UnityEngine;

public class AttackState: PlayerState
{
    public override string Name => nameof(AttackState);

    public override void EnterState(PlayerController playerController)
    {
        playerController.spineAnimationState.SetAnimation(0, playerController.atkAnimationName_2, true);
    }
    public override void UpdateState(PlayerController playerStateMachine)
    {
        if (playerStateMachine.horizontalMovement != 0)
        {
            playerStateMachine.SwitchState(playerStateMachine.walkingState);
        }

        if (Input.GetButtonDown("Jump") && playerStateMachine.IsGrounded())
        {
            playerStateMachine.SwitchState(playerStateMachine.jumpState);
        }

        if (Input.GetKeyDown(playerStateMachine.upKey))
        {
            playerStateMachine.SwitchState(playerStateMachine.jumpState);
        }
    }
}
