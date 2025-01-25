using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float jumpForce = 1f;
    public float _maxJumpSpeed = 6f;
    public float rotationSpeed = 10f;
    public float moveSpeed = 100f;
    
    public Rigidbody rb;

    public Transform virtualCamera;

    private Vector3 _cameraForward;
    private Vector3 _direction;

    private float _cameraAngle;
    private float _playerAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0 ,Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        RotatePlayerToView();
        HandleMovement();
        if (Input.GetButton("Jump"))
        {
            HandleJump();
        }
    }


    private void HandleJump()
    {
        // Apply upward force
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
        
    }
    
    private void HandleMovement()
    {
        if (_direction != Vector3.zero)
        {
            Vector3 moveDirection = transform.TransformDirection(_direction);
            rb.linearVelocity = moveDirection * moveSpeed * Time.fixedDeltaTime;
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
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed));
            
        }
    }

    
}
