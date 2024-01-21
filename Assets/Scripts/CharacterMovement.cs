using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Movement Stats")]
    [SerializeField] private float _moveSpead;
    [SerializeField] private float _rotateSpeed;

    [Header("Jump Stats")]
    [SerializeField] private float _maxJumpTime;
    [SerializeField] private float _maxJumpHeight;
    private float _startJumpVelocity;
    private Vector3 _velocityDirection;

    [Header("Gravity parameters")]
    [SerializeField] private float _gravityForce = 9.8f;

    [Header("Character components")]
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        float maxHeightTime = _maxJumpTime / 2;
        var GravityForce = (2 * _maxJumpHeight) / Mathf.Pow(maxHeightTime, 2);
        _startJumpVelocity = (2 * _maxJumpHeight) / maxHeightTime;
    }

    private void Update()
    {
        GravityHandling();
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        _velocityDirection.x = moveDirection.x * _moveSpead;
        _velocityDirection.z = moveDirection.z * _moveSpead;
        _characterController.Move(_velocityDirection * Time.deltaTime);

    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if(!_characterController.isGrounded )
        {
            if(Vector3.Angle(transform.forward, moveDirection) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }

    public void HandleJump()
    {
        if(_characterController.isGrounded)
        {
            _velocityDirection.y = _startJumpVelocity;   
        }
    }


    private void GravityHandling()
    {
        if (!_characterController.isGrounded)
        {
            _velocityDirection.y -= _gravityForce * Time.deltaTime;
        }
        else
        {
            _velocityDirection.y -= 0.5f;
        }
    }

}
