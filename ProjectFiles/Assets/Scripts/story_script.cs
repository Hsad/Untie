using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
public class story_script : MonoBehaviour {
	private Text story;
	//private bool next_arc = false;
	private int page_number=0;
	private List<string> story_book = new List<string>();
	private GameObject conversation;
	// Use this for initialization
	void Start () {
		conversation = GameObject.Find("Story_canvas");
		if (conversation == null){
			print ("failed");
		}
		story = GetComponent<Text>();
		var sr = new StreamReader(Application.dataPath +"/scripts/story_proto.txt");
		var contents = sr.ReadToEnd();
		var lines = contents.Split("\n"[0]);
		int temp = 0;
		for ( temp = 0 ; temp < lines.Length ; temp ++){
			story_book.Add(lines[temp]);
		}
		//story_book.Add("Pieer: sadaksj");
		//story_book.Add("Ivan:sakjalkjsd");
		story.text = story_book[page_number];
	}
	public void next_arc(){
		//gets called when next story arc is needed
		conversation.SetActive(true);
	}
	// Update is called once per frame
	public void next_page(){
		//use nextarc to stop in the middle of big text document
		if (page_number < (story_book.Count -1)){
			page_number ++;
			story.text = story_book[page_number];
		}else{
			//next arc theory is play entire arc, then stop and close, next can chang it to true and so on and so 
			//next_arc = true;
			conversation.SetActive(false);
		}

	}
}
