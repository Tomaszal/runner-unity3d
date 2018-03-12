using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public Fade fade;

	IEnumerator SceneTransition(int scene)
	{
		yield return new WaitForSeconds(fade.BeginFade(1));

		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void StartGame(int difficulty)
	{
		GameManager.difficulty = difficulty;

		StartCoroutine(SceneTransition(1));
	}

	private void Start()
	{
		fade.BeginFade(-1);
	}
}
