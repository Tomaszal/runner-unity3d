//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody _rb;

	public float _forwardForce = 20000f;
	public float _sideForce = 100f;
	
	void FixedUpdate () {
		_rb.AddForce(0f, 0f, _forwardForce * Time.deltaTime);

		if (Input.GetKey("d")) {
			_rb.AddForce(_sideForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
		} else if (Input.GetKey("a")) {
			_rb.AddForce(-_sideForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
		}
	}
}
