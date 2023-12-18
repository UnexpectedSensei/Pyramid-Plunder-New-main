using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayer : MonoBehaviour
{
    // Reference to the main character's Rigidbody (assuming the main character has a Rigidbody)
    public Rigidbody MainCharacterRigidbody;

    // Reference to the player's health manager (assuming you have a HealthManager script)
    public HealthManager playerHealthManager;

    // Variable to track whether the character is frozen
    private bool isCharacterFrozen = false;

    // Timer to count down the freeze duration
    private float freezeTimer = 3.0f;

    // Initial rotation of the character
    private Quaternion initialRotation;

    private void Start()
    {
        if (playerHealthManager == null)
        {
            Debug.LogError("Player's HealthManager not assigned to the trap!");
        }
    }

    private void Update()
    {
        // Check if the character is frozen
        if (isCharacterFrozen)
        {
            // Decrement the freeze timer
            freezeTimer -= Time.deltaTime;

            // Check if the freeze timer has reached zero
            if (freezeTimer <= 0)
            {
                // Unfreeze the character
                UnfreezeCharacter();
            }
        }
    }

    // Function to freeze the character
    public void FreezeCharacter()
    {
        // Check if the main character's Rigidbody is assigned
        if (MainCharacterRigidbody != null)
        {
            // Disable the Rigidbody's movement and rotation
            MainCharacterRigidbody.velocity = Vector3.zero;
            MainCharacterRigidbody.angularVelocity = Vector3.zero;
            MainCharacterRigidbody.isKinematic = true;
        }

        // Store the initial rotation
        initialRotation = transform.rotation;

        // Set the character as frozen
        isCharacterFrozen = true;

        // Inflict damage to the player when the trap is triggered
        playerHealthManager.TakeDamage(1);
    }

    // Function to unfreeze the character
    private void UnfreezeCharacter()
    {
        // Check if the main character's Rigidbody is assigned
        if (MainCharacterRigidbody != null)
        {
            // Enable the Rigidbody's movement
            MainCharacterRigidbody.isKinematic = false;
        }

        // Reset the character's rotation to the initial rotation
        transform.rotation = initialRotation;

        // Reset the freeze timer and unfreeze the character
        isCharacterFrozen = false;
        freezeTimer = 3.0f;
    }
}
