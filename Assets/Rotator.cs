using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float xRate = 0f;
	public float yRate = 0f;
	public float zRote = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (xRate, yRate, zRote) * Time.deltaTime);
	}
}
