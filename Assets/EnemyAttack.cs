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

	public PlayerMove playerMoveSqr;
	Rigidbody rb;


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
	[SerializeField] float tackleTime;
	[SerializeField] float breakTime;
	[SerializeField] float tackleSpeed;


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
	}

	private void FixedUpdate()
	{
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
						Instantiate(bullets[i],new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
					}
					else if (i == 1)
					{
						Instantiate(bullets[i], new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
					}
					else
					{
						Instantiate(bullets[i], new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
						timer = 0;
						isMultiBullet = false;
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
						timer = 0;
						nowNum = 0;
					}
				}
			}
		}

		if(tackle)
		{
			timer++;

			if(timer <= tackleTime)
			{
				time -= tackleSpeed;
			}
			else if (timer >= tackleTime + breakTime)
			{
				timer = 0;
				tackle = false;
			}
		}
	}
}
