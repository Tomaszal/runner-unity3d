using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public PlayerMovement _movement;

	void OnCollisionEnter (Collision _collisionInfo) {
		if (_collisionInfo.collider.tag == "Obstacle") {
			_movement.enabled = false;

			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
