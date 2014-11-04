using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerState : Singleton<PlayerState> {
	public int publicOpinion = 0;//public opinion level
	public int violence = 0;//amount of violence inflicted on civilians attributed to your group
	public int clock = 0;
	[SerializeField]
	public Sprite ropeSprite;//have to put this here because reasons
	public GameObject noteFab;//also have to put this here because reasons
	public GameObject arrowFab;//see above
	


	
	public Dictionary<string,int> materials = new Dictionary<string, int>();//table of each material and the quantity acquired

	//money should also be a resource

	public List<Dossier> intel = new List<Dossier>();//keep track of all player intel

	public List<string> notes = new List<string>();//keeps track of extra information, each string = one page of the notebook


	//----------------------
	// Notes:
	//	Dossiers should all be generated with a script by reading a JSON file or something
	public int get_time(){
		return clock;
	}
	public void update_time(){
		clock ++;
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
	public void update_public(){
		publicOpinion ++;
	}
	public void update_violence(){
		violence ++;
	}
	public void update_notes(string new_info){
		notes.Add(new_info);
	}
}
