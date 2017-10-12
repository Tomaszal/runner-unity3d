using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartEasy()
    {
    	Debug.Log("Starting with easy difficulty.");

    	ApplicationModel._difficulty = 1;

        SceneManager.LoadScene("Randomized Level", LoadSceneMode.Single);
    }

    public void StartMedium()
    {
    	Debug.Log("Starting with medium difficulty.");

    	ApplicationModel._difficulty = 2;

        SceneManager.LoadScene("Randomized Level", LoadSceneMode.Single);
    }

    public void StartHard()
    {
    	Debug.Log("Starting with hard difficulty.");

    	ApplicationModel._difficulty = 3;
    	
        SceneManager.LoadScene("Randomized Level", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
    	Debug.Log("Exiting the game.");
    	
        Application.Quit();
    }
}