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
		if(nowHp <= 0)
		{
			nowHp = 0;
		}
	}

	public void InsekiDamage()
	{
		nowHp -= insekiDamageNum;
		if (nowHp <= 0)
		{
			nowHp = 0;
		}
	}

	public void tuckleDamage()
	{
		nowHp -= tuckleDamageNum;
		if (nowHp <= 0)
		{
			nowHp = 0;
		}
	}

}
