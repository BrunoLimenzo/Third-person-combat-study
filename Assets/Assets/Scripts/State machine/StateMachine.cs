using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    State _currentState;
    void Update()
    {
        _currentState?.Tick(Time.deltaTime);
    }

    public void ChangeState(State state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState?.Enter();
    }
}
