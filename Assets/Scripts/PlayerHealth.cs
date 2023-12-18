using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Initialize the character's health
    public int maxHealth = 3;
    private int currentHealth;
    public int damageAmount = 1;

    private void Start()
    {
        // Set the initial health
        currentHealth = maxHealth;
    }

    // Function to take damage
    public void TakeDamage(int damageAmount)
    {
        // Check if the character is not already dead
        if (currentHealth > 0)
        {
            // Reduce the character's health by the damage amount
            currentHealth -= damageAmount;

            // Check if the character's health has reached zero
            if (currentHealth <= 0)
            {
                // Load Game Over Screen
                SceneManager.LoadScene("DeathScreen");
            }
        }
    }
    
        
    
}
