using System;
using UnityEngine;

public class MomentController : MonoBehaviour
{
    public bool isDone;
    public AudioSource sound;

    private bool _isStarted;

    private KillPlayer _isPlayerDead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerDead != null && _isPlayerDead.isDead)
        {
            _isStarted = false;
        }
        
        if (_isStarted && !sound.isPlaying)
        {
            isDone = true;
            Debug.Log("Done moment");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDone)
        {
            sound.Play();
            _isStarted = true;
            _isPlayerDead = other.gameObject.GetComponent<KillPlayer>();
        }
    }
}
