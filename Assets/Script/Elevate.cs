﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevate : MonoBehaviour {

	public float minHeight = -1.0f;
	public float maxHeight = 8.0f;
	public float velocity = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float y = transform.position.y;
		y += velocity * Time.deltaTime;

		if (y > maxHeight) {
			y = maxHeight;
			velocity = -velocity;
		}

		if (y < minHeight) {
			y = minHeight;
			velocity = -velocity;
		}

		transform.position = new Vector3 (transform.position.x, y, transform.position.z);
	}
}
  