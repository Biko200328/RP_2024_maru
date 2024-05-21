using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPGauge : MonoBehaviour
{
	public float maxHp;
	public float nowHp;

	public EnemyDamage enemyDamageSqr;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		nowHp = enemyDamageSqr.nowHp;
		maxHp = enemyDamageSqr.maxHp;

		var scale = gameObject.transform.localScale;
		scale.x = nowHp / maxHp;
		gameObject.transform.localScale = scale;
	}
}
