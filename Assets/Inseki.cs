using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inseki : MonoBehaviour
{
	public float speed;
	[SerializeField] float time;

	float _x;
	float _z;

	public PlayerMove playerMoveSqr;

	// Start is called before the first frame update
	void Start()
	{
		playerMoveSqr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
		transform.eulerAngles = new Vector3(-90, 0, 0);
		time = Random.Range(-1.0f, 1.0f);
	}

	// Update is called once per frame
	void Update()
	{
		_x = playerMoveSqr.radius * Mathf.Sin(time);
		_z = playerMoveSqr.radius * Mathf.Cos(time);

		transform.position = new Vector3(_x, transform.position.y, _z);
	}

	private void FixedUpdate()
	{
		
	}
}
