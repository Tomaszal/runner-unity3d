using UnityEngine;

public class Fade : MonoBehaviour
{
	public float fadeSpeed = 1.25f;
	private int fadeDirection = -1;

	private Color colorGUI = Color.white;

	private void OnGUI()
	{
		// Calculate new alpha
		colorGUI.a = Mathf.Clamp01(colorGUI.a + fadeDirection * fadeSpeed * Time.deltaTime);

		// Put GUI (fade overlay) on top layer and draw it
		GUI.depth = -1000;
		GUI.color = colorGUI;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Texture2D.whiteTexture);
	}

	public float BeginFade(int direction)
	{
		fadeDirection = direction;

		// Return how long it will take to fade
		return (1 / fadeSpeed);
	}
}
