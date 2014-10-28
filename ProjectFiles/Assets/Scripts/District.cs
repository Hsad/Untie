using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class District : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public HashSet<GameObject> nodes;//collection of nodes in this particular district, nodes are any kind of photograph




	Image im;
	Color highlightColor = Color.green;
	Color normalColor;

	void Awake(){
		im = gameObject.GetComponent<Image>();
		normalColor = im.color;
		nodes = new HashSet<GameObject>();
	}

	public void OnDrop(PointerEventData data){//do this when the dragged image is dropped
		im.color = normalColor;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null){
			DragMe dm = data.pointerDrag.GetComponent<DragMe>();
			if(dm != null && dm.icon != null){
				nodes.Add(dm.icon);
				print("added node: " + dm.icon); 
			}

		}
	}



	public void OnPointerEnter(PointerEventData data){		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			im.color = highlightColor;
		
	}

	public void OnPointerExit(PointerEventData data){
		im.color = normalColor;
	}

	private Sprite GetDropSprite(PointerEventData data)
	{
		var originalObj = data.pointerDrag;
		if (originalObj == null)
			return null;
		
		var srcImage = originalObj.GetComponent<Image>();
		if (srcImage == null)
			return null;
		
		return srcImage.sprite;
	}
}
