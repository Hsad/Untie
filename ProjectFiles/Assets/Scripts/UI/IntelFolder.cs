using UnityEngine;
using System.Collections;

public class IntelFolder : MonoBehaviour {
	public GameObject front;
	private Animator anim1;
	private Animator anim2;
	
	void Awake(){
		anim1 = GetComponent<Animator>();
		anim2 = front.GetComponent<Animator>();
	}
	
	public void Update(){
		anim1.SetBool("showing",CameraLook.isInteracting);
		anim2.SetBool("showing",CameraLook.isInteracting);
	}
}
