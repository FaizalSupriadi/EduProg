using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;
	public Transform playerBody;
	float xRotation = 0f;
	float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        if(Input.GetMouseButtonDown(1)){

        	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);

        	
        }
        else if(Input.GetMouseButtonUp(1)){
        	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
        }
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
		playerBody.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);

    }
}
