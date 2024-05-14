using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	//�ʏ�ړ�
	public float speed;
	public float time;

	float _x;
	float _z;

	public PlayerMove playerMoveSqr;


	//�e
	[SerializeField] bool isMultiBullet;
	float timer = 0;
	[SerializeField] float[] bulletsTime;
	[SerializeField] GameObject[] bullets;

	[SerializeField] GameObject laserbullet;


	[SerializeField] bool inseki;
	[SerializeField] float insekiTime;
	int nowNum;
	[SerializeField] int maxNum;
	[SerializeField] GameObject insekiObj;

	[SerializeField] bool tackle;
	[SerializeField] float tackleTime;
	[SerializeField] float breakTime;
	[SerializeField] float tackleSpeed;


	// Start is called before the first frame update
	void Start()
	{
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
			if(timer >= insekiTime)
			{
				Instantiate(insekiObj, new Vector3(transform.position.x, transform.position.y + 6.0f, transform.position.z), Quaternion.identity);
				timer = 0;
				nowNum++;
				if(nowNum >= maxNum)
				{
					inseki = false;
					timer = 0;
					nowNum = 0;
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
