using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class placeNote : MonoBehaviour {


	//this script is called every time a mission is linked up
	//brings up the UI prompt where the player chooses which option to take

	IgnoreRaycast selfnote;
	IgnoreRaycast othernote;

	public GameObject buttonfab;
	public GameObject timeselector;
	
	public Text comrade;
	public GameObject actiontext;
	public GameObject timetext;
	public Text targettext;


	public int time;
	public string action;

	bool tset,aset = false;//have the values been set yet?




	string[] person_actions = new string[]{"bribe","assassinate","track","threaten"};
	string[] place_actions = new string[]{"bombing","robbery","propaganda"};
	string[] thing_actions = new string[]{"acquire","destroy","sabotage"};

	private List<GameObject> buttons = new List<GameObject>();

	public void setup(IgnoreRaycast self, IgnoreRaycast target){//set up the note
		gameObject.SetActive(true);//display self
		selfnote = self;
		othernote = target;
		comrade.text = self.d.name;
		targettext.text = target.d.name;
	}

	void reset(){
		//write the final text to the note
		selfnote.timenote.GetComponentInChildren<Text>().text = comrade.text + " will " + action + " " + targettext.text + " at " + (time/100).ToString("00") + ":" + (time%100).ToString("00");
		selfnote.time = time;
		selfnote.action = action;

		//set values back to default

		comrade.text = "<comrade>";
		targettext.text = "<target>";
		actiontext.GetComponent<Text>().text = "<action>";
		timetext.GetComponent<Text>().text = "<time>";


		tset = aset = false;


		gameObject.SetActive(false);//hide this thing
	}



	public void create_action(){//make the options for the category of choice pop up
		string category = othernote.d.type;//options are based on what kind of object the target is 


		string[] options = new string[0];
		if(category == "person"){
			options = person_actions;
		}
		if(category == "place"){
			options = place_actions;
		}
		if(category == "thing"){
			options = thing_actions;
		}

		RectTransform rct = buttonfab.transform as RectTransform;

		for(int i=0;i<options.Length;i++){
			GameObject g = Instantiate(buttonfab) as GameObject;
			g.transform.parent = gameObject.transform;
			g.transform.localPosition = new Vector2(0, rct.sizeDelta.y * i);
			Text txt = g.GetComponentInChildren<Text>();
			txt.text = options[i];

			buttons.Add(g);
		}

		actiontext.GetComponent<Button>().interactable = false;
		timetext.GetComponent<Button>().interactable = false;
	}

	public void create_time(){
		GameObject g = Instantiate(timeselector) as GameObject;
		g.transform.parent = gameObject.transform;
		g.transform.localPosition = new Vector2(0, 0);
		buttons.Add(g);

		actiontext.GetComponent<Button>().interactable = false;
		timetext.GetComponent<Button>().interactable = false;
		
	}

	void clear_options(){
		foreach(GameObject g in buttons){
			Destroy(g);
		}
		actiontext.GetComponent<Button>().interactable = true;
		timetext.GetComponent<Button>().interactable = true;

		if(tset && aset){//if both options are now set, close this interface and write the data on the board
			reset();
		}


	}

	public void set_action(Text txt){
		print("choice is: " + txt.text);
		actiontext.GetComponent<Text>().text = txt.text;
		action = txt.text;
		aset = true;
		clear_options();

	}

	public void set_time(timesetter t){
		time = t.hour * 100 + t.minute;
		print("time is: " + time);
		timetext.GetComponent<Text>().text = t.hour.ToString("00") + ":" + t.minute.ToString("00");
		tset = true;
		clear_options();

	}



}
