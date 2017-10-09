using UnityEngine;

public class EndTrigger : MonoBehaviour {

	public GameManager _gameManager;

	void OnTriggerEnter () {
		_gameManager.LevelComplete();
	}
}
