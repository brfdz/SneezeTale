using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    public AudioClip roomAmbientClip;

    public Room roomObject;
    public string roomName;

    public Dictionary<string, bool> dictionary = GameManager.managerInstance.roomAudioDictionary;

    void Start()
    {
        roomObject = new Room(roomName);
        SetRoomMoments();
    }

    void Update()
    {

    }

    private void SetRoomMoments()
    {
        foreach (var item in dictionary)
        {
            if (item.Key.ToLower().Contains(roomName))
            {
                roomObject.momentCount++;
                if (item.Value.Equals(1))
                {
                    roomObject.completedMomentCount++;
                }
            }
        }
        
    }

public class Room
{
    public string name;
    public int completedMomentCount = 0;
    public int momentCount = 0;

    public Room(string name)
    {
        this.name = name;
    }

}
