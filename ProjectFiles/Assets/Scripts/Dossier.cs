using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dossier : MonoBehaviour {

	public string biotext;//name, etc.
	public string details;//additional info
	public Sprite photo;//the mugshot sprite

	private Image ms;//reference to picture
	private Text bt;//reference to bio text
	private Text dt;//reference to details text

	void Awake(){
		ms = transform.Find("Mugshot").GetComponent<Image>();
		bt = transform.Find("BioText").GetComponent<Text>();
		dt = transform.Find("DetailText").GetComponent<Text>();
	}

	public void fromFile(){//set the variables for this document from a file
	}
}
