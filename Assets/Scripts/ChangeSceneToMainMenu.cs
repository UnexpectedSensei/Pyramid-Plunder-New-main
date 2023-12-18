using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToMainMenu : MonoBehaviour
{
    // Public method to be called when the button is clicked
    public void ChangeToMainMenu()
    {
        // Replace "MainMenu" with the name of your main menu scene
        SceneManager.LoadScene("MainMenu");
    }
}
