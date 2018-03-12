using UnityEngine;

public class FollowTransform : MonoBehaviour
{
	public Transform transformObject;
	public int axis;

	private void Update()
	{
		Vector3 newPosition;

		newPosition = transform.position;
		newPosition[axis] = transformObject.position[axis];

		transform.position = newPosition;
	}
}
