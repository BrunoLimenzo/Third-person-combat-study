using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingState : PlayerBaseState
{
    public TargetingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)  {}

    public override void Enter()
    {
        _playerStateMachine._InputReader.onCancel += ChangeToFreeLook;
        _playerStateMachine._Targeter.SelectTarget();
    }


    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {
        _playerStateMachine._InputReader.onCancel -= ChangeToFreeLook;
    }

    private void ChangeToFreeLook()
    {
        _playerStateMachine._Targeter.Cancel();
        _playerStateMachine.ChangeState(new FreeLookState(_playerStateMachine));
    }
}
