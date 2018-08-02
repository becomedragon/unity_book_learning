using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool clicked() {
	#if(UNITY_ANDROID || UNITY_IPHONE)
		return Cardboard.SDK.Triggered;
	#else
		return Input.anyKeyDown;
	#endif
	}

}
