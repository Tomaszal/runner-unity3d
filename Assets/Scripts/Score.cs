using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform _player;
    public Text _score;

    void Update()
    {
        _score.text = "Score: " + _player.position.z.ToString("0");
    }
}