﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
//using UnityEngine.EventSystems;
public class Phone : MonoBehaviour {
	private List<Numbers> book;
	private List<string> anton_intel;
	private int page_number = 1;
	private int max_page = 2;
	public display_phone_story p_story;
	public class Numbers{
		private string name;
		private int page;
		private GameObject button;
		public Numbers(string title,int page_num){
			button = GameObject.Find (title);
			name = title;
			page = page_num;
			if ((page_num > 1 || page_num == -2) && button) {
				button.SetActive(false);
			}
		}
		public int get_page(){
			return page;
		}
		public string get_title(){
			return name;
		}
		public GameObject get_button(){
			return button;
		}
	}
	void Start () {
		//create the list of button names
		book = new List<Numbers>();
		anton_intel = new List<string>();
		//adding the button names
		var temp = new Numbers("anton",1);
		book.Add(temp);
		var temp2 = new Numbers("extra",1);
		book.Add (temp2);
		var temp3 = new Numbers("next_button",-1);
		book.Add (temp3);
		var temp4 = new Numbers("other",2);
		book.Add(temp4);
		var temp5 = new Numbers("Prev_button", -2);
		book.Add(temp5);

		//creating the text/ phone story clips
		var sr = new StreamReader(Application.dataPath +"/scripts/anton_phone.txt");
		var contents = sr.ReadToEnd();
		var lines = contents.Split("\n"[0]);
		int temp8 = 0;
		for ( temp8 = 0 ; temp8 < lines.Length ; temp8 ++){
			anton_intel.Add(lines[temp8]);
		}
	}
	void disable_buttons(string ignore){
		//Iterating through all the buttons and disabling them
		//unless its the button pressed
		foreach(Numbers temp in book){
			//checks if its the button pressed
			if (temp.get_title() == ignore){
				continue;
			}
			//find the button and if it exist
			//disable it
			var obj = temp.get_button();
			if (obj){
				obj.SetActive(false);
			}
		}
	}
	void new_page(){
		foreach(Numbers temp in book){
			//checks if its the button pressed
			if (temp.get_page() == -1 || temp.get_page() == page_number || (page_number >1 && temp.get_page() == -2)){
				var obj = temp.get_button();
				if (obj){

					obj.SetActive(true);
				}
				continue;
			}
			//find the button and if it exist
			//disable it
			var obj2 = temp.get_button();
			if (obj2){
				obj2.SetActive(false);
			}
		}
	}
	void reactivate_buttons(){
		//reactivates all the button
		foreach(Numbers temp in book){
			var obj = temp.get_button();
			//print (temp.get_page()+ page_number);
			if (obj && (temp.get_page() == page_number)){
				//print (page_number);
				obj.SetActive(true);
			}
		}
	}
	public void mouse(){
		print ("yes");
	}
	public void call_anton(){
		disable_buttons("anton");
		p_story.news (anton_intel[0]);
		//open buttons up again
		reactivate_buttons();
	}
	public void call_extra(){
		disable_buttons("extra");
	}
	public void call_next(){
		if ( page_number < max_page ){
			page_number ++;
			new_page();
		}

	}
	public void call_prev(){
		if ( page_number > 0){
			page_number --;
			new_page();
		}

	}
	/*public Dictionary<string,string> contactInfo; //dictionary of <Name,phone#>

	public void call(string number){
		//Call a phone number and do something based on the state of the game
	}*/
}
