using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	public float moveSpeed = 10f;
	
	void Update(){

		if(Input.GetKeyDown(KeyCode.E)){//begin or end interaction
			if(CameraLook.isInteracting){
				print("ending interaction");
				CameraLook.isInteracting = false;
			}else{
				print("beginning interaction");
				CameraLook.isInteracting = true;
			}
		}


		if(!CameraLook.isInteracting){//only move if camera isn't locked
			Vector3 right = transform.right;
			Vector3 fwdHorizontal = Vector3.Cross(right, Vector3.up);
			
			//Get the input and scale it appropriately
			Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
			Vector3 movement = (right * input.x + fwdHorizontal * input.z) * Time.deltaTime * moveSpeed;

			transform.parent.position += movement;
		}else{//otherwise just strafe a bit
			float mouseX = 100 * ((Input.mousePosition.x - Screen.width / 2) / (Screen.width / 2));



			if(Mathf.Abs(mouseX) >= 90){
				Vector3 movement = (transform.right * mouseX / 500) * Time.deltaTime * moveSpeed;
				transform.parent.position += movement;
			}
			

		}
	}
}
