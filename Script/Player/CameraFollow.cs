using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f);

	void LateUpdate()
	{
		if (Player.Instance == null) return;

		transform.position = Player.Instance.transform.position + offset;
	}
}
