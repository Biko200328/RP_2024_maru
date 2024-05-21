using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleMove : MonoBehaviour
{
	Rigidbody rb;

	public bool isPosition;

	float _x;
	float _z;
	float _nextX;
	float _nextZ;
	public float radius;
	public float speed;
	public float vRadius;
	float time;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		_x = radius * Mathf.Sin(-time);
		_z = radius * Mathf.Cos(-time);

		_nextX = radius * Mathf.Sin(-time - speed);
		_nextZ = radius * Mathf.Cos(-time - speed);

		var x = _nextX - _x;
		var z = _nextZ - _z;

		if(isPosition)
		{
			transform.position = new Vector3(_x, transform.position.y, _z);
		}
		else
		{
			var v = rb.velocity;
			v.x = x * vRadius;
			v.z = z * vRadius;
			rb.velocity = v;
		}
	}

	private void FixedUpdate()
	{
		time += speed;
	}
}
