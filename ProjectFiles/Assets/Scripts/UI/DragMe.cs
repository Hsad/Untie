using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public bool dragOnSurfaces = true;
	public Dossier d;//reference to the dossier info.
	private Canvas canvas;

	
	private GameObject m_DraggingIcon;
	private RectTransform m_DraggingPlane;

	void Awake(){
		canvas = FindInParents<Canvas>(gameObject);
		if(canvas != null){
			d = canvas.GetComponent<Dossier>();
		}
	}

	public GameObject icon {//get the current icon (read only)
		get {
			return m_DraggingIcon;
		}    
	}

	public void OnBeginDrag(PointerEventData eventData)
	{

		if (canvas == null)
			return;

		// We have clicked something that can be dragged.
		// What we want to do is create an icon for this.
		m_DraggingIcon = new GameObject("icon");

		m_DraggingIcon.transform.SetParent (canvas.transform, false);
		m_DraggingIcon.transform.SetAsLastSibling();
		
		var image = m_DraggingIcon.AddComponent<Image>();
		// The icon will be under the cursor.
		// We want it to be ignored by the event system.
		m_DraggingIcon.AddComponent<IgnoreRaycast>().d = d;

		image.sprite = GetComponent<Image>().sprite;
		image.SetNativeSize();
		
		if (dragOnSurfaces)
			m_DraggingPlane = transform as RectTransform;
		else
			m_DraggingPlane = canvas.transform as RectTransform;
		
		SetDraggedPosition(eventData);
	}

	public void OnDrag(PointerEventData data)
	{
		if (m_DraggingIcon != null)
			SetDraggedPosition(data);
	}

	private void SetDraggedPosition(PointerEventData data)
	{
		if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null){

			m_DraggingPlane = data.pointerEnter.transform as RectTransform;

			Canvas newcanvas = FindInParents<Canvas>(data.pointerEnter);
			if(newcanvas != canvas && newcanvas.tag == "pinnable"){

				m_DraggingIcon.transform.SetParent (newcanvas.transform, false);
				m_DraggingIcon.transform.SetAsLastSibling();
				m_DraggingIcon.transform.localScale = canvas.transform.lossyScale;
				canvas = newcanvas;
			}
		}
		
		var rt = m_DraggingIcon.GetComponent<RectTransform>();
		Vector3 globalMousePos;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
		{
			rt.position = globalMousePos;
			//rt.rotation =  m_DraggingPlane.rotation;

		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (m_DraggingIcon != null)
			//Destroy(m_DraggingIcon);
			m_DraggingIcon.GetComponent<IgnoreRaycast>().pin();
		canvas = FindInParents<Canvas>(gameObject);
	}

	static public T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null) return null;
		var comp = go.GetComponent<T>();

		if (comp != null)
			return comp;
		
		Transform t = go.transform.parent;
		while (t != null && comp == null)
		{
			comp = t.gameObject.GetComponent<T>();
			t = t.parent;
		}
		return comp;
	}
}
