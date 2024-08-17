using Mirror;
using UnityEngine;

public class AlignToCenter : NetworkBehaviour
{
    //public Transform centerOfGravity; // Reference to the center point transform
    public Vector3 centerOfGravity;

    void Update()
    {
        if (isLocalPlayer)
        {
            // Calculate the direction vector from the GameObject to the center point
            Vector3 lookDirection = centerOfGravity - transform.position;

            // Calculate the rotation to align the GameObject's up direction with the center point
            Quaternion targetRotation = Quaternion.FromToRotation(-transform.up, lookDirection.normalized) * transform.rotation;

            // Apply the rotation to the GameObject
            transform.rotation = targetRotation;
        }
    }
}
