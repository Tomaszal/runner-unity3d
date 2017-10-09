using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform _player;
	public Vector3 _offset;

	void Update () {
		transform.position = _player.position + _offset;
	}
}
