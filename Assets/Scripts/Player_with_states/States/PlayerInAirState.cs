using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private int xInput;
    private bool isGrounded;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool coyoteTime;
    private bool wallJumpCoyoteTime;
    private bool isJumping;
    private bool isTouchingLedge;

    private float startWallJumpCoyoteTime;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckIfGrounded();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        CheckCoyoteTime();

        xInput = player.InputHandler.NormInputX;
        jumpInput = player.InputHandler.JumpInput;
        jumpInputStop = player.InputHandler.JumpInputStop;

        CheckJumpMultiplier();

        if (isGrounded && player.CurrentVelocity.y < 0.01f)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
        else if(jumpInput && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else
        {
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);

            player.Player_Animator.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Player_Animator.SetFloat("xVelocity", Mathf.Abs(player.CurrentVelocity.x));
        }
    }

    private void CheckJumpMultiplier()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                player.SetVelocityY(player.CurrentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if (player.CurrentVelocity.y <= 0f)
            {
                isJumping = false;
            }
        }
    }

    private void CheckCoyoteTime()
    {
        if (coyoteTime && Time.time > startTime + playerData.coyoteTime)
        {
            coyoteTime = false;
            player.JumpState.DecreaseAmountOfJumpsLeft();
        }
    }

    public void StartCoyoteTime() => coyoteTime = true;

    public void SetIsJumping() => isJumping = true;
}
