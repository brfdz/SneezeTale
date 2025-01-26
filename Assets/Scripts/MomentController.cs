using System;
using UnityEngine;

public class MomentController : MonoBehaviour
{
    public bool isDone;
    public AudioSource sound;
    public ParticleSystem particles;
    public RoomTrigger roomTrigger;

    private bool _isStarted;
    
    void Start()
    {
        if (roomTrigger != null)
        {
            // add moment to the room
            roomTrigger.AddRoomMoment(this);
        }
    }
    
    
    void Update()
    {
        if (GameManager.managerInstance.isPlayerDead)
        {
            _isStarted = false;
        }
        
        if (_isStarted && !sound.isPlaying && !isDone)
        {
            isDone = true;
            CompleteMoment();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isDone && !_isStarted)
        {
            sound.Play();
            _isStarted = true;
        }
    }

    public void CompleteMoment()
    {
        particles.Stop();
        roomTrigger.MarkMomentDone(this);
    }
}
