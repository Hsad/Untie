using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class IgnoreRaycast : MonoBehaviour, ICanvasRaycastFilter, IBeginDragHandler, IEndDragHandler, IDragHandler {
	public bool pinned = false;
	public Dossier d = null;//reference to dossier
	private Image im;//create an image
	public GameObject target;//the target (formed by connecting strings)
	public GameObject timenote;//the note with the time and instructions
	public GameObject arrow;//arrow to give strings direction

	bool dragging = false;

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
		child.AddComponent("IgnoreRaycast");
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

		if(target == null){//clear picture
			Destroy(gameObject);
		}else{//else clear target
			im.rectTransform.sizeDelta = new Vector2(0,30);//make string this height, width doesn't matter
			target = null;
			Destroy(timenote);
		}
	}

	void Update(){
		if(pinned && target == null && !dragging){//get rid of string if target has been destroyed
			im.rectTransform.sizeDelta = new Vector2(0,30);
			Destroy(timenote);
		}
	}



	public void OnBeginDrag(PointerEventData eventData){
		target = null; // reset connection
		Destroy(timenote);
		dragging = true;
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

			im.rectTransform.localPosition = localPoint/2;




			im.rectTransform.sizeDelta = new Vector2(localPoint.magnitude,30);//make string width so it follows cursor
			
		}
	}

	public void OnEndDrag(PointerEventData data){
		dragging = false;
		GameObject tmp1 = data.pointerCurrentRaycast.go;
		if(tmp1 == null || tmp1 == gameObject) return;
		IgnoreRaycast tmp2 = tmp1.GetComponent<IgnoreRaycast>();
		if(tmp2 != null && tmp2.pinned){//if the drag ends on a valid location, set target
			target = tmp1;
			//timenote = Instantiate(PlayerState.Instance.noteFab,im.rectTransform.position,Quaternion.identity) as GameObject; //create note in middle of string
			RectTransform trt = transform as RectTransform;
			Vector3 newpos = new Vector3(0, -(trt.position.y + trt.sizeDelta.y),0);
			timenote = Instantiate(PlayerState.Instance.noteFab,Vector3.zero,Quaternion.identity) as GameObject; //create note at bottom of node
			timenote.transform.parent = gameObject.transform;
			timenote.transform.localPosition = newpos;
			timenote.transform.SetAsLastSibling();

			trt = PlayerState.Instance.arrowFab.transform as RectTransform;
			//RectTransform trt2 = transform as RectTransform;

			//newpos = new Vector3(im.rectTransform.position.x,im.rectTransform.position.y - trt.sizeDelta.y,0);
			newpos = im.transform.localPosition/4.5f;//new Vector3(trt2.sizeDelta.x, trt2.sizeDelta.y - trt.sizeDelta.y,0);



			arrow = Instantiate(PlayerState.Instance.arrowFab,Vector3.zero,im.rectTransform.rotation) as GameObject; //create note in middle of string
			arrow.transform.parent = gameObject.transform;
			arrow.transform.localPosition = newpos;
			arrow.transform.parent = timenote.transform;



		}else{
			im.rectTransform.sizeDelta = new Vector2(0,30);//make string this height, width doesn't matter
		}
	}

}
