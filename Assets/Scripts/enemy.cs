// using UnityEditor.VersionControl;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public char enemyType = 'a'; // Default to type 'a'
    private float moveSpeed;
    public int damage = 1;
    private int health;
    private int maxHealth; 
    public Transform healthBar; // Assign this in the Inspector
    public int cakeDamage = 5; // Damage the enemy takes from a cake hit

    private void Start()
    {
        SetEnemyCharacteristics();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        UpdateHealthBarScale();
    }

    private void SetEnemyCharacteristics()
    {
        // Set characteristics based on enemy type
        switch (enemyType)
        {
            case 'a':
                moveSpeed = 10f;
                damage = 1;
                health = 50;
                maxHealth = 50; 
                break;
            case 'b':
                moveSpeed = 5f;
                damage = 2;
                health = 60;
                maxHealth = 60; 
                break;
            case 'c':
                moveSpeed = 2.5f;
                damage = 10;
                health = 90;
                maxHealth = 90; 
                break;
            default:
                Debug.LogWarning("Invalid enemy type. Using default characteristics for 'a'.");
                moveSpeed = 3.0f;
                damage = 1;
                health = 10;
                maxHealth = 10; 
                break;
        }

        // Update the health bar scale based on the initial health.
        UpdateHealthBarScale();
    }

    private void UpdateHealthBarScale()
    {
        // Adjust health bar to relevant size based on damaget
        float healthPercent = (float)health / maxHealth;
        Debug.Log("THIS MY PERCENT:" + healthPercent);
        healthBar.localScale = new Vector3(healthPercent, 0.1f, 0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello, Unity!");
        
            if (collision.gameObject.CompareTag("Cake"))
            {
                Destroy(collision.gameObject); // Destroy the cake on impact
                TakeDamage(cakeDamage);
            }

    }

    private void TakeDamage(int damageAmount)
    {
        Debug.Log("I have" + health);
        health -= damageAmount;
        UpdateHealthBarScale();
        if (health <= 0)
        {
            Debug.Log("I will die as i have" + health);
            Destroy(gameObject); // Destroy enemy if health is depleted
        }
    }
}


