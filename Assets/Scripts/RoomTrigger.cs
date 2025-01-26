using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    public AudioClip roomAmbientClip;

    void Start()
    {
       
    }

    void Update()
    {

    }
}

public class Room
{
    public string name;
    public int completedMomentCount;
    public int momentCount;

    public Dictionary<string, bool> dictionary = new Dictionary<string, bool>();

    public Room(string name, int momentCount)
    {
        switch (name)
        {
            case "kitchen":
                foreach (var item in dictionary)
                {
                    dictionary[item.Key]
                }
        }
    }

    void Start()
    {
        dictionary = GameManager.managerInstance.roomAudioDictionary;
    }
}
