using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerState : Singleton<PlayerState> {
	public int publicOpinion = 0;//public opinion level
	public int violence = 0;//amount of violence inflicted on civilians attributed to your group
	
	public Dictionary<string,int> materials;//table of each material and the quantity acquired

	//money should also be a resource

	public List<Dossier> intel;//keep track of all player intel

	public List<string> notes;//keeps track of extra information, each string = one page of the notebook

}
