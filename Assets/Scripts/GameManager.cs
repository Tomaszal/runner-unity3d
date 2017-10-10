using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	bool _gameHasEnded;

	public float _restartDelay = 2f;

    public Transform _player;
    public GameObject ObstaclePrefab;
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

    void Spawn1()
    {
        Instantiate(ObstaclePrefab, new Vector3(Random.Range(-7, 0), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity);
    }

    void Spawn2()
    {
        Instantiate(ObstaclePrefab, new Vector3(Random.Range(0, 7), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("Spawn1", 0, 0.3f);
        InvokeRepeating("Spawn2", 0, 0.2f);
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
