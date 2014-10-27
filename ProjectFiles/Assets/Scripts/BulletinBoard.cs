using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletinBoard : MonoBehaviour {

	//This class keeps track of the current state of the bulletin board

	public Dictionary<GameObject,Dossier> nodes = new Dictionary<GameObject,Dossier>();//list of every event slot

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//post-it notes next to links between nodes
	//specify time and action --> actions are limited, player makes choice


	//your core people are in fixed board positions
	//make connections to specify their next move
	//distance they must travel relative to actual time of objective determines failure chance

}
