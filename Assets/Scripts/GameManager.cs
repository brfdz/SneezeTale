using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager managerInstance;

    public List<string> keys = new List<string>();
    public List<bool> values = new List<bool>();

    public Dictionary<string, bool> roomAudioDictionary = new Dictionary<string, bool>();

    public bool isPlayerDead;

    public List<Room> rooms; 
    private void Awake()
    {
        rooms = new List<Room>();
        int i = 0;
        foreach (var item in keys)
        {
            roomAudioDictionary[item] = values[i];
            i++;
        }

        if (managerInstance == null)
        {
            managerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        foreach (var key in roomAudioDictionary.Keys)
        {
            //Debug.Log($"Key: {key}, Value: {roomAudioDictionary[key]}");
        }
    }

    void Update()
    {
        
    }

}
