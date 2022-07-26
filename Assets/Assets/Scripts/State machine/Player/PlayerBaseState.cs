using UnityEngine;
public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine _playerStateMachine;

    public PlayerBaseState(PlayerStateMachine playerStateMachine)
    {
        _playerStateMachine = playerStateMachine;
    }
}
