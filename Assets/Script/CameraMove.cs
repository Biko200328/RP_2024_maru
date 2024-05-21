using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	float addRotSpeedCon;
	float addRotSpeed = 0.02f;
	public float rotate = 0.5f;
	public float radius = 20.5f;

	float _x;
	float _z;

	public GameObject playerObj;
	public PlayerMove playerMoveSqr;

	public bool isDontMoveCamera;
	public bool isDontMoveShot;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isDontMoveCamera == false && isDontMoveShot == false)
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
			_x = radius * Mathf.Sin(rotate);
			_z = radius * Mathf.Cos(rotate);

			//À•WˆÚ“®
			transform.position = new Vector3(_x, transform.position.y, _z);
			transform.LookAt(playerObj.gameObject.transform);
		}
	}
}
