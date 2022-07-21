using UnityEngine;
public class JumpState : PlayerBaseState
{
    public JumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

    public override void Enter()
    {
        _playerStateMachine._InputReader.onJump += OnJump;
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Is Jumping");
    }

    public override void Exit()
    {
        _playerStateMachine._InputReader.onJump -= OnJump; 
    }

    void OnJump()
    {
        _playerStateMachine.ChangeState(this);
    }
}
