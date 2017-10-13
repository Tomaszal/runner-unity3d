using UnityEngine;

public class Fade : MonoBehaviour
{
    public Texture2D _fadeOutTexture;
    public float _fadeSpeed = 0.85f;

    private float _alpha = 1.0f;
    private int _fadeDir = -1;

    void OnGUI()
    {
		_alpha += _fadeDir * _fadeSpeed * Time.deltaTime;
		_alpha = Mathf.Clamp01(_alpha);

		GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, _alpha);
		GUI.depth = -1000;
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height), _fadeOutTexture);
    }

    public float BeginFade(int _direction)
    {
    	_fadeDir = _direction;
    	return (_fadeSpeed);
    }
}
