using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
	public float force = 500f;
	// Collision velocity (X - angular multiplier)
	public Vector3 collisionVelocity = new Vector3(25f, 5f, 10f);

	private void OnCollisionEnter(Collision collision)
	{
		switch (collision.gameObject.tag)
		{
			case "Player":
				// Throw obstacle into the air for dramatic effect
				Rigidbody obstacle = GetComponent<Rigidbody>();
				obstacle.velocity = new Vector3(obstacle.velocity.x,
				                                collisionVelocity.y,
				                                collisionVelocity.z);
				obstacle.angularVelocity = obstacle.angularVelocity * collisionVelocity.x;

				FindObjectOfType<GameManager>().InitiateDeath();

				break;
			case "ObstacleWall":
				Destroy(gameObject);

				break;
		}
	}

	private void Update()
	{
		// Move obstacle on Z axis (towards player)
		GetComponent<Rigidbody>().AddForce(0f, 0f, -force);
	}
}
