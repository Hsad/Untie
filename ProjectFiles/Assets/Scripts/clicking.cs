using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class clicking : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			print ("clicking");
			print (EventSystem.current);
		}
		if (EventSystem.current.IsPointerOverGameObject() == true){
			print("yesy");
		}
	}
}
