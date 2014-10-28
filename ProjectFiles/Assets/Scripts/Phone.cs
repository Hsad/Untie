using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Phone : MonoBehaviour {

	private bool clicked = false;
	private bool inside = false;
	private List<Numbers> book;
	private int current_page  = 1; 
	//Stuct for the numbers in the pages
	public class Numbers{
		//store the name/number of the struct
		private string name;
		//Storing whether or not to show the number
		private bool show;
		//Storing on which page of book the number is on
		private int page;
		//stroing the location of the button on the GUI interface
		private int pos_x;
		private int pos_y;
		//Default constuctor
		public Numbers(string title,int start_x, int start_y, int page_num){
			name = title;
			pos_x = start_x;
			pos_y = start_y;
			page = page_num;
			show = true;
		}
		//returns the current stats of the button
		public bool showing(){
			return show;
		}
		//changing the boolean of the button
		public bool set_show(){
			show = !show;
			return show;
		}
		//returning the x position
		public int get_x(){
			return pos_x;
		}
		//returning the y position
		public int get_y(){
			return pos_y;
		}
		//collecting the page on which the number is on
		public int get_page(){
			return page;
		}
		//returning the name
		public string get_name(){
			return name;
		}
	}
	void Start () {
		//create the list of numbers
		book = new List<Numbers>();
		//Adding to the phone book the numbers player can call and the pages
		Numbers close = new Numbers("Close",10,120,1);
		book.Add(close);
		var next = new Numbers("Next",10,70,1);
		book.Add(next);
		var number_1 = new Numbers("978-935-9386", 10,10,1);
		book.Add(number_1);
		var number_2  = new Numbers("781-965-8569", 10,40,1);
		book.Add(number_2);
		var number_3 = new Numbers("985-968-9365", 10,10,2);
		book.Add(number_3);
		var prev = new Numbers("Previous", 10, 95,2);
		book.Add(prev);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*public Dictionary<string,string> contactInfo; //dictionary of <Name,phone#>

	public void call(string number){
		//Call a phone number and do something based on the state of the game
	}*/
}
