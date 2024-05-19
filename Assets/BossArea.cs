using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArea : MonoBehaviour
{
	public Texture tex;

	public GameObject boss;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		transform.position = boss.transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PlayerBullet")
		{
			PlayerBullet bullet = other.gameObject.GetComponent<PlayerBullet>();
			bullet.ChangeMaterial();
		}
	}
}
