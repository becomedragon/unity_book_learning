using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGesture : MonoBehaviour {
	public bool isFacingDown = false;
	public bool isMovingDown = false;

	private float sweepRate = 100.0f;
	private float previousCameraAngle;

	// Use this for initialization
	void Start () {
		previousCameraAngle = CameraAngleFromGound ();
	}
	
	// Update is called once per frame
	void Update () {
		isFacingDown = DetectFacingDown ();
		isMovingDown = DetectMovingDown ();
	}

	private bool DetectFacingDown() {
		return (CameraAngleFromGound () < 60.0f);
	}
		
	private float CameraAngleFromGound(){
		return Vector3.Angle (Vector3.down, Camera.main.transform.rotation * Vector3.forward);
	}

	private bool DetectMovingDown() {
		float angle = CameraAngleFromGound ();
		float delteAngle = previousCameraAngle - angle;
		float rate = delteAngle / Time.deltaTime;
		previousCameraAngle = angle;
		return (rate >= sweepRate);
	}
}
