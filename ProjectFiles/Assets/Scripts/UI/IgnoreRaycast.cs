using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class IgnoreRaycast : MonoBehaviour, ICanvasRaycastFilter, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public bool pinned = false;
	public Dossier d = null;//reference to dossier

	private Image im;//create an image






	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)//make the image ignore raycasting while it's being dragged
	{
		return pinned;
	}

	private Button MyButton = null; // assign in the editor
	
	public void pin(){
		MyButton = gameObject.AddComponent<Button>();
		MyButton.onClick.AddListener(() => { kill();});  //destroy the object when it's clicked
		pinned = true;

		GameObject child = new GameObject("linedraw");
		child.transform.parent = gameObject.transform;
		//create line drawing thing

		im = child.AddComponent<Image>();
		im.type = Image.Type.Tiled;//set the string to tiled so it will repeat
		im.rectTransform.sizeDelta = new Vector2(0,30);//make string this height, width doesn't matter
		im.rectTransform.localScale = new Vector3(1,1,1);
		im.rectTransform.position = Vector3.zero;
		im.rectTransform.localPosition = Vector3.zero;
		im.rectTransform.SetAsLastSibling();//draw in front of everything else
		im.sprite = PlayerState.Instance.ropeSprite;
	}

	void kill(){
		//Destroy(gameObject);
	}



	public void OnBeginDrag(PointerEventData eventData){
	}
	
	public void OnDrag(PointerEventData data){


		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(transform as RectTransform, data.position, data.pressEventCamera, out globalMousePos)){

			Vector3 heading = globalMousePos - transform.position;



			im.rectTransform.rotation = Quaternion.Euler(heading);

			float angle = Mathf.Atan2(heading.y, heading.x) * Mathf.Rad2Deg;

			im.rectTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			Vector2 localPoint;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, data.position, data.pressEventCamera, out localPoint);

			print(localPoint);

			im.rectTransform.localPosition = localPoint/2;




			im.rectTransform.sizeDelta = new Vector2(localPoint.magnitude,30);//make string width so it follows cursor
			
		}
	}

	public void OnEndDrag(PointerEventData eventData){
		//if no valid target to string up, do this
		im.rectTransform.sizeDelta = new Vector2(0,30);//make string this height, width doesn't matter

	}

	void DrawLine(Vector2 a, Vector2 b, Sprite someSprite){


	}

}
