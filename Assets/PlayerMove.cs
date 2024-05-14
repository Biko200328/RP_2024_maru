using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float addSpeed = 0.1f;
	float speed = 0.5f;  //カメラの移動速度
	public float radius = 0.5f; //円の大きさ

	float _x;
	float _z;

	public GameObject lookObj;

	public float jumpPower;

	// Start is called before the first frame update
	void Start()
	{

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
		transform.LookAt(lookObj.gameObject.transform);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			
		}
	}
}
