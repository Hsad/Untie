﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class PlayerState : Singleton<PlayerState> {
	public int publicOpinion = 0;//public opinion level
	public int violence = 0;//amount of violence inflicted on civilians attributed to your group
	private int clock = 1200;//the time of day (in form: int hhmm)
	int day = 0;
	
	[SerializeField]
	public Sprite ropeSprite;//have to put this here because reasons
	public GameObject noteFab;//also have to put this here because reasons
	public GameObject arrowFab;//see above

	public placeNote notePrompt;//reference to the note writing interface


	public JSONNode tv_messages;
	public JSONNode phone_messages;

	public DialogueQueue dq;


	
	public Dictionary<string,int> materials = new Dictionary<string, int>();//table of each material and the quantity acquired

	//money should also be a resource

	public List<Dossier> intel = new List<Dossier>();//keep track of all player intel

	public List<string> notes = new List<string>();//keeps track of extra information, each string = one page of the notebook



	void Start(){
		TextAsset f = Resources.Load("Dialogue/tv_messages") as TextAsset;
		tv_messages = JSON.Parse(f.text);
		f = Resources.Load("Dialogue/phone_messages") as TextAsset;
		phone_messages = JSON.Parse(f.text);
		materials["guns"] = 1;
	}


	public int get_time(){
		return clock;
	}

	public void set_time(int newtime){
		if(newtime < clock){//assume next day
			day++;
		}
		clock = newtime;
	}

	public void update_time(){//increment the time
		int hour = clock/100;
		int minute = clock%100;

		if(++minute > 59){
			minute = 0;
			hour += 1;
		}
		if(hour > 23){
			hour = 0;
			day ++;
		}
		clock = hour * 100 + minute;
	}

	public bool check_materials(string temp_change, int temp_num){
		if (materials.TryGetValue(temp_change, out temp_num)){
			materials[temp_change] += temp_num;
			if ( materials[temp_change] > 0){
				return true;
			}
			return false;
		}else{
			return false;
		}
	}
	public void update_materials(string change, int change_num){
		if (materials.TryGetValue(change,out change_num)){
			materials[change] += change_num;
		}else{
			materials.Add(change, change_num);
		}
	}
	public void update_notes(string new_info){
		notes.Add(new_info);
	}
}
