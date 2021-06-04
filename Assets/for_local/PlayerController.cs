using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    
    [SerializeField] float mouseSensitivity = 3.0f;
    [SerializeField] float keyRotSensitivity = 3.0f;
    [SerializeField] float joyRotSensitivity = 10.0f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float vertSpeed = 6.0f;
    [SerializeField] float joyFlySpeed = 6.0f;
    [SerializeField] float joyWalkSpeed = 3.0f;
    
    [SerializeField] bool lockCursor = true;
    
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
        if(Input.GetKey("escape"))
	{
	    Application.Quit();
	}
    }
    
    void UpdateRotation()
    {
    	float yaw = 0.0f;
	if(Input.GetKey(";")) yaw = keyRotSensitivity;
	if(Input.GetKey("k")) yaw = -keyRotSensitivity;
	yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
	yaw += Input.GetAxis("RightStickX") * joyRotSensitivity;
	transform.Rotate(Vector3.up * yaw);
	
	if(Input.GetKey("o")) cameraPitch += keyRotSensitivity;
	if(Input.GetKey("l")) cameraPitch -= keyRotSensitivity;
	cameraPitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
	cameraPitch += Input.GetAxis("RightStickY") * joyRotSensitivity;
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
        Vector2 iDir = new Vector2(Input.GetAxis("Horizontal") * joyWalkSpeed + keySlew.x, Input.GetAxis("Vertical") * joyWalkSpeed + keySlew.y);
	vTOL += Input.GetAxis("RightTrigger") * joyFlySpeed; //axis 6
	vTOL -= Input.GetAxis("LeftTrigger") * joyFlySpeed; //axis 3
	
	Vector3 velocity = (transform.forward * iDir.y + transform.right * iDir.x) * walkSpeed + transform.up * vTOL * vertSpeed;
	
	controller.Move(velocity * Time.deltaTime);
    }

}
