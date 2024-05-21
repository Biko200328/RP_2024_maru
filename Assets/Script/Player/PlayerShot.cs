using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
	public ControllerTrigger controllerTriggerSqr;

	[SerializeField] GameObject bulletObj;

	PlayerMove playerMove;

	public float bulletSpeed;

	// Start is called before the first frame update
	void Start()
	{
		playerMove = GetComponent<PlayerMove>();
	}

	// Update is called once per frame
	void Update()
	{
		if(controllerTriggerSqr.GetRTDown())
		{
			PlayerBullet pb = Instantiate(bulletObj, transform.position, Quaternion.identity).GetComponent<PlayerBullet>();
			if (playerMove.lookLeft)
			{
				pb.speed = bulletSpeed;
			}
			else
			{
				pb.speed = -bulletSpeed;
			}
		}
	}
}
