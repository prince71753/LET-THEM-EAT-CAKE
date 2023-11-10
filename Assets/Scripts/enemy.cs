using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public char enemyType = 'a'; // Default to type 'a'
    private float moveSpeed;
    public int damage = 1;
    private int health;
    private int maxHealth; 
    public Transform healthBar; // Assign this in the Inspector
    public int cakeDamage = 10; // Damage the enemy takes from a cake hit

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
                moveSpeed = 1.0f;
                damage = 1;
                health = 10;
                maxHealth = 10; 
                break;
            case 'b':
                moveSpeed = 1.2f;
                damage = 2;
                health = 20;
                maxHealth = 20; 
                break;
            case 'c':
                moveSpeed = 0.5f;
                damage = 10;
                health = 30;
                maxHealth = 30; 
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
        // Adjust health bar to relevant size based on damage
        float healthPercent = (float)health / maxHealth;
        healthBar.localScale = new Vector3(healthPercent, 0.1f, 0.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cake"))
        {
            TakeDamage(cakeDamage);
            Destroy(collision.gameObject); // Destroy the cake on impact
        }
    }

    private void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        UpdateHealthBarScale();
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy enemy if health is depleted
        }
    }
}


