using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToGameScreen : MonoBehaviour
{
    // Public method to be called when the button is clicked
    public void ChangeToGame()
    {
        // Replace "MainMenu" with the name of your main menu scene
        SceneManager.LoadScene("GameScreen");
    }
}
