using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public Image[] HealthHeart;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
    }

    // Damage Logic with fixed damage amount of 1
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= 1; // Always deduct 1 health point
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < HealthHeart.Length; i++)
        {
            if (i < currentHealth)
            {
                HealthHeart[i].enabled = true; // Show the heart
            }
            else
            {
                HealthHeart[i].enabled = false; // Hide the empty hearts
            }
        }
    }
}
