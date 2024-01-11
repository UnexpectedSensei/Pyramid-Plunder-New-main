using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    public string animationTrigger = "MainCharacter"; // Animation Trigger Name
    private bool hasEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasEntered && other.CompareTag("Player"))
        {
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(animationTrigger);
            }
            hasEntered = true; // Set a flag to ensure the animation is triggered only once
        }
    }
}
