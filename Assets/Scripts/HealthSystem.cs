using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject healthBar; // Assign the cube representing the health bar in the Inspector.
    private float currentHealth = 100f; // Initial health value.

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an enemy prefab.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Decrease health when an enemy hits the player.
            print("hit me");
            DecreaseHealth(10f); // You can adjust the amount of health to decrease.
            Destroy(collision.gameObject);
        }
    }

    public void DecreaseHealth(float amount)
    {
        // Decrease the health value by the specified amount.
        currentHealth -= amount;

        // Ensure the health value stays within the valid range (0-100).
        currentHealth = Mathf.Clamp(currentHealth, 0f, 100f);

        // Call SetHealth to update the health bar.
        SetHealth(currentHealth);
    }

    public void SetHealth(float health)
    {
        // Ensure the health value is within the valid range (0-100).
        health = Mathf.Clamp(health, 0f, 100f);

        // Calculate the new scale of the health bar cube on the X-axis.
        float newScaleX = 0.5f * (health / 100f);

        // Update the health bar's X scale based on the health value.
        Vector3 newScale = new Vector3(newScaleX, 0.1f, 0.1f);
        healthBar.transform.localScale = newScale;
    }
}
