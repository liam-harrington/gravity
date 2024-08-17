using Mirror;
using UnityEngine;

public class PlayerControllerJump : NetworkBehaviour
{
    public float jumpForce = 4f;
    private Rigidbody rb;
    
    [Client]
    void Start()
    {
        if (isLocalPlayer)
        {
            rb = GetComponent<Rigidbody>();
        }
    }
    
    [Client]
    void Update()
    {
        if (isLocalPlayer)
        {
	    if (Input.GetKeyDown(KeyCode.Space))
            {
	        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
