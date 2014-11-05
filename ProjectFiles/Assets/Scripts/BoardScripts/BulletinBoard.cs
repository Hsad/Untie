using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletinBoard : MonoBehaviour {

	//This class keeps track of the current state of the bulletin board

	public District[] districts;

	// Use this for initialization
	void Start () {
		//get a list of every district object
		districts = GetComponentsInChildren<District>();
	}
	
	public void step_time(){
		//only comrades can be given missions so look for comrades


		//for each district
		//	for each node in the district with a set target
		//		find the node with the shortest target time

		Dictionary<int,List<IgnoreRaycast>> temp = new Dictionary<int, List<IgnoreRaycast>>();

		int curmin = int.MaxValue;

		foreach(District district in districts){
			foreach(GameObject g in district.nodes){
				IgnoreRaycast irc = g.GetComponent<IgnoreRaycast>();
				if(irc.is_comrade && irc.target != null){//only consider comrades with active targets
					int timediff = irc.time - PlayerState.Instance.get_time();
					print("time difference: " + timediff);
					if(timediff < 0) timediff += 2400;//roll time over to next day
					if(!temp.ContainsKey(timediff)){
						temp[timediff] = new List<IgnoreRaycast>();
					}
					temp[timediff].Add(irc);
					if(timediff < curmin){
						curmin = timediff;
					}
				}
			}
		}

		if(curmin == int.MaxValue) return;//if no missions, ignore

		//get all comrades with the shortest time until mission and carry out their missions
		foreach(IgnoreRaycast irc in temp[curmin]){
			//execute the mission
			PlayerState.Instance.set_time(irc.time);

			//set comrade's new location to that of mission
			irc.gameObject.transform.localPosition = irc.target.transform.localPosition;

			IgnoreRaycast igrt = irc.target.GetComponent<IgnoreRaycast>();
			irc.current_district = igrt.current_district;


			//destroy mission object
			igrt.current_district.nodes.Remove(irc.target);
			Destroy(irc.target);
			irc.current_mission = null;//set the current mission to null
		}
	}
}
