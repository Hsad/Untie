using UnityEngine;
using System.Collections;

public class IntelFolder : MonoBehaviour {
	public GameObject front;
	public GameObject dossier; //the dossier object

	//animate the intel folder with these
	private Animator anim1;
	private Animator anim2;

	private int curindex = 0;//current dossier index of the folder

	private GameObject curd;//the current dossier
	
	void Awake(){
		anim1 = GetComponent<Animator>();
		anim2 = front.GetComponent<Animator>();

		//start out by adding comrades to intel
		PlayerState.Instance.intel.Add(new Dossier("AntonNovik"));
		PlayerState.Instance.intel.Add(new Dossier("DmitryMoroz"));
		//PlayerState.Instance.intel.Add(new Dossier("AntonNovik"));
		//PlayerState.Instance.intel.Add(new Dossier("AntonNovik"));



		//set first intel
		PlayerState.Instance.intel[0].displayData(dossier);
	}


	public void nextDossier(){//display the next dossier in the files
		if(PlayerState.Instance.intel.Count > 0){
			print("setting next dossier");
			Dossier next = PlayerState.Instance.intel[((++curindex)%PlayerState.Instance.intel.Count)];
			next.displayData(dossier);
		}

	}

	
	public void Update(){
		anim1.SetBool("showing",CameraLook.isInteracting);
		anim2.SetBool("showing",CameraLook.isInteracting);
	}
}
