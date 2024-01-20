using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;

    private void Update()
    {
        _characterMovement.MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        //
        //for jostic movement
        //_characterMovement.RotateCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        if(Input.GetKeyDown(KeyCode.Space)) _characterMovement.HandleJump();
    }
}
