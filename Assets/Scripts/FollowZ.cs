using UnityEngine;

public class FollowZ : MonoBehaviour {
	
	public Transform _player;

	void Update () {
		transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, _player.position.z);
	}
}
