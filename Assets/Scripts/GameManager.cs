using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager managerInstance;
    public bool isPlayerDead;
    public bool isPaused;
    public List<Room> rooms;

    public TMP_Text roomMomentCounts;
    public GameObject pauseMenu;

    public AudioSource ambiantMusic;
    
    private void Awake()
    {
        rooms = new List<Room>();
        ambiantMusic = GetComponent<AudioSource>();

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
       UpdateMomentCount();
       pauseMenu.SetActive(false);
       Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TogglePauseMenu();
        }
    }

    public void UpdateMomentCount()
    {
        string countList = "";
        foreach (var room in rooms)
        {
            if (room.momentCount == 0) continue;
            countList += room.name + ": " + room.completedMomentCount + " / " + room.momentCount + "\n";
        }

        roomMomentCounts.text = countList;
    }

    public void TogglePauseMenu()
    {
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        // Stop play mode in the Editor
        EditorApplication.isPlaying = false;
#else
        
        Application.Quit();
#endif
    }

}
