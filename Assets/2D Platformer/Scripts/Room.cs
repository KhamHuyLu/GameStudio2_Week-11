using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public GameObject virtualCam;

    private bool changingRoom = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger && !changingRoom)
        {
            StartCoroutine(ChangeRoom());
        }
    }

    private IEnumerator ChangeRoom()
    {
        changingRoom = true;
        Time.timeScale = 0; // Pause the game time
        Time.fixedDeltaTime = 0; // Pause the physics simulation
        yield return new WaitForSecondsRealtime(0.1f); // Wait for a brief moment
        Time.fixedDeltaTime = 0.02f; // Resume the physics simulation
        Time.timeScale = 1; // Resume the game time
        virtualCam.SetActive(false); // Deactivate the virtual camera
        changingRoom = false;
    }
}
