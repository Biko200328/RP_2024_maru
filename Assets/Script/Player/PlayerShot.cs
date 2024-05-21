using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
	public ControllerTrigger controllerTriggerSqr;

	[SerializeField] GameObject bulletObj;

	PlayerMove playerMove;

	public float bulletSpeed;

	[SerializeField]float timer;
	[SerializeField] float createTime;
	[SerializeField] GameObject bigBullet;
	[SerializeField] GameObject particle;

	public CameraMove cameraMove;

	GameObject keepParticle;

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

		if(controllerTriggerSqr.GetLT())
		{
			timer++;
			playerMove.isDontMoveShot = true;
			cameraMove.isDontMoveShot = true;

			if (timer == 1)
			{
				keepParticle = Instantiate(particle, transform.position, Quaternion.identity);
			}
			if (timer >= createTime)
			{
				Instantiate(bigBullet, transform.position, Quaternion.identity);
				timer = 0;
			}

		}
		else
		{
			timer = 0;
			playerMove.isDontMoveShot = false;
			cameraMove.isDontMoveShot = false;
			if(keepParticle != null)
			{
				Destroy(keepParticle);
			}
		}
	}
}
