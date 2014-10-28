using UnityEngine;
using System.Collections;

public class Dossier : MonoBehaviour {

	public string Name;//name of the person on file

	//other relevant dossier stuff goes here

	//this stuff is for handling animation

	public Animator anim;

	void Awake(){
		anim = GetComponent<Animator>();
	}

	public void Update(){
		anim.SetBool("showing",CameraLook.isInteracting);
	}

}
