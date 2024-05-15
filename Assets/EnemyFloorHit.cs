using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloorHit : MonoBehaviour
{
	public EnemyAttack enemyAttack;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Floor")
		{
			if(enemyAttack.isHitFloor == false)
			{
				enemyAttack.isHitFloor = true;
				enemyAttack.jumpTime = Random.Range(1.0f, 200.0f);
			}
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.tag == "Floor")
		{
			enemyAttack.isHitFloor = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Floor")
		{
			enemyAttack.isHitFloor = false;
		}
	}
}
