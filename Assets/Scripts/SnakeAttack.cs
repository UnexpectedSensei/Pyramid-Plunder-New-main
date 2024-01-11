using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    public Animator snakeAnimator; // Reference to the snake's Animator component
    public AudioSource HissSound; // Reference to the snake's hiss sound
    public HealthManager healthManager; // Reference to the HealthManager script on the main character

    private bool hasAttacked = false; // To prevent repeated attacks

    private void OnTriggerEnter(Collider other)
    {
        // Check if the main character enters the snake's box collider
        if (other.CompareTag("Player") && !hasAttacked)
        {
            // Play snake attack animation
            snakeAnimator.SetTrigger("SnakeAttack");

            // Play snake hissing sound
            HissSound.Play();

            // Prevent repeated attacks until the snake resets
            hasAttacked = true;

            // Call function to damage the player
            DamagePlayer();
        }
    }

    // Reset the hasAttacked flag when the player exits the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasAttacked = false;
        }
    }

    // Function to damage the player
    private void DamagePlayer()
    {
        // Check if the health manager reference is not null
        if (healthManager != null)
        {
            // Damage the player by calling TakeDamage without arguments
            healthManager.TakeDamage();
        }
        else
        {
            Debug.LogWarning("HealthManager reference is missing. Make sure to assign it in the Inspector.");
        }
    }
}
