using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 4f;
    public Camera camera;
    private Rigidbody rb;

    // Adjust this value to control mouse sensitivity
    public float sensitivity = 0.01f;

    private float previousX = 0.0f;
    private float previousY = 0.0f;
    
    [Client]
    void Start()
    {
        if (isLocalPlayer)
        {
            rb = GetComponent<Rigidbody>();
	    camera.gameObject.SetActive(true);
        } else
        {
	    camera.gameObject.SetActive(false);
        }
    }
    
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
	    rb.transform.position += movement;
	    
	    // Calculate mouse X movement change
	    float mouseXRaw = Input.mousePosition.x - 1094 / 2;
	    float mouseMovedX = mouseXRaw - previousX;
	    previousX = mouseXRaw;
	    float mouseX = mouseMovedX * sensitivity;
	    
	    rb.transform.Rotate(Vector3.up * mouseMovedX);
	    
	    // Calculate mouse Y movement change
	    float mouseYRaw = Input.mousePosition.y - 1094 / 2;
	    float mouseMovedY = mouseYRaw - previousY;
	    previousY = mouseYRaw;
	    float mouseY = mouseMovedY * sensitivity;
	    
	    camera.transform.Rotate(Vector3.left * mouseMovedY);
	    
	    if (Input.GetKeyDown(KeyCode.Space))
            {
	        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
