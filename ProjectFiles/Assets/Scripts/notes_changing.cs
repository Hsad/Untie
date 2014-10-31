using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class notes_changing : MonoBehaviour {
	public Text notes;
	// Use this for initialization
	void Start () {
		notes = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		notes.text = ("hi i'm gosu  dsjfhlksjahsfkjasfhlaskjdhlsjdkfsahlfkjsdlas");
	}
}
