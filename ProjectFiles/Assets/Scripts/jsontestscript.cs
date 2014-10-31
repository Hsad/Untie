using UnityEngine;
using System.Collections;

public class jsontestscript : MonoBehaviour {

	public Dossier dossier;

	public string filename;
	string lastfilename;

	void Update(){
		if(lastfilename != filename){
			dossier.fromFile(filename);
			lastfilename = filename;
		}
	}
}
