using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	//í èÌà⁄ìÆ
	public float speed;
	public float time;

	float _x;
	float _z;

	[SerializeField] float attackTime;
	[SerializeField] float attackTimer;
	bool isAttack;


	//íe
	[Header("íe")]
	[SerializeField] bool isMultiBullet;
	float timer = 0;
	[SerializeField] float[] bulletsTime;
	[SerializeField] GameObject[] bullets;
	[SerializeField] GameObject particle;

	//Ë¶êŒ
	[Header("Ë¶êŒ")]
	[SerializeField] bool inseki;
	[SerializeField] float insekiTime;
	[SerializeField] float jumpPower;
	[SerializeField] float afterJumpTime;
	int nowNum;
	[SerializeField] int maxNum;
	[SerializeField] GameObject insekiObj;

	[Header("ìÀêi")]
	[SerializeField] bool tackle;
	[SerializeField] float stopTime;
	[SerializeField] float tackleTime;
	[SerializeField] float breakTime;
	[SerializeField] float tackleSpeed;

	PlayerMove playerMoveSqr;
	Rigidbody rb;


	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		playerMoveSqr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
	}

	// Update is called once per frame
	void Update()
	{
		_x = playerMoveSqr.radius * Mathf.Sin(-time);
		_z = playerMoveSqr.radius * Mathf.Cos(-time);

		transform.position = new Vector3(_x, transform.position.y, _z);

		if(isAttack == true)
		{
			int a = 0;
			a = Random.Range(0, 3);
			if(a == 0)
			{
				isMultiBullet = true;
			}
			else if (a == 1)
			{
				inseki = true;
			}
			else
			{
				tackle = true;
			}

			isAttack = false;
		}
	}

	private void FixedUpdate()
	{
		if(isAttack == false && isMultiBullet == false && inseki == false && tackle == false)
		{
			attackTimer++;
			if(attackTimer >= attackTime)
			{
				isAttack = true;
			}
		}


		if (tackle == false)
		{
			time += speed;
		}
		

		if (isMultiBullet)
		{
			timer++;

			if(timer == 5)
			{
				GameObject particleObj = Instantiate(particle, transform.position, Quaternion.identity);
				particleObj.transform.parent = this.gameObject.transform;
			}

			for(int i = 0;i < 3;i++)
			{
				if (timer == bulletsTime[i])
				{
					if(i == 0)
					{
						Instantiate(bullets[i],new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
					}
					else if (i == 1)
					{
						Instantiate(bullets[i], new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), Quaternion.identity);
					}
					else
					{
						Instantiate(bullets[i], new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
						timer = 0;
						isMultiBullet = false;
						isAttack = false;
						attackTimer = 0;
					}

					break;
				}
			}
			
		}

		if(inseki)
		{
			timer++;
			var v = rb.velocity;

			if(timer == 5)
			{
				v.y += jumpPower;
			}
			rb.velocity = v;

			if(timer >= afterJumpTime)
			{
				if (timer >= afterJumpTime + insekiTime)
				{
					Instantiate(insekiObj, new Vector3(transform.position.x, transform.position.y + 6.0f, transform.position.z), Quaternion.identity);
					timer = afterJumpTime;
					nowNum++;
					if (nowNum >= maxNum)
					{
						inseki = false;
						isAttack = false;
						attackTimer = 0;
						timer = 0;
						nowNum = 0;
					}
				}
			}
		}

		if(tackle)
		{
			timer++;
			if(timer == stopTime - 35)
			{
				var v = rb.velocity;

				v.y += 5;
				rb.velocity = v;
			}
			if (timer >= stopTime && timer <= stopTime + tackleTime)
			{
				time -= tackleSpeed;
			}
			else if (timer >= stopTime + tackleTime + breakTime)
			{
				timer = 0;
				tackle = false;
				isAttack = false;
				attackTimer = 0;
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			PlayerHp playerHp = collision.gameObject.GetComponent<PlayerHp>();
			playerHp.tuckleDamage();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			PlayerHp playerHp = other.GetComponent<PlayerHp>();
			playerHp.tuckleDamage();
		}
	}
}
