using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler{
	//bulletin board drop slot

	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
	Color highlightColor = Color.green;
	Color lockColor = Color.red;
	private BulletinBoard bb;
	public Dossier d;//reference to the dossier info.

	public bool locked = false;
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}

	public void Awake(){
		bb = transform.parent.GetComponent<BulletinBoard>();
	}

	
	public void OnDrop(PointerEventData data){
		if(!locked){//if the data is not locked in place, replace it
			containerImage.color = normalColor;
			
			if (receivingImage == null)
				return;
			
			Sprite dropSprite = GetDropSprite (data);
			if (dropSprite != null){
				receivingImage.overrideSprite = dropSprite;
				DragMe dm = data.pointerDrag.GetComponent<DragMe>();
				if(dm != null){
					d = dm.d;
					bb.nodes[gameObject] = d;
				}
			}
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;

		if(locked){
			containerImage.color = lockColor;
			return;
		}
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;

	}

	public void resetImage(){
		receivingImage.overrideSprite = containerImage.sprite;
		d = null;
		bb.nodes[gameObject] = null;
	}

	public void OnPointerExit(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		containerImage.color = normalColor;
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
