using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;

    // Add a reference to the death screen scene name in the Unity Inspector
    public string deathScreenSceneName = "DeathScreen";

    private void Start()
    {
        // Initialize the player's current health
        currentHealth = maxHealth;
    }

    // Function to apply damage to the player
    public void TakeDamage(int damageAmount)
    {
        // Reduce the player's health
        currentHealth -= damageAmount;

        // Check if the player's health has reached zero or below
        if (currentHealth <= 0)
        {
            // Call handle player death function
            HandlePlayerDeath();
        }
    }

    // Function to handle player death
    private void HandlePlayerDeath()
    {
        // Load the DeathScreen scene when the player dies
        SceneManager.LoadScene(deathScreenSceneName);
    }
}
