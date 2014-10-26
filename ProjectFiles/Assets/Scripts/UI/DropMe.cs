using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Image containerImage;
	public Image receivingImage;
	private Color normalColor;
	public Color highlightColor = Color.yellow;
	private BulletinBoard bb;
	public Dossier d;//reference to the dossier info.
	
	public void OnEnable ()
	{
		if (containerImage != null)
			normalColor = containerImage.color;
	}

	public void Awake(){
		bb = transform.parent.GetComponent<BulletinBoard>();
	}

	
	public void OnDrop(PointerEventData data)
	{
		containerImage.color = normalColor;
		
		if (receivingImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null){
			receivingImage.overrideSprite = dropSprite;
			d = data.pointerDrag.GetComponent<DragMe>().d;
		}
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (containerImage == null)
			return;
		
		Sprite dropSprite = GetDropSprite (data);
		if (dropSprite != null)
			containerImage.color = highlightColor;

	}

	public void resetImage(){
		receivingImage.overrideSprite = containerImage.sprite;
		d = null;
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
