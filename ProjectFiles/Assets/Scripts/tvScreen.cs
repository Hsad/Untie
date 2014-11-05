using UnityEngine;
using System.Collections;

public class tvScreen : MonoBehaviour {

	public Material mat;
	
	void set_texture(Texture t){
		mat.SetTexture(0,t);
	}
}
