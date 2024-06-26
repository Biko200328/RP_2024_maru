using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public float speed;
	public float time;

	public float radius = 0.5f; //�~�̑傫��

	float _x;
	float _z;

	public PlayerMove playerMoveSqr;

	public float deadTime;
	float deadTimer;

	public GameObject particle;
	public GameObject particleRed;

	bool isNoHit;
	float hitTimer;

	public bool isRed;
	[SerializeField] Material[] materialArray = new Material[1];
	public Texture tex;

	public bool isMb;

	// Start is called before the first frame update
	void Start()
    {
		playerMoveSqr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

		if (isMb == false)
		{
			transform.eulerAngles = new Vector3(-90, 0, 0);
			time -= playerMoveSqr.rotate;
			isNoHit = true;
		}
	}

    // Update is called once per frame
    void Update()
    {
		_x = playerMoveSqr.radius * Mathf.Sin(-time);
		_z = playerMoveSqr.radius * Mathf.Cos(-time);

		transform.position = new Vector3(_x, transform.position.y, _z);

		if (isMb == false)
		{
			if (isRed)
			{
				Instantiate(particleRed, transform.position, Quaternion.identity);
			}
			else
			{
				Instantiate(particle, transform.position, Quaternion.identity);
			}


			if (deadTimer >= deadTime)
			{
				Destroy(this.gameObject);
			}
		}
	}

	private void FixedUpdate()
	{
		time += speed;

		deadTimer += Time.deltaTime;

		hitTimer++;
		if(hitTimer >= 40)
		{
			isNoHit = false;
		}

		//transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);
	}

	public void ChangeMaterial()
	{
		GetComponent<MeshRenderer>().material = materialArray[1];
		isRed = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}

		if(other.gameObject.tag == "Enemy")
		{
			if(isMb == false)
			{
				EnemyDamage enemyDamage = other.gameObject.GetComponent<EnemyDamage>();
				enemyDamage.Damage();
				EnemyAttack enemyAttack = other.gameObject.GetComponent<EnemyAttack>();
				if (speed > 0)
				{
					enemyAttack.isLeft = true;
				}
				else
				{
					enemyAttack.isLeft = false;
				}
				enemyAttack.isKnock = true;

				Destroy(this.gameObject);
			}
		}

		if (other.gameObject.tag == "Player")
		{
			if(isNoHit == false)
			{
				PlayerHp hp = other.gameObject.GetComponent<PlayerHp>();
				hp.SelfDamage();
				Destroy(this.gameObject);
			}
		}
	}
}
