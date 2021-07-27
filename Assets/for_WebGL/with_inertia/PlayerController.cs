using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    
    [SerializeField] float mouseSensitivity = 1.0f;
    [SerializeField] float keyRotSensitivity = 0.01f;
    
    [SerializeField] bool lockCursor = true;
    
    float cameraPitch = 0.0f;
    float vTOL = 0.0f;
    float strafe = 0.0f;
    float forward = 0.0f;
    float yaw = 0.0f;
    float pitch = 0.0f;
    float yInvert = 1;
    

    
    CharacterController controller = null;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
	
        if(lockCursor)
	{
	    Cursor.lockState = CursorLockMode.Locked;
	    Cursor.visible = false;
	}
    }

    void Update()
    {
        UpdateSettings();
        UpdateRotation();
	UpdateMovement();
    }
    
    void UpdateSettings()
    {
        // Quit on escape key; not needed for WebGL build
        //if(Input.GetKey("escape"))
	//{
	//    Application.Quit();
	//}
	if(Input.GetKeyUp("y"))
	{
	    yInvert *= -1;
	}
    }
    
    void UpdateRotation()
    {
	if(Input.GetKey(";")) yaw += keyRotSensitivity;
	if(Input.GetKey("k")) yaw -= keyRotSensitivity;
	yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
	yaw *= 0.95f;
	transform.Rotate(Vector3.up * yaw * Time.deltaTime);
	
	if(Input.GetKey("o")) pitch -= keyRotSensitivity * yInvert;
	if(Input.GetKey("l")) pitch += keyRotSensitivity * yInvert;
	pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * yInvert;
	pitch *= 0.95f;
	cameraPitch += pitch * Time.deltaTime;
	cameraPitch = Mathf.Clamp(cameraPitch, -85.0f, 85.0f);
	playerCamera.localEulerAngles = Vector3.right * cameraPitch;	
    }
    
    void UpdateMovement()
    {
        float t = Time.deltaTime;
        if(Input.GetKey("e")) vTOL += 6.0f * t;
	if(Input.GetKey("q")) vTOL -= 6.0f * t;
	if(Input.GetKey("d")) strafe += 6.0f * t;
	if(Input.GetKey("a")) strafe -= 6.0f * t;
	if(Input.GetKey("w")) forward += 6.0f * t;
	if(Input.GetKey("s")) forward -= 6.0f * t;
        if(Input.GetKey("space"))
	{
	    vTOL *= 0.95f;
	    strafe *= 0.95f;
	    forward *= 0.95f;
	}
	
	Vector2 keySlew = new Vector2(strafe, forward);
	
	Vector3 velocity = (transform.forward * keySlew.y + transform.right * keySlew.x) + transform.up * vTOL;

	controller.Move(velocity * Time.deltaTime);
    }

}
