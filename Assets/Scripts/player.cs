using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cakePrefab;
    public float shootingForce = 500f;
    private Transform shootOrigin;

    private void Start()
    {
        // Set the shooting origin to this GameObject's transform
        // Attached script to the right VR controller
        shootOrigin = this.transform;
    }

    void Update()
    {
        // Detect primary button press
        if (Input.GetButtonDown("Fire1")) // "Fire1" is the default for the primary button in Unity
        {
            ShootCake();
        }
    }

    void ShootCake()
    {
        // Instantiate the cake at the shoot origin position and rotation
        GameObject cake = Instantiate(cakePrefab, shootOrigin.position, shootOrigin.rotation);

        Rigidbody rb = cake.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = cake.AddComponent<Rigidbody>();
        }

        // Set the Rigidbody to not use gravity
        rb.useGravity = false;

        // Apply force to the cake to propel it forward
        rb.AddForce(shootOrigin.forward * shootingForce);

        // Set a time to destroy the cake if it doesn't hit anything
        Destroy(cake, 5f);
    }
}
