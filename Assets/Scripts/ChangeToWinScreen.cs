using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToWinScreen : MonoBehaviour
{
    // Set this in the Unity Inspector to the name of the scene you want to load when the win condition is met.
    public string winSceneName = "Win Screen";

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision occurred with an object tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the "WinScreen" scene
            SceneManager.LoadScene(winSceneName);
        }
    }
}
