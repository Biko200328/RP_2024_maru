using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	public PlayerMove playerMoveSqr;

	float addRotSpeedCon;
	//float addRotSpeed = 0.02f;
	public float rotate = 0.5f;
	public float radius = 20.5f;

	float _x;
	float _z;

	Rigidbody rb;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Floor" || other.gameObject.tag == "Wall")
		{
			playerMoveSqr.isFloor = true;

			if(playerMoveSqr.isDoubleJump == false)
			{
				playerMoveSqr.isDoubleJump = true;
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Wall")
		{
			playerMoveSqr.isFloor = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Wall")
		{
			playerMoveSqr.isFloor = false;
		}
	}
}
