using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPositioner : MonoBehaviour {
	private float defaultPosZ;

	// Use this for initialization
	void Start () {
		defaultPosZ = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void Update () {
		Transform camera = Camera.main.transform;
		Ray ray = new Ray (camera.position, camera.rotation * Vector3.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			if (hit.distance <= defaultPosZ) {
				Debug.Log ("distance is :" + hit.distance.ToString ("2F"));
				transform.localPosition = new Vector3 (0, 0, hit.distance);
			} else {
				Debug.Log ("default distance : hit distance" + defaultPosZ + hit.distance);
				transform.localPosition = new Vector3 (0, 0, defaultPosZ);
			}
		}
	}
}
