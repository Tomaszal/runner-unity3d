using UnityEngine;

public class RemoveObstacles : MonoBehaviour
{
    void OnCollisionEnter(Collision _obstacle)
    {
        if (_obstacle.gameObject.tag == "Obstacle")
        {
            Destroy(_obstacle.gameObject);
        }
    }
}