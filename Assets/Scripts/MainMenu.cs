using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Fade _fade;

    void Start()
    {
        _fade.BeginFade(-1);
    }

    public void StartGame(int _difficulty)
    {
    	ApplicationModel._difficulty = _difficulty;

    	StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
    	yield return new WaitForSeconds(_fade.BeginFade(1));

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting the game.");
    	
        Application.Quit();
    }
}