using UnityEngine;

public class FollowX : MonoBehaviour
{
    public Transform _player;

    void Update()
    {
        transform.position = new Vector3(_player.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}