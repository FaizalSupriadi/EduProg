using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraLook : MonoBehaviour
{
	public float mouseSensitivity = 100f;
	public Transform playerBody;
	float xRotation = 0f;
	float yRotation = 0f;
	int speed = 10;
	int limit =0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // This handles the camera look and walking
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        if(Input.GetKeyDown("a")){
        	if(limit != 6){
        		transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z );
				playerBody.position = new Vector3(playerBody.position.x - speed, playerBody.position.y, playerBody.position.z );
				limit += 1;
        	}
        	
        }

        if(Input.GetKeyDown("d")){
        	if(limit != -6){
	        	transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z );
				playerBody.position = new Vector3(playerBody.position.x + speed, playerBody.position.y, playerBody.position.z);
				limit -= 1;
        	}

        	
        }    
        if(Input.GetMouseButtonDown(1)){

        	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);
			playerBody.position = new Vector3(playerBody.position.x, playerBody.position.y, playerBody.position.z + 10);

        	
        }
        else if(Input.GetMouseButtonUp(1)){
        	transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
        	playerBody.position = new Vector3(playerBody.position.x, playerBody.position.y, playerBody.position.z - 10);

        }    

        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
		playerBody.localRotation = Quaternion.Euler(xRotation, yRotation, 0.0f);

    }
}
