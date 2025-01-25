using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float jumpForce = 1f;
    public float _maxJumpSpeed = 6f;
    public float rotationSpeed = 10f;
    
    public Rigidbody rb;

    public Transform virtualCamera;

    private Vector3 _cameraForward;

    private float _cameraAngle;
    private float _playerAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        RotatePlayerToView();
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Jump"))
        {
            HandleJump();
        }
    }


    private void HandleJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);

        // Apply upward force if the upward velocity is below the max float speed
        if (rb.linearVelocity.y < _maxJumpSpeed)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
        }
    }

    private void RotatePlayerToView()
    {
        _cameraAngle = virtualCamera.rotation.eulerAngles.y;
        _playerAngle = transform.rotation.eulerAngles.y;
        float angleDifference = Mathf.DeltaAngle(_playerAngle, _cameraAngle);

        // Rotate when camera rotates enough to avoid jittering
        if (Mathf.Abs(angleDifference) > 0.1)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, _cameraAngle, 0f);
            //Quaternion currentRotation = Quaternion.Euler(0f, _playerAngle, 0f);
            
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * rotationSpeed));
            
        }
    }
}
