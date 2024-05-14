using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float addSpeed = 0.1f;
	float speed = 0.5f;
	public float radius = 0.5f; //円の大きさ

	public bool isFloor;
	public bool isDoubleJump;
	public float jumpPower;

	float _x;
	float _z;

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
			speed += addSpeed;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			speed += -addSpeed;
		}

		_x = radius * Mathf.Sin(speed);
		_z = radius * Mathf.Cos(speed);

		transform.position = new Vector3(_x, transform.position.y,_z);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			var v = rb.velocity;
			
			if(Input.GetKeyDown(KeyCode.Space))
			{
				//地面についてる時はジャンプ可能
				if(isFloor == true)
				{
					v.y = 0;
					v.y += jumpPower;
				}
				//ついていないときでもダブルジャンプフラグが残ってる時はできる
				else
				{
					if(isDoubleJump == true)
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
}
