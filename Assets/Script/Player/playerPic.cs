using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPic : MonoBehaviour
{
	public Material material;

	public PlayerMove moveSqr;

	[SerializeField] Texture texLeft;
	[SerializeField] Texture texRight;

	public bool isDamage;
	public float damageTimer;
	[SerializeField] float DamageTime;
	[SerializeField] Texture texLeftDamage;
	[SerializeField] Texture texRightDamage;

	// Start is called before the first frame update
	void Start()
	{
		material.SetTexture("_MainTex", texLeft);
	}

	// Update is called once per frame
	void Update()
	{
		if(moveSqr.lookLeft)
		{
			if(isDamage)
			{
				material.SetTexture("_MainTex", texLeftDamage);
			}
			else
			{
				material.SetTexture("_MainTex", texLeft);
			}
		}
		else
		{
			if (isDamage)
			{
				material.SetTexture("_MainTex", texRightDamage);
			}
			else
			{
				material.SetTexture("_MainTex", texRight);
			}
		}

		if(isDamage)
		{
			damageTimer++;
			if(damageTimer >= DamageTime)
			{
				isDamage = false;
				damageTimer = 0;
			}
		}
	}
}
