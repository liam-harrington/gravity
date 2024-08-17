using Mirror;
using UnityEngine;

public class PlayerControllerLook : NetworkBehaviour
{
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
        }
        else
        {
	    camera.gameObject.SetActive(false);
        }
    }
    
    [Client]
    void Update()
    {
        if (isLocalPlayer)
        {
	    
	    // Calculate mouse X movement change
	    float mouseXRaw = Input.mousePosition.x;
	    float mouseMovedX = mouseXRaw - previousX;
	    previousX = mouseXRaw;
	    float mouseX = mouseMovedX * sensitivity;
	    
	    rb.transform.Rotate(Vector3.up * mouseMovedX);
	    
	    // Calculate mouse Y movement change
	    float mouseYRaw = Input.mousePosition.y;
	    float mouseMovedY = mouseYRaw - previousY;
	    previousY = mouseYRaw;
	    float mouseY = mouseMovedY * sensitivity;
	    
	    camera.transform.Rotate(Vector3.left * mouseMovedY);
        }
    }
}
