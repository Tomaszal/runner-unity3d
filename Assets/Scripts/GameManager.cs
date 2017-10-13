using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool _gameHasEnded;
    int _highscore;

    public float _restartDelay = 2f;

    public Text _score;
    public Transform _player;
    public GameObject _obstaclePrefab;
    //public GameObject _completeLevelUI;
    public PlayerMovement _movement;

    public void EndGame()
    {
        if (!_gameHasEnded)
        {
            Debug.Log("Game Over!");

            if (Mathf.Ceil(_player.position.z) > _highscore)
            {
                _highscore = (int)(Mathf.Ceil(_player.position.z));
                PlayerPrefs.SetInt("Highscore", _highscore);

                Debug.Log(_highscore);
            }

            CancelInvoke("SpawnL");
            CancelInvoke("SpawnR");

            _movement.enabled = false;
            _gameHasEnded = true;

            Invoke("Restart", _restartDelay);
        }
    }

    void SpawnL()
    {
        Instantiate(_obstaclePrefab, new Vector3(Mathf.Floor(Random.Range(-7, 0)), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity);
    }

    void SpawnR()
    {
        Instantiate(_obstaclePrefab, new Vector3(Mathf.Ceil(Random.Range(0, 7)), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("SpawnL", 1f, 0.5f / ApplicationModel._difficulty);
        InvokeRepeating("SpawnR", 1f, 0.5f / ApplicationModel._difficulty);

        _highscore = PlayerPrefs.GetInt("Highscore");
    }

    void FixedUpdate()
    {
        if (Input.GetKey("r"))
        {
            Restart();
        }

        _score.text = "Highscore: " + _highscore + "\nScore: " + Mathf.Ceil(_player.position.z);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _gameHasEnded = false;
    }
}