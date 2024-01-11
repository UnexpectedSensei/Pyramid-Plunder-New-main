using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingInterval = 5.0f;
    public float initialForce = 10.0f; // Adjust this value as needed.
    private float lastShotTime;

    private void Start()
    {
        lastShotTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - lastShotTime >= shootingInterval)
        {
            ShootProjectile();
            lastShotTime = Time.time;
        }
    }

    private void ShootProjectile()
    {
        if (projectilePrefab != null)
        {
            // Create and activate a projectile at the spawn point
            GameObject projectile = Instantiate(projectilePrefab, transform.GetChild(0).position, Quaternion.identity);
            projectile.SetActive(true);

            // Apply a force to make the projectile move upward
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * initialForce, ForceMode.VelocityChange);
            }

            // Destroy the projectile after a certain time (adjust as needed).
            Destroy(projectile, 2.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }

            // Destroy the projectile upon hitting the player.
            Destroy(gameObject);
        }
    }
}
