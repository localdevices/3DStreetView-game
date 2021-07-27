using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    
    [SerializeField] float mouseSensitivity = 3.0f;
    [SerializeField] float keyRotSensitivity = 3.0f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float vertSpeed = 6.0f;
    
    [SerializeField] bool lockCursor = true;
    [SerializeField] bool invertedY = false;
    
    float cameraPitch = 0.0f;
    
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
    }
    
    void UpdateRotation()
    {
    	float yaw = 0.0f;
	if(Input.GetKey(";")) yaw = keyRotSensitivity;
	if(Input.GetKey("k")) yaw = -keyRotSensitivity;
	yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
	transform.Rotate(Vector3.up * yaw);
	
	if(Input.GetKey("o")) cameraPitch -= keyRotSensitivity;
	if(Input.GetKey("l")) cameraPitch += keyRotSensitivity;
	cameraPitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
	cameraPitch = Mathf.Clamp(cameraPitch, -85.0f, 85.0f);
	playerCamera.localEulerAngles = Vector3.right * cameraPitch;	
    }
    
    void UpdateMovement()
    {
        float vTOL = 0.0f;
        if(Input.GetKey("e")) vTOL = 1;
	if(Input.GetKey("q")) vTOL = -1;
	float strafe = 0.0f;
	if(Input.GetKey("d")) strafe = 1;
	if(Input.GetKey("a")) strafe = -1;
	float forward = 0.0f;
	if(Input.GetKey("w")) forward = 1;
	if(Input.GetKey("s")) forward = -1;
	Vector2 keySlew = new Vector2(strafe, forward);
	keySlew.Normalize();
	
	Vector3 velocity = (transform.forward * keySlew.y + transform.right * keySlew.x) * walkSpeed + transform.up * vTOL * vertSpeed;
	
	controller.Move(velocity * Time.deltaTime);
    }

}
