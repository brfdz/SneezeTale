using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    public AudioClip roomAmbientClip;

    public Room roomObject;
    public string roomName;

    private List<MomentController> roomMoments;

    void Awake()
    {
        roomMoments = new List<MomentController>();
        roomObject = new Room(roomName);
        GameManager.managerInstance.rooms.Add(roomObject);
    }


    public void AddRoomMoment(MomentController moment)
    {
        roomMoments.Add(moment);
        roomObject.momentCount++;
    }

    public void MarkMomentDone(MomentController moment)
    {
        if (roomMoments.Contains(moment))
        {
            roomObject.completedMomentCount++;
        }
    }

}

public class Room
{
    public string name;
    public int completedMomentCount = 0;
    public int momentCount;
    public Room(string name)
    {
        this.name = name;
    }
    
}
