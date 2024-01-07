using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToGameScreen : MonoBehaviour
{
    // Public method to be called when the button is clicked
    public void ChangeToGame()
    {
        // Load the game screen
        SceneManager.LoadScene("GameScreen");
    }
}
