using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
	float addRotSpeedCon;
	float addRotSpeed = 0.02f;
	public float rotate = 0.5f;
	public float openNum;

	float _x;
	float _z;

	public GameObject playerObj;
	public PlayerMove playerMoveSqr;

	public bool isLeft;

	Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		var inputH = Input.GetAxis("cHorizontalL");
		addRotSpeedCon = inputH * addRotSpeed;

		if (addRotSpeedCon > 0)
		{
			if (playerMoveSqr.isHitLeft == false)
			{
				rotate -= addRotSpeedCon;
			}
		}
		if (addRotSpeedCon < 0)
		{
			if (playerMoveSqr.isHitRight == false)
			{
				rotate -= addRotSpeedCon;
			}
		}

		//Œ»Ý
		if(isLeft)
		{
			_x = playerMoveSqr.radius * Mathf.Sin(rotate - openNum);
			_z = playerMoveSqr.radius * Mathf.Cos(rotate - openNum);
		}
		else
		{
			_x = playerMoveSqr.radius * Mathf.Sin(rotate + openNum);
			_z = playerMoveSqr.radius * Mathf.Cos(rotate + openNum);
		}

		//À•WˆÚ“®
		transform.position = new Vector3(_x, playerMoveSqr.transform.position.y, _z);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Wall")
		{
			if(isLeft)
			{
				playerMoveSqr.isHitLeft = true;
			}
			else
			{
				playerMoveSqr.isHitRight = true;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			if (isLeft)
			{
				playerMoveSqr.isHitLeft = true;
			}
			else
			{
				playerMoveSqr.isHitRight = true;
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			if (isLeft)
			{
				playerMoveSqr.isHitLeft = false;
			}
			else
			{
				playerMoveSqr.isHitRight = false;
			}
		}
	}
}
