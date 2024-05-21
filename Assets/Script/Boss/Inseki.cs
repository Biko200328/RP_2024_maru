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

	[SerializeField] float DestroyTime;
	float timer;

	public Vector3 rotate;

	// Start is called before the first frame update
	void Start()
	{
		playerMoveSqr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
		transform.eulerAngles = new Vector3(-90, 0, 0);
		time = Random.Range(playerMoveSqr.rotate - 0.5f, playerMoveSqr.rotate + 0.5f);

		rotate = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
	}

	// Update is called once per frame
	void Update()
	{
		_x = playerMoveSqr.radius * Mathf.Sin(time);
		_z = playerMoveSqr.radius * Mathf.Cos(time);

		transform.position = new Vector3(_x, transform.position.y, _z);
		transform.localEulerAngles += rotate;

		if (timer >= DestroyTime)
		{
			Destroy(this.gameObject);
		}
	}

	private void FixedUpdate()
	{
		timer++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			PlayerHp playerHp = other.GetComponent<PlayerHp>();
			playerHp.InsekiDamage();
		}
	}
}
