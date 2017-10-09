using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool _gameHasEnded;

	public float _restartDelay = 2f;

	public GameObject _completeLevelUI;

	public void LevelComplete () {
		_completeLevelUI.SetActive(true);
	}

	public void EndGame () {
		if (!_gameHasEnded) {
			Debug.Log("Game Over!");
			_gameHasEnded = true;
			Invoke("Restart", _restartDelay);
		}
	}

	void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		_gameHasEnded = false;
	}
}
