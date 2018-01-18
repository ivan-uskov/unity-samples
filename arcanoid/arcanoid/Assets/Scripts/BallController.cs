using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	void Start () {
		GetComponent<Rigidbody>().AddForce(0, -300f, 0);
	}

	void Update () {
		
	}
}
