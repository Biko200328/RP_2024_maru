using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
	public float nowHp;
	public float maxHp;

	public float bulletDamageNum;
	public float insekiDamageNum;
	public float tuckleDamageNum;
	public float selfDamageNum;

	public playerPic picSqr;

	public SceneController sceneController;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void BulletDamage()
	{
		nowHp -= bulletDamageNum;
		picSqr.isDamage = true;
		picSqr.damageTimer = 0;
		if(nowHp <= 0)
		{
			nowHp = 0;
			sceneController.sceneChange("GameOverScene");
		}
	}

	public void InsekiDamage()
	{
		nowHp -= insekiDamageNum;
		picSqr.isDamage = true;
		picSqr.damageTimer = 0;
		if (nowHp <= 0)
		{
			nowHp = 0;
			sceneController.sceneChange("GameOverScene");
		}
	}

	public void tuckleDamage()
	{
		nowHp -= tuckleDamageNum;
		picSqr.isDamage = true;
		picSqr.damageTimer = 0;
		if (nowHp <= 0)
		{
			nowHp = 0;
			sceneController.sceneChange("GameOverScene");
		}
	}

	public void SelfDamage()
	{
		nowHp -= selfDamageNum;
		picSqr.isDamage = true;
		picSqr.damageTimer = 0;
		if (nowHp <= 0)
		{
			nowHp = 0;
			sceneController.sceneChange("GameOverScene");
		}
	}

}
