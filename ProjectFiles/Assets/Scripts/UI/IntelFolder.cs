using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

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
		PlayerState.Instance.intel.Add(new Dossier("IvanRudenko"));
		PlayerState.Instance.intel.Add(new Dossier("MariaBoyko"));

		//add some objective for test
		PlayerState.Instance.intel.Add(new Dossier("Test1"));



		//set first intel
		PlayerState.Instance.intel[0].displayData(dossier);
	}


	public void nextDossier(){//display the next dossier in the files
		if(PlayerState.Instance.intel.Count > 0){
			Dossier next = PlayerState.Instance.intel[((++curindex)%PlayerState.Instance.intel.Count)];
			next.displayData(dossier);
		}

	}


	public void p_exit(){
		//if the mouse is over the thing, set show to true

		//if the mouse is not over the thing, set show to false only if nothing is being dragged

		if(!EventSystem.current.IsPointerOverGameObject()){
			anim1.SetBool("showing",false);
			anim2.SetBool("showing",false);
		}
	}

	public void p_click(){
		//if(EventSystem.current.currentSelectedGameObject == gameObject){
			bool showing = anim1.GetBool("showing");
			anim1.SetBool("showing",!showing);
			anim2.SetBool("showing",!showing);
		//}
	}

	public void p_enter(){
		anim1.SetBool("showing",true);
		anim2.SetBool("showing",true);
	}

	
	public void Update(){
		if(!CameraLook.isInteracting){
			anim1.SetBool("showing",false);
			anim2.SetBool("showing",false);
		}
	}
}
