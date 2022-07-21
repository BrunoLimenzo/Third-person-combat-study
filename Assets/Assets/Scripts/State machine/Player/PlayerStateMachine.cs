using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader _InputReader { get; private set; }
    [field: SerializeField] public CharacterController _CharacterController { get; private set; }
    [field: SerializeField] public Animator _Animator { get; private set; }
    [field: SerializeField] public float _FreeLookMovementSpeed { get; private set; }
    [field: SerializeField] public float _RotationDamping { get; private set; }
   public Transform _MainCameraTransform { get; private set; }

    private void Start()
    {
        _MainCameraTransform = Camera.main.transform;
        ChangeState(new FreeLookState(this));
    }
}
