using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class District : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	//this script defines a district on the map
	//also allows photos to be dropped and linked to a particular district
	Image im;
	Color highlightColor = Color.green;
	Color normalColor;

	void Awake(){
		im = gameObject.GetComponent<Image>();
		normalColor = im.color;
	}



	public void OnPointerEnter(PointerEventData data)
	{
		print("pointer entered object: " + gameObject.name);
		//if (containerImage == null)
			//return;
		
		//if(locked){
			//containerImage.color = lockColor;
			//return;
		//}
		
		//Sprite dropSprite = GetDropSprite (data);
		//if (dropSprite != null)
		im.color = highlightColor;
		
	}

	public void OnPointerExit(PointerEventData data)
	{
		//if (containerImage == null)
			//return;
		print("pointer exited object: " + gameObject.name);
		im.color = normalColor;
	}
}
