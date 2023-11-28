using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cakePrefab;
    UnityEngine.XR.InputDevice rightController;
    public float shootingForce = 500f;
    private Transform shootOrigin;

    // Cooldown variables
    private bool canShoot = true;
    public float shootingCooldown = 1f;
    private float shootingTimer = 0f;

    private void Start()
    {
        List<UnityEngine.XR.InputDevice> devices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, devices);
        rightController = devices[0];

        // Set the shooting origin to this GameObject's transform
        // Attached script to the right VR controller
        shootOrigin = this.transform;
    }

    void Update()
    {
        // Update the shooting timer
        if (!canShoot)
        {
            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingCooldown)
            {
                canShoot = true;
                shootingTimer = 0f;
            }
        }

        bool triggerValue;
        if (canShoot && rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
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

        // Set cooldown
        canShoot = false;
    }
}
