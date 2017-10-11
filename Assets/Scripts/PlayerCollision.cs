using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter (Collision _collisionInfo) {
		if (_collisionInfo.collider.tag == "Obstacle") {
			FindObjectOfType<GameManager>().EndGame();
		}
	}
}
