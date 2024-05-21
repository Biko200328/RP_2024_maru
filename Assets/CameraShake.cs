using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	public PlayerMove playerMove;
	public CameraMove cameraMove;

	public void Shake(float duration, float magnitude)
	{
		StartCoroutine(DoShake(duration, magnitude));
	}

	private IEnumerator DoShake(float duration, float magnitude)
	{
		var pos = transform.position;

		var elapsed = 0f;

		playerMove.isDontMoveCamera = true;
		cameraMove.isDontMoveCamera = true;

		while (elapsed < duration)
		{
			var x = pos.x + Random.Range(-1f, 1f) * magnitude;
			var y = pos.y + Random.Range(-1f, 1f) * magnitude;

			transform.position = new Vector3(x, y, pos.z);

			elapsed += Time.deltaTime;

			yield return null;
		}

		if(elapsed > duration)
		{
			playerMove.isDontMoveCamera = false;
			cameraMove.isDontMoveCamera = false;
		}

		transform.position = pos;
	}
}
