//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody _rb;

	public float _forwardForce = 2000f;
	public float _sideForce = 500f;
	
	// FixedUpdate are preffered when working with physics.
	void FixedUpdate () {
		// Add a constant forward force.
		_rb.AddForce(0, 0, _forwardForce * Time.deltaTime);

		// Add basic movement to the sides.
		if (Input.GetKey("d")) {
			_rb.AddForce(_sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a")) {
			_rb.AddForce(-_sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (_rb.position.y <= 0f) {
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
