using System;
using UnityEngine;

public class AirBoost : MonoBehaviour
{
    public float boostForce;

    private Vector3 _boostDirection;
    private Rigidbody _playerRb;

    private void Start()
    {
        _boostDirection = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerRb = other.gameObject.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _playerRb != null)
        {
            _playerRb.AddForce(_boostDirection * boostForce);
        }
    }
    
    
}
