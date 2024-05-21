using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
	GameObject centerObj;
	public float speed;
	Rigidbody rb;

	Vector3 n;

	bool isTrack;
	GameObject bullet;
	// Start is called before the first frame update
	void Start()
	{
		centerObj = GameObject.FindGameObjectWithTag("Center");
		rb = GetComponent<Rigidbody>();

		transform.eulerAngles = new Vector3(-90, 0, 0);
		n = centerObj.transform.position - transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (isTrack)
		{
			//transform.position = bullet.transform.position;
		}
		else
		{
			var v = rb.velocity;
			v = n.normalized * speed;
			rb.velocity = v;
		}
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PlayerBullet")
		{
			bullet = other.gameObject;
			isTrack = true;
			PlayerBullet pbSqr = other.gameObject.GetComponent<PlayerBullet>();
			PlayerBullet mbSqr = gameObject.AddComponent<PlayerBullet>();
			mbSqr.isMb = true;
			mbSqr.time = pbSqr.time;
			mbSqr.speed = pbSqr.speed / 2;
			Destroy(other.gameObject);
		}
	}
}
