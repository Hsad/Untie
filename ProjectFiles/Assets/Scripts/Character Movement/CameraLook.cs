using UnityEngine;
using System.Collections;


public class CameraLook : MonoBehaviour
{
	public float sensitivity = 3f;


	public static bool isInteracting = false;
	
	void Update(){
		Vector3 mouseMovement;
		Vector3 currentEuler;
		Vector3 newEuler;


		if(!isInteracting){
			Screen.lockCursor = true;

			mouseMovement = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
			mouseMovement *= sensitivity;
			
			//Retrieve the camera's current rotation, adjust it, and set it back.
			currentEuler = transform.localEulerAngles;
			newEuler = currentEuler + mouseMovement;
			transform.localEulerAngles = newEuler;
		}else{
			Screen.lockCursor = false;

			mouseMovement = new Vector3(-Input.GetAxis("Mouse Y")/10, 0f, 0f);
			mouseMovement *= sensitivity;
			
			//Retrieve the camera's current rotation, adjust it, and set it back.
			currentEuler = transform.localEulerAngles;
			newEuler = currentEuler + mouseMovement;
			transform.localEulerAngles = newEuler;
		}


	}
}
