using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class EventCubes : MonoBehaviour, IDragHandler, IBeginDragHandler  {


	public CubeRun CubeRunScript;

	public void OnBeginDrag(PointerEventData eventData)
	{
		CubeRunScript.Run (eventData.delta.x, eventData.delta.y);
	}
	
	public void OnDrag(PointerEventData eventData)
	{
		
	}

	void Update () {
	
	}
}
