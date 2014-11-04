using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class phone_names_change : MonoBehaviour {
	public Text names;
	public int num_phone =0;
	public List<string> names_phones = new List<string>();
	// Use this for initialization
	void Start () {
		names = GetComponent<Text>();
		names_phones.Add("hiyo\nhi");
		names_phones.Add("boo\nno");
		names_phones.Add("halloween\nkobe");
		names.text = names_phones[num_phone];
	}
	
	public void page_change(){ 
		if (num_phone == (names_phones.Count - 1)){
			names.text = names_phones[num_phone];
		}else{
			num_phone ++;
			names.text = names_phones[num_phone];
		}
		
	}
	public void add_page(string new_intel){
		names_phones.Add (new_intel);
		num_phone = (names_phones.Count - 1);
	}
	public void prev_page(){
		if( num_phone > 0){
			num_phone --;
			names.text = names_phones[num_phone];
		}
	}
}
