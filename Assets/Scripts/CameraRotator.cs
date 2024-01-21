using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerBody;

    private float _mouseX, _mouseY;
    private float xRotation;
    void Start()
    {
        xRotation = 0;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCameraRotation();

        _playerBody.Rotate(Vector3.up * _mouseX);
        xRotation -= _mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        
    }
    private void UpdateCameraRotation()
    {
        float rotationSpeed = _mouseSensitivity * Time.deltaTime;
        _mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        _mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;


    }
}
