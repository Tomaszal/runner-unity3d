using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded;
    private int _highscore;

    public Text _scoreUI;
    public Text _highscoreUI;

    public Transform _player;
    public Transform _obstacles;
    public GameObject _obstaclePrefab;
    public GameObject _deathOverlayUI;

    public PlayerMovement _movement;
    public Fade _fade;

    public void EndGame()
    {
        if (!_gameHasEnded)
        {
            CancelInvoke("SpawnL");
            CancelInvoke("SpawnR");

            _movement.enabled = false;
            _gameHasEnded = true;

            Invoke("DeathOverlay", 1f);
        }
    }

    public void MenuButton()
    {
        StartCoroutine(Menu());
    }

    public void RetryButton()
    {
        StartCoroutine(Retry());
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(_fade.BeginFade(1));

        SceneManager.LoadScene(0);
    }

    IEnumerator Retry()
    {
        yield return new WaitForSeconds(_fade.BeginFade(1));

        SceneManager.LoadScene(1);
    }

    private void Spawn()
    {
        Instantiate(_obstaclePrefab, new Vector3(Mathf.Floor(Random.Range(-7, 0)), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity, _obstacles);
        Instantiate(_obstaclePrefab, new Vector3(Mathf.Ceil(Random.Range(0, 7)), 1, Mathf.Floor(_player.position.z) + 100), Quaternion.identity, _obstacles);
    }

    private void Start()
    {
        _fade.BeginFade(-1);

        InvokeRepeating("Spawn", 1f, 0.5f / ApplicationModel._difficulty);

        _highscore = PlayerPrefs.GetInt("Highscore" + ApplicationModel._difficulty);
    }

    private void Update()
    {
        if (Input.GetKey("r"))
        {
            CheckHighscore();

            RetryButton();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            EndGame();
        }

        _scoreUI.text = "Score: " + Mathf.Ceil(_player.position.z);
    }

    private void CheckHighscore()
    {
        if (Mathf.Ceil(_player.position.z) > _highscore)
        {
            _highscore = (int)(Mathf.Ceil(_player.position.z));
            PlayerPrefs.SetInt("Highscore" + ApplicationModel._difficulty, _highscore);
        }
    }

    private void DeathOverlay()
    {
        CheckHighscore();

        string _temp = "NaN";

        switch (ApplicationModel._difficulty)
        {
            case 1:
                _temp = "Easy";
                break;
            case 2:
                _temp = "Medium";
                break;
            case 3:
                _temp = "Hard";
                break;
        }

        _highscoreUI.text = _temp + " highscore: " + _highscore;
        _deathOverlayUI.SetActive(true);
    }
}