using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToWinScreen : MonoBehaviour
{
    // Setting scene to be loaded.
    public string winSceneName = "Win Screen";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to an object tagged as "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered trigger area");
            // Load the "WinScreen" scene
            SceneManager.LoadScene(winSceneName);
        }
    }
}
