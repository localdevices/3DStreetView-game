using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    
    bool lockCursor = true; // I don't remember why
    
    float mouseSensitivity = 1.0f;
    float keyRotSensitivity = 6.0f;
    float rotDamper = 2.0f;
    float keySlewSensitivity = 6.0f;
    float slewDamper = 3.0f;
    float minSpeedSqrt = 0.1f;

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
        float d = (1.0f - (rotDamper * Time.deltaTime));
	if(Input.GetKey(";")) yaw += keyRotSensitivity;
	if(Input.GetKey("k")) yaw -= keyRotSensitivity;
	yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
	yaw *= d;
	transform.Rotate(Vector3.up * yaw * Time.deltaTime);
	
	if(Input.GetKey("o")) pitch -= keyRotSensitivity * yInvert;
	if(Input.GetKey("l")) pitch += keyRotSensitivity * yInvert;
	pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * yInvert;
	pitch *= d;
	cameraPitch += pitch * Time.deltaTime;
	cameraPitch = Mathf.Clamp(cameraPitch, -85.0f, 85.0f);
	playerCamera.localEulerAngles = Vector3.right * cameraPitch;	
    }
    
    void UpdateMovement()
    {
	float m = Time.deltaTime * keySlewSensitivity;
        if(Input.GetKey("e")) vTOL += m;
	if(Input.GetKey("q")) vTOL -= m;
	if(Input.GetKey("d")) strafe += m;
	if(Input.GetKey("a")) strafe -= m;
	if(Input.GetKey("w")) forward += m;
	if(Input.GetKey("s")) forward -= m;
        if(Input.GetKey("space"))
	{
	    float brake = (1.0f - (slewDamper * Time.deltaTime));
	    vTOL *= brake;
	    if(vTOL * vTOL < minSpeedSqrt) vTOL = 0;
	    strafe *= brake;
	    if(strafe * strafe < minSpeedSqrt) strafe = 0;
	    forward *= brake;
	    if(forward * forward < minSpeedSqrt) forward = 0;
	}
	
	Vector2 keySlew = new Vector2(strafe, forward);
	
	Vector3 velocity = (transform.forward * keySlew.y + transform.right * keySlew.x) + transform.up * vTOL;

	controller.Move(velocity * Time.deltaTime);
    }

}
