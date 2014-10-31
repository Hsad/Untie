using UnityEngine;
using System.Collections;

public class Notebook_script : MonoBehaviour {
	public string name;
	// Use this for initialization
	public Animator anim;
	
	void Awake(){
		anim = GetComponent<Animator>();
	}
	
	public void Update(){
		anim.SetBool("moving",CameraLook.isInteracting);
	}
}
