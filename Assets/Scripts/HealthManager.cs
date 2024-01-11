using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // This will contain a list of the game objects for the health icons
    public GameObject[] healthIcons;

    // Reference to the PlayerHealth component on the player game object
    private PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        // Search the scene for the object with PlayerHealth attached
        // Store the PlayerHealth component from that object in our player variable
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a variable to keep track of which item of the list we are on
        // and how much health that icon is worth
        int iconHealth = 0;

        // Go through each icon in the list
        // We will do everything inside the braces for each item in the list
        // For each step in the loop, we'll store the current list item in the "icon" variable
        foreach (GameObject icon in healthIcons)
        {
            // Each icon is worth one more health than the last
            // So we get the current health and add one to it and store the result back into the iconHealth variable
            iconHealth = iconHealth + 1;

            // If the player current health is equal or greater
            // than the health value for this icon...
            if (player.GetHealth() >= iconHealth)
            {
                // Then turn the icon ON
                icon.SetActive(true);
            }
            // Otherwise
            // (the player's health is LESS than this icon's value)
            else
            {
                // ... turn the icon OFF
                icon.SetActive(false);
            }
        }
    }

    // Function to update the player's health
    public void TakeDamage()
    {
        if (player != null)
        {
            player.TakeDamage();
        }
    }
}
