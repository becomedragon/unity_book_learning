using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTimeout : MonoBehaviour {
	public float timer = 15.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, timer);
	}
}
