using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // This function is called when the "Exit Game" button is clicked.
    public void ExitGame()
    {
        // Check if the game is running in the Unity Editor's play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Quit the application in standalone builds
        Application.Quit();
#endif
    }
}
