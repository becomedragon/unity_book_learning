using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookWalk : MonoBehaviour {
	public float velocity = 0.7f;
	public bool isWalking = false;

	private CharacterController controller ;

	private Clicker clicker = new Clicker ();
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (clicker.clicked ()) {
			isWalking = !isWalking;
		}

		if(isWalking) {
			Vector3 moveDirection = Camera.main.transform.forward;
			moveDirection *= velocity * Time.deltaTime;
			moveDirection.y = 0.0f;
			transform.position += moveDirection;
		//		controller.Move (moveDirection);
			controller.SimpleMove(Camera.main.transform.forward * velocity);
		}
	}
}
