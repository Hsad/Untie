using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SimpleJSON;
[System.Serializable]
public class Dossier: System.Object{

	//visual data
	public Sprite photo;
	public string biotext, details;
	public bool is_comrade = false;
	public JSONNode node;


	//intel values
	public string name,type, prerequisites, inputs, success_vars, failure_vars,success_weights;


	public Dossier(){
	}

	public Dossier(string filename){
		fromFile(filename);
	}


	public void displayData(GameObject obj){//apply this script's information to the in-game object (for viewing)
		Transform ms = obj.transform.Find("Mugshot");
		ms.GetComponent<Image>().sprite = photo;
		ms.GetComponent<DragMe>().d = this;
		obj.transform.Find("BioText").GetComponent<Text>().text = biotext;
		obj.transform.Find("DetailText").GetComponent<Text>().text = details;



	}




	public void fromFile(string filename){//set the variables for this document from a file
		TextAsset f = Resources.Load("IntelData/" + filename) as TextAsset;
		if(f != null){
			node = JSON.Parse(f.text);

			//prerequisites = node["prerequisites"];
			//inputs = node["inputs"];
			//success_vars = node["success_vars"];
			//failure_vars = node["failure_vars"];
			//success_weights = node["success_weights"];

			type = node["type"];
			photo = Resources.Load<Sprite>("Photos/" + node["photo"]);
			biotext = node["biotext"];
			details = node["details"];
			name = node["name"];
			is_comrade = node["comrade"].AsBool;
		}else{
			Debug.Log("Invalid file: " + filename);
		}

	}
}
