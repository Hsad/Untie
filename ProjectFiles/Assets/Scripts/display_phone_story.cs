using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class display_phone_story : MonoBehaviour {
	public Text phone_story;
	public GameObject conversation;
	// Use this for initialization
	public display_phone_story(){

	}
	void Start () {
		conversation = GameObject.Find("phone_information");
		conversation.SetActive(false);
		phone_story = GetComponent<Text>(); 
	}
	
	// Update is called once per frame
	public void news (string info) {
		conversation.SetActive(true);
		phone_story.text= info;
	}
	public void hang(){
		conversation.SetActive(false);
	}
}
