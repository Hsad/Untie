using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class notes_changing : MonoBehaviour {
	public Text notes;
	public int num_pages =0;
	private List<string> data = new List<string>();
	// Use this for initialization
	void Start () {
		notes = GetComponent<Text>();
		data.Add("hiyo");
		data.Add("boo");
		data.Add("halloween");
	}
	
	// Update is called once per frame
	void Update () {
		//notes.text = ("his");
		//check if need to add notes
		//
	}
	public void page_change(){
		num_pages ++;
		notes.text = data[num_pages];
	}
	public void prev_page(){
		if( num_pages > 0){
			num_pages ++;
			notes.text = data[num_pages];
		}
	}
}
