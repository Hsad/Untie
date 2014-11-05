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
		data.Add("Notes");
		data.Add("Notes\nboo");
		data.Add("Notes\nhalloween");
		notes.text = data[num_pages];
	}

	public void page_change(){ 
		if (num_pages == (data.Count - 1)){
			notes.text = data[num_pages];
		}else{
			num_pages ++;
			notes.text = data[num_pages];
		}

	}
	public void add_page(string new_intel){
		data.Add (new_intel);
		num_pages = (data.Count - 1);
	}
	public void prev_page(){
		if( num_pages > 0){
			num_pages --;
			notes.text = data[num_pages];
		}
	}
}
