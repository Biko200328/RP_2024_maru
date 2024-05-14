using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float speed = 1f;
	public float addRotSpeed = 0.1f;
	public float addRotSpeedCon = 0;
	public float rotate = 0.5f;
	public float radius = 0.5f; //円の大きさ

	public bool isFloor;
	public bool isDoubleJump;
	public float jumpPower;

	float _x;
	float _z;

	float _nextX;
	float _nextZ;
	float _nextRotate;

	public GameObject lookObj;
	

	Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKey(KeyCode.A))
		{
			rotate += addRotSpeed;
			//_nextRotate = rotate + addRotSpeed; 
		}
		else if (Input.GetKey(KeyCode.D))
		{
			rotate -= addRotSpeed;
			//_nextRotate = rotate - addRotSpeed;
		}

		var inputH = Input.GetAxis("cHorizontalL");
		addRotSpeedCon = inputH * addRotSpeed;

		rotate -= addRotSpeedCon;

		////現在
		_x = radius * Mathf.Sin(rotate);
		_z = radius * Mathf.Cos(rotate);

		////次
		//_nextX = radius * Mathf.Sin(_nextRotate);
		//_nextZ = radius * Mathf.Cos(_nextRotate);

		//float vecX = _nextX - _x;
		//float vecZ = _nextZ - _z;

		//Vector2 vec = new Vector2(vecX, vecZ);
		//vec = vec.normalized;

		var v = rb.velocity;

		//座標移動
		transform.position = new Vector3(_x, transform.position.y,_z);

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("buttonA"))
		{
			//地面についてる時はジャンプ可能
			if (isFloor == true)
			{
				v.y += jumpPower;
			}
			//ついていないときでもダブルジャンプフラグが残ってる時はできる
			else
			{
				if (isDoubleJump == true)
				{
					v.y = 0;
					v.y += jumpPower;
					isDoubleJump = false;
				}
			}
		}

		rb.velocity = v;

	}
}
