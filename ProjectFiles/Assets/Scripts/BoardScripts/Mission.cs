using UnityEngine;
using System.Collections;
using System.IO;
using SimpleJSON;

public class Mission{
	public JSONNode node;
	public IgnoreRaycast target;
	public int missiontime;

	
	public Mission(){
	}
	public Mission(JSONNode n, IgnoreRaycast t, int m){
		node = n;
		target = t;
		missiontime = m;
	}

	public bool check_prereqs(){//gets called before running the mission
		Debug.Log(node.ToString());

		foreach (JSONArray pair in node["prerequisites"].AsArray){//treat each pair as materials for now
			string material = pair[0];
			int qty = int.Parse(pair[1]);

			if (PlayerState.Instance.check_materials(material, qty)){//if all of the required materials have been obtained
				PlayerState.Instance.update_materials(material, qty);//remove the materials from the materials log
				return true;//return success
			}else{
				return false;//return failure
			}
		}
		return true;
	}
	public bool check_success(){//gets called after running the mission
		//determinants for success: location, time, leeway
		//returns false if fail mission, true otherwise
		string location = node["requirements"][0];
		int time = int.Parse(node["requirements"][1]);
		int leeway = int.Parse(node["requirements"][2]);

		if(!(location == target.current_district.dname)){
			//Debug.Log("failed mission because wrong location");
			return false;
		}
		if(Mathf.Abs(time - missiontime) > leeway){
			//Debug.Log("failed mission because wrong time");
			return false;
		}
		return true;
	}
	public bool run(){
		//access player state and analyze the current data
		//and modify the rest of the program
		if(check_prereqs()){
			string result = check_success() ? "success" : "failure";

			Debug.Log("mission result: " + result);

			PlayerState.Instance.violence += node[result]["violence"].AsInt;
			PlayerState.Instance.publicOpinion += node[result]["public_opinion"].AsInt;

			Debug.Log ("node: " + node[result].ToString());


			foreach (JSONArray pair in node[result]["materials"].AsArray){//update materials based on success
				string material = pair[0];
				int qty = int.Parse(pair[1]);
				PlayerState.Instance.update_materials(material, qty);//remove the materials from the materials log
			}

			foreach (JSONArray pair in node[result]["dialogue"].AsArray){//update materials based on success
				string medium = pair[0];
				string act = pair[1];
				int index = int.Parse(pair[2]);

				Debug.Log (medium + " " + act + " " + index);

				string dialogue = "";
				if(medium == "tv"){
					dialogue = PlayerState.Instance.tv_messages[act][index];
					PlayerState.Instance.dq.add_dialogue(dialogue);
				}
				else if(medium == "phone"){
					dialogue = PlayerState.Instance.phone_messages[act][index];
					PlayerState.Instance.dq.add_dialogue(dialogue);
				}
			}

			foreach (JSONNode item in node[result]["intel"].AsArray){//add new intel
				string filename = item;
				PlayerState.Instance.intel.Add(new Dossier(filename));
			}

			return true;
		}
		return false;
	}
}
