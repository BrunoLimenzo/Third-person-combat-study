using UnityEngine;

public class FreeLookState : PlayerBaseState
{
    private readonly int FreeLookHash = Animator.StringToHash("FreeLookSpeed");
    private const float AnimatorDampTime = 0.1f;

    public FreeLookState(PlayerStateMachine playerStateMachine) : base(playerStateMachine){}

    public override void Enter()
    {

    }

    public override void Tick(float deltaTime)
    {
        //gets player input
        Vector3 movementVec = CalculateMovement();
        

        //applies movement based on player input
        _playerStateMachine._CharacterController.Move(movementVec * _playerStateMachine._FreeLookMovementSpeed * deltaTime);

        // if player is not moving set animation to idle and return method
        if(movementVec == Vector3.zero) 
        {
            _playerStateMachine._Animator.SetFloat(FreeLookHash, 0, AnimatorDampTime, deltaTime);
            return; 
        }

        //set running animation and rotate player throught input direction
        _playerStateMachine._Animator.SetFloat(FreeLookHash, 1, AnimatorDampTime, deltaTime);
        FaceMovementDirection(movementVec, deltaTime);
    }

    public override void Exit()
    {
   
    }
    
    private Vector3 CalculateMovement()
    {
        Vector3 forward = _playerStateMachine._MainCameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = _playerStateMachine._MainCameraTransform.right;
        right.y = 0;
        right.Normalize();

        return forward * _playerStateMachine._InputReader.MovementValue.y + right * _playerStateMachine._InputReader.MovementValue.x; 
    }

    private void FaceMovementDirection(Vector3 dir, float deltaTime)
    {
        _playerStateMachine.transform.rotation = Quaternion.Lerp(_playerStateMachine.transform.rotation,
            Quaternion.LookRotation(dir),
            _playerStateMachine._RotationDamping * deltaTime);
    }
}
