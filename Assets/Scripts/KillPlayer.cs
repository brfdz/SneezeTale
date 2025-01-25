using System.Collections;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    private Transform respawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // remember to mark the colliding objects as "is trigger" in inspector
        if (other.gameObject.CompareTag("SpawnPointTrigger")){ 
            // get respawnPoint position from the "SpawnPointTrigger" that collided with the player
            respawnPoint = other.gameObject.GetComponent<LocateSpawnPoint>().respawnPoint;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("SpawnPointTrigger"))
        {
            StartCoroutine(waitToSpawn());
        }
    }

    IEnumerator waitToSpawn()
    {
        // freeze game
        Time.timeScale = 0;
        player.GetComponent<MeshRenderer>().enabled = false; 
        player.GetComponent<Collider>().enabled = false;

        //Wait for 4 seconds
        yield return new WaitForSecondsRealtime(3);

        // unfreeze game
        Time.timeScale = 1;

        player.transform.position = respawnPoint.position; // move player to designated spawn point
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<Collider>().enabled = true;

    }
}
