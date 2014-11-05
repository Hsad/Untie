using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
public class television : MonoBehaviour {
	private Text clip_intel;
	//private bool next_arc = false;
	private int clip_number = 0;
	private List<string> clips = new List<string>();
	private GameObject conversation;
	// Use this for initialization
	void Start () {
		//adding clips
		conversation = GameObject.Find("tv_canvas");

		if (conversation == null){
			print ("failed");
		}
		clip_intel = GetComponent<Text>();
		if (clip_intel == null){
			print("failed");
		}
		var sr = new StreamReader(Application.dataPath +"/scripts/tv_1_script.txt");
		var contents = sr.ReadToEnd();
		var lines = contents.Split("\n"[0]);
		int temp = 0;
		for ( temp = 0 ; temp < lines.Length ; temp ++){
			clips.Add(lines[temp]);
		}
		//story_book.Add("Pieer: sadaksj");
		//story_book.Add("Ivan:sakjalkjsd");
		clip_intel.text = clips[clip_number];
		//conversation.SetActive(false);
	}
	
	public void next_arc(){
		//gets called when next story arc is needed
		conversation.SetActive(true);
	}
	// Update is called once per frame
	public void next_page(){
		//use nextarc to stop in the middle of big text document
		if (clip_number < (clips.Count -1)){
			clip_number ++;
			clip_intel.text = clips[clip_number];
		}else{
			//next arc theory is play entire arc, then stop and close, next can chang it to true and so on and so 
			//next_arc = true;
			conversation.SetActive(false);
		}
		
	}
}
