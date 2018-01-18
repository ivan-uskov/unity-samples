using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PaddleController : MonoBehaviour {

	const float paddleSpeed = 5f;
	const float maxX = 4.67f;

	// Use this for initialization
	void Start () {
		
	}

	void Update () {
		transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
		if (Math.Abs(transform.position.x) > maxX) {
			var position = transform.position;
			position.x = maxX * Math.Sign(transform.position.x);
			transform.position = position;
		}
	}

	void OnCollisionEnter(Collision col) {
		foreach (ContactPoint contact in col.contacts) {
			if (contact.thisCollider == GetComponent<Collider>()) {
				float diff = contact.point.x - transform.position.x;
				contact.otherCollider.GetComponent<Rigidbody>().AddForce(300f * diff, 0, 0);	
			}
		}
	}
}
