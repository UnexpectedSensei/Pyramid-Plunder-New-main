using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3; // Player's starting health
    public int currentHealth; // Player's current health
    public string targetScene = "DeathScreen";

    private void Awake()
    {
        // Initialize our current health to be equal to
        // our starting health at the beginning of the game.
        currentHealth = startingHealth;
    }

    // Modify the TakeDamage method to always deduct 1 from current health
    public void TakeDamage()
    {
        // Deduct 1 from our current health
        currentHealth--;

        // Keep our currentHealth between 0 and starting health value
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        if (currentHealth <= 0)
        {
            // Call the Kill function to handle player death
            Kill();
        }
    }

    public void Kill()
    {
        // When the players health reaches zero, execute change scene function
        ChangeScene();
    }

    // This function will let other scripts ask this one what the current health is
    public int GetHealth()
    {
        return currentHealth;
    }

    // This function changes the scene when the player dies
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
