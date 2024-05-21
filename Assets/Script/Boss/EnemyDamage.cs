using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	[Header("ƒmƒbƒNƒoƒbƒNŒn")]
	[SerializeField] bool isDamage;
	[SerializeField] float totalTime;
	float timer;

	float speed;
	public float addSpeed;
	float time;

	float _x;
	float _z;

	[Header("ƒ_ƒ[ƒWŒn")]
	public float nowHp = 100;
	public float maxHp = 100;
	public float damageNum;
	public float bigDamageNum;

	[Header("Žó‚¯“n‚µ")]
	public PlayerMove playerMoveSqr;
	public SceneController sceneController;

	// Start is called before the first frame update
	void Update()
	{
		if(isDamage == true)
		{
			//_x = playerMoveSqr.radius * Mathf.Sin(-time);
			//_z = playerMoveSqr.radius * Mathf.Cos(-time);

			//transform.position = new Vector3(_x, transform.position.y, _z);

			if (timer >= totalTime)
			{
				isDamage = false;
				timer = 0;
				speed = 0;
			}
		}

		

	}

	private void FixedUpdate()
	{
		if(isDamage == true)
		{
			timer += Time.deltaTime;

			speed = addSpeed;
			//speed = MyEasing.QuartIn(timer, totalTime, 0.1f, 0);
		}

		time += speed;
	}

	public void Damage()
	{
		isDamage = true;
		nowHp -= damageNum;

		if(nowHp <= 0)
		{
			nowHp = 0;
			sceneController.sceneChange("GameClearScene");
		}
	}

	public void BigDamage()
	{
		isDamage = true;
		nowHp -= bigDamageNum;

		if (nowHp <= 0)
		{
			nowHp = 0;
			sceneController.sceneChange("GameClearScene");
		}
	}
}
