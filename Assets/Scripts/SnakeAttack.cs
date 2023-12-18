using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAttack : MonoBehaviour
{
    public Animator snakeAnimator; // Reference to the snake's Animator component
    public AudioSource HissSound; // Reference to the snake's hiss sound
    public int damageAmount = 1; // Amount of damage the snake inflicts
    public HealthManager healthManager; // Reference to the HealthManager script on the main character

    private bool hasAttacked = false; // To prevent repeated attacks

    private void OnTriggerEnter(Collider other)
    {
        // Check if the main character enters the snake's box collider
        if (other.CompareTag("MainCharacter") && !hasAttacked)
        {
            // Play snake attack animation
            snakeAnimator.SetTrigger("SnakeAttack");

            // Play snake hissing sound
            HissSound.Play();

            // Inflict damage to the main character
            healthManager.TakeDamage(damageAmount);

            // Prevent repeated attacks until the snake resets
            hasAttacked = true;
        }
    }

    // Reset the hasAttacked flag when the player exits the trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCharacter"))
        {
            hasAttacked = false;
        }
    }
}
