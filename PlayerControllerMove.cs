using Mirror;
using UnityEngine;

public class PlayerControllerMove : NetworkBehaviour
{
    public float moveSpeed = 5f;
    
    [Client]
    void Update()
    {
        if (isLocalPlayer)
        {
	    // Handle player input
	    float horizontalInput = Input.GetAxis("Horizontal");
	    float verticalInput = Input.GetAxis("Vertical");

	    // Calculate the movement vector in local space
	    Vector3 input = new Vector3(horizontalInput, 0f, verticalInput);
	    Vector3 movement = transform.TransformDirection(input.normalized) * moveSpeed * Time.deltaTime;

	    // Apply movement to the Rigidbody
	    transform.position += movement;
        }
    }
}
