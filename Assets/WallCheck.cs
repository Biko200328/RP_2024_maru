using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
	float speed = 0.5f;  //ÉJÉÅÉâÇÃà⁄ìÆë¨ìx
	float addSpeedCon;

	float _x;
	float _z;

	public GameObject playerObj;
	public PlayerMove playerMoveSqr;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(KeyCode.A))
		{
			speed += playerMoveSqr.addRotSpeed;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			speed += -playerMoveSqr.addRotSpeed;
		}

		var h = Input.GetAxis("cHorizontalL");

		addSpeedCon = h * playerMoveSqr.addRotSpeed;

		speed -= addSpeedCon;

		_x = playerMoveSqr.radius * Mathf.Sin(speed + 0.02f);
		_z = playerMoveSqr.radius * Mathf.Cos(speed + 0.02f);

		transform.position = new Vector3(_x, transform.position.y, _z);
	}

	private void OnTriggerEnter(Collider other)
	{
		
	}

	private void OnTriggerStay(Collider other)
	{
		
	}

	private void OnTriggerExit(Collider other)
	{
		
	}
}
