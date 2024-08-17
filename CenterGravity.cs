using Mirror;
using UnityEngine;

public class CenterGravity : NetworkBehaviour
{
    //public Transform centerOfGravity; // The center of gravity point
    public Vector3 centerOfGravity;

    public float gravityStrength = 9.81f; // Strength of gravity

    void FixedUpdate()
    {
        // Calculate the direction from the object to the center of gravity
        Vector3 gravityDirection = (centerOfGravity - transform.position).normalized;

        // Apply gravity force towards the center
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(gravityDirection * gravityStrength * rb.mass);
    }
}
