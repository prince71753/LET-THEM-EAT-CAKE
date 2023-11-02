using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public char enemyType = 'a'; // Default to type 'a'
    private float moveSpeed;
    public int damage = 1;
    private int health;
    public Transform healthBar; // Make the health bar public so you can assign it in the Inspector.

    private void Start()
    {
        // Set enemy characteristics based on the specified type.
        SetEnemyCharacteristics();
    }

    void Update()
    {
        // Move the enemy forward along the Z-axis.
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Update the health bar's scale based on the health.
        UpdateHealthBarScale();
    }

    private void SetEnemyCharacteristics()
    {
        switch (enemyType)
        {
            case 'a':
                moveSpeed = 1.0f;
                damage = 1;
                health = 1;
                break;
            case 'b':
                moveSpeed = 1.2f;
                damage = 2;
                health = 3;
                break;
            case 'c':
                moveSpeed = 0.5f;
                damage = 10;
                health = 10;
                break;
            default:
                Debug.LogWarning("Invalid enemy type. Using default characteristics for 'a'.");
                moveSpeed = 3.0f;
                damage = 1;
                health = 1;
                break;
        }

        // Update the health bar scale based on the initial health.
        UpdateHealthBarScale();
    }

    private void UpdateHealthBarScale()
    {
        // Calculate the new scale of the health bar cube on the X-axis based on health.
        float newScaleX = Mathf.Clamp01((float)health / 10f); // Assuming max health is 10.

        // Update the health bar's scale.
        healthBar.localScale = new Vector3(newScaleX, 0.1f, 0.1f);
    }
}
