using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool _gameHasEnded;

	public float _restartDelay = 2f;

    public Transform _player;
    public GameObject _obstaclePrefab;
	public GameObject _completeLevelUI;
    public PlayerMovement _movement;

	public void LevelComplete () {
		_completeLevelUI.SetActive(true);
	}

	public void EndGame () {
		if (!_gameHasEnded) {
			Debug.Log("Game Over!");

            CancelInvoke("SpawnL");
            CancelInvoke("SpawnR");

            _movement.enabled = false;
			_gameHasEnded = true;

			Invoke("Restart", _restartDelay);
		}
	}

    void SpawnL() {
        Instantiate(_obstaclePrefab, new Vector3(Mathf.Floor(Random.Range(-7, 0)), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity);
    }

    void SpawnR() {
        Instantiate(_obstaclePrefab, new Vector3(Mathf.Ceil(Random.Range(0, 7)), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("SpawnL", 0f, 0.2f);
        InvokeRepeating("SpawnR", 0f, 0.2f);
    }

    void FixedUpdate() {
        if (Input.GetKey("r")) {
            Restart();
        }
    }

	void Restart () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		_gameHasEnded = false;
	}
}
