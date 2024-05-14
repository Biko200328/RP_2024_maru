using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPGauge : MonoBehaviour
{
	public float maxHp;
	public float nowHp;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		var scale = gameObject.transform.localScale;
		scale.z = nowHp / maxHp;
		gameObject.transform.localScale = scale;
	}
}
