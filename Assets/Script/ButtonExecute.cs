using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonExecute : MonoBehaviour {
	private GameObject currentButton;
	private Clicker clicker = new Clicker();

	public float timeToSelect = 2.0f;
	private float countDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform camera = Camera.main.transform;
		Ray ray = new Ray (camera.position, camera.rotation * Vector3.forward);
		RaycastHit hit;
		GameObject hitButton = null;
		PointerEventData data = new PointerEventData (EventSystem.current);

		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.tag == "Button") {
				hitButton = hit.transform.parent.gameObject;
			}
		}

		if (currentButton != hitButton) {
			if (currentButton != null) {
//				Debug.Log ("Enter");
				ExecuteEvents.Execute<IPointerExitHandler> (currentButton, data, ExecuteEvents.pointerExitHandler);
			}
			currentButton = hitButton;
			if (currentButton != null) {
//				Debug.Log ("Exit");
				ExecuteEvents.Execute<IPointerEnterHandler> (currentButton, data, ExecuteEvents.pointerEnterHandler);
				countDown = timeToSelect;
			}
		}

		if (currentButton != null) {
			countDown -= Time.deltaTime;
//			Debug.Log ("count down + " + countDown);
			if (clicker.clicked ()  || countDown < 0.0f) {
//				Debug.Log ("Clicked !!!!");
				ExecuteEvents.Execute<IPointerClickHandler> (currentButton, data, ExecuteEvents.pointerClickHandler);
				countDown = timeToSelect;
			}
		}
	}
}
